// <copyright file="ExampleController.cs" company="ZEOS">
// Copyright (c) ZEOS. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
namespace ZeosApp.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	[Authorize]
	[Route("api/[controller]")]
	public class ExampleController : Controller
	{
		[HttpGet("[action]")]
		public ActionResult<object> Index()
		{
			return new
			{
				test = "Test",
			};
		}
	}
}
