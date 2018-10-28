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
					ImageUrl = "https://www.google.co.uk/url?sa=i&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwiasNK4laneAhUJhRoKHRaXBIoQjRx6BAgBEAU&url=https%3A%2F%2Fwww.ebay.co.uk%2Fitm%2FDurex-Red-Strawberry-flavours-Taste-Me-condoms-x1-3-6-10-20-30-50-PCS-%2F111887449893&psig=AOvVaw1FgOuw2vtKWQOt1k_D7bl4&ust=1540817175931225",
					taglines = new string[]{"Os likes small things", "Joe is buying extra small condoms"}
				},

				new Product
				{
					Category = "Personal hygiene",
					CategoryId = 1,
					Description = "Very sharp...",
					Name = "Razors",
					Price = 900,
					ImageUrl = "https://www.google.co.uk/url?sa=i&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwi0udnOlaneAhWIyoUKHYMgDIIQjRx6BAgBEAU&url=https%3A%2F%2Fondemand.gillette.com%2Fen-us%2Fmen%2Fshaving%2Fblades-razors%2F4-mach3-razor-blade-cartridges-handle-included%2F00047400664296.html&psig=AOvVaw2u0h62QjpK0Y-tIiaH9v8k&ust=1540817214214131",
					taglines = new string[]{"Buying this cus I'm a f****** hairy beast", "Razor is for p******"}
				},

				new Product
				{
					Category = "Flat Screen TVs",
					CategoryId = 1,
					Description = "87-inch, 1366x768 Pixel, 16:9, HDTV ready",
					Name = "Flat Watch HD37",
					Price = 1199,
					ImageUrl = "https://www.google.co.uk/url?sa=i&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwiBip7ylaneAhVnxYUKHfzXAKUQjRx6BAgBEAU&url=https%3A%2F%2Fwww.amazon.com%2FSamsung-UN32EH5300-32-Inch-1080p-Smart%2Fdp%2FB0074FGNJ6&psig=AOvVaw0CwDs5yEV_AS5wU2orjMy8&ust=1540817259901566",
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
