// <copyright file="Startup.cs" company="ZEOS">
// Copyright (c) ZEOS. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ZeosApp
{
	using System;
	using System.Collections.Generic;
	using System.IdentityModel.Tokens.Jwt;
	using System.Text;
	using AspNetCore.Identity.MongoDbCore.Models;
	using Microsoft.AspNetCore.Authentication.JwtBearer;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.SpaServices.AngularCli;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.IdentityModel.Tokens;
	using Swashbuckle.AspNetCore.Swagger;
	using ZeosApp.Models;

	public class Startup
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Startup"/> class.
		/// </summary>
		/// <param name="configuration">IConfiguration injection.</param>
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		private IConfiguration Configuration { get; }

		/// <summary>
		/// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		/// </summary>
		/// <param name="app">IApplicationBuilder injection.</param>
		/// <param name="env">IHostingEnvironment injection.</param>
		public static void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseAuthentication();
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseSpaStaticFiles();
			app.UseSwagger();
			app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller}/{action=Index}/{id?}");
			});
			app.UseSpa(spa =>
			{
				// To learn more about options for serving an Angular SPA from ASP.NET Core,
				// see https://go.microsoft.com/fwlink/?linkid=864501
				spa.Options.SourcePath = "ClientApp";
				if (env.IsDevelopment())
				{
					spa.UseAngularCliServer(npmScript: "start");
				}
			});
		}

		/// <summary>
		/// This method gets called by the runtime. Use this method to add services to the container.
		/// </summary>
		/// <param name="services">IServiceCollection injection.</param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
				var security = new Dictionary<string, IEnumerable<string>>
				{
					{"Bearer", new string[] { }},
				};

				c.AddSecurityDefinition("Bearer", new ApiKeyScheme
				{
					Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
					Name = "Authorization",
					In = "header",
					Type = "apiKey"
				});
				c.AddSecurityRequirement(security);
			});

			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/dist"; });

			services.AddIdentity<ApplicationUser, MongoIdentityRole>()
				.AddMongoDbStores<ApplicationUser, MongoIdentityRole, Guid>(
					this.Configuration["MongoDB:ConnectionString"],
					this.Configuration["MongoDB:Database"])
				.AddDefaultTokenProviders();

			JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
			services
				.AddAuthentication(options =>
				{
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(cfg =>
				{
					cfg.RequireHttpsMetadata = false;
					cfg.SaveToken = true;
					cfg.TokenValidationParameters = new TokenValidationParameters
					{
						ValidIssuer = this.Configuration["JwtIssuer"],
						ValidAudience = this.Configuration["JwtIssuer"],
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Configuration["JwtKey"])),
						ClockSkew = TimeSpan.Zero,
					};
				});

			services.AddSingleton<DataAccess>();
		}
	}
}
