// <copyright file="Startup.cs" company="ZEOS">
// Copyright (c) ZEOS. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
namespace ZeosApp
{
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.SpaServices.AngularCli;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Swashbuckle.AspNetCore.Swagger;

	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		private IConfiguration Configuration { get; }

		/// <summary>
		/// This method gets called by the runtime. Use this method to add services to the container.
		/// </summary>
		/// <param name="services">IServiceCollection injection.</param>
		public static void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" }); });

			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/dist"; });
		}

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
	}
}
