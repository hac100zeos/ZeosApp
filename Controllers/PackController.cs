// <copyright file="PackController.cs" company="ZEOS">
// Copyright (c) ZEOS. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ZeosApp.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using MongoDB.Driver;
	using ZeosApp.Models;

	[Authorize]
	[Route("api/[controller]")]
	public class PackController : Controller
	{
		private readonly IMongoDatabase database = null;
		private readonly MongoClient client = null;

		public PackController(DataAccess access)
		{
			client = access.InitializeClient();
			database = client.GetDatabase("ZeosApp", null);
		}

		[HttpGet("[action]")]
		public ActionResult<Pack> GetAll()
		{
			var packs = database.GetCollection<Pack>("PackInstance");
			if (packs == null)
			{
				return NotFound();
			}

			return new ObjectResult(packs);
		}
	}
}
