// <copyright file="AccountController.cs" company="ZEOS">
// Copyright (c) ZEOS. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
namespace ZeosApp.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.IdentityModel.Tokens.Jwt;
	using System.Linq;
	using System.Security.Claims;
	using System.Text;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Configuration;
	using Microsoft.IdentityModel.Tokens;
	using ZeosApp.Models;

	[Route("api/[controller]")]
	public class AccountController : Controller
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IConfiguration _configuration;

		public AccountController(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			IConfiguration configuration)
		{
			this._userManager = userManager;
			this._signInManager = signInManager;
			this._configuration = configuration;
		}

		[HttpPost("[action]")]
		public async Task<object> Login([FromBody] LoginDto model)
		{
			var result = await this._signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

			if (!result.Succeeded)
			{
				throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
			}

			var appUser = this._userManager.Users.SingleOrDefault(r => r.Email == model.Email);
			return this.GenerateJwtToken(model.Email, appUser);
		}

		[HttpPost("[action]")]
		public async Task<object> Register([FromBody] RegisterDto model)
		{
			var user = new ApplicationUser
			{
				UserName = model.Email,
				Email = model.Email,
			};
			var result = await this._userManager.CreateAsync(user, model.Password);

			if (!result.Succeeded)
			{
				Console.WriteLine(result.ToString());
				throw new ApplicationException("UNKNOWN_ERROR");
			}

			await this._signInManager.SignInAsync(user, false);
			return this.GenerateJwtToken(model.Email, user);
		}

		private string GenerateJwtToken(string email, ApplicationUser user)
		{
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, email),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
			};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["JwtKey"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var expires = DateTime.Now.AddDays(Convert.ToDouble(this._configuration["JwtExpireDays"]));

			var token = new JwtSecurityToken(
				this._configuration["JwtIssuer"],
				this._configuration["JwtIssuer"],
				claims,
				expires: expires,
				signingCredentials: creds);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public class LoginDto
		{
			[Required]
			public string Email { get; set; }

			[Required]
			public string Password { get; set; }
		}

		public class RegisterDto
		{
			[Required]
			public string Email { get; set; }

			[Required]
			[StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
			public string Password { get; set; }
		}
	}
}
