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
