<<<<<<< Updated upstream
// <copyright file="GeneralController.cs" company="ZEOS">
// Copyright (c) ZEOS. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
namespace ZeosApp.Controllers
{
	using System.Collections.Generic;
	using Microsoft.AspNetCore.Mvc;
	using MongoDB.Bson;
	using MongoDB.Driver;
	using ZeosApp.Models;

	[Route("api/[controller]")]
	public class GeneralController : Controller
	{
		private readonly IMongoDatabase database = null;
		private readonly MongoClient client = null;

		public GeneralController(DataAccess access)
		{
			client = access.InitializeClient();
			database = client.GetDatabase("ZeosApp", null);
		}

		[HttpGet("[action]")]
		public void SeedDb()
		{
			var products = new List<Product>
			{
				new Product
				{
					Category = "Desktop Computers",
					CategoryId = 1,
					Description = "3,4 Ghz quad core, 16 GB DDR3 SDRAM, 4000 GB Hard Disc, Graphic Card: Hurricane GX, Windows 8",
					Name = "Gaming Monster Pro",
					Price = 1700,
					ImageUrl = "test-resources/sap/ui/demokit/explored/img/HT-1603.jpg",
				},

				new Product
				{
					Category = "Desktop Computers",
					CategoryId = 1,
					Description = "2,8 Ghz dual core, 4 GB DDR3 SDRAM, 1000 GB Hard Disc, Graphic Card: Gladiator MX, Windows 8",
					Name = "Family PC Pro",
					Price = 900,
					ImageUrl = "test-resources/sap/ui/demokit/explored/img/HT-1601.jpg",
				},

				new Product
				{
					Category = "Flat Screen TVs",
					Description = "37-inch, 1366x768 Pixel, 16:9, HDTV ready",
					Name = "Flat Watch HD37",
					ImageUrl = "test-resources/sap/ui/demokit/explored/img/HT-6131.jpg",
					Price = 1199,
					CategoryId = 2,
				},
			};
			var collection = database.GetCollection<BsonDocument>("Products");
			foreach (Product item in products)
				collection.InsertOne(item.ToBsonDocument());
		}

		[HttpGet("[action]")]
		public void DropCollection()
		{
			database.DropCollection("Products");
		}
	}
}
=======
namespace ZeosApp.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Mvc;
	using MongoDB.Bson;
	using MongoDB.Driver;
	using ZeosApp.Models;

	[Route("api/[controller]")]
	public class GeneralController : Controller
	{
		private readonly IMongoDatabase database = null;
		private readonly MongoClient client = null;

		public GeneralController(DataAccess access)
		{
			client = access.InitializeClient();
			database = client.GetDatabase("ZeosApp", null);
			SeedDb("Products");
		}

		[HttpGet("[action]")]
		public async Task<bool> SeedDb(String collectionName)
		{
			var products = new List<Product>
			{
				new Product
				{
					Category = "Personal hygiene",
					CategoryId = 1,
					Description = "Pack of condoms",
					Name = "Getting laid tonight",
					Price = 1700,
					ImageUrl = "test-resources/sap/ui/demokit/explored/img/HT-1603.jpg",
					taglines = new string[]{"Os likes small things", "Joe is buying extra small condoms"}
				},

				new Product
				{
					Category = "Personal hygiene",
					CategoryId = 1,
					Description = "Very sharp...",
					Name = "Razors",
					Price = 900,
					ImageUrl = "test-resources/sap/ui/demokit/explored/img/HT-1601.jpg",
					taglines = new string[]{"Buying this cus I'm a f****** hairy beast", "Razor is for p******"}
				},

				new Product
				{
					Category = "Flat Screen TVs",
					Description = "87-inch, 1366x768 Pixel, 16:9, HDTV ready",
					Name = "Flat Watch HD37",
					ImageUrl = "test-resources/sap/ui/demokit/explored/img/HT-6131.jpg",
					Price = 1199,
					CategoryId = 1,
					taglines = new string[]{"Need a tv for my new house", "Black Friday deal"}

				}
			};

			if (database != null) 
			{
				var collection = database.GetCollection<BsonDocument>(collectionName);
				foreach (Product item in products) 
				{
					await collection.InsertOneAsync(item.ToBsonDocument());
				}
			}

			return false;
		}
	}
}
>>>>>>> Stashed changes
