namespace ZeosApp.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using MongoDB.Bson;
	using MongoDB.Bson.Serialization;
	using MongoDB.Driver;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Bson;
	using ZeosApp.Models;

	[Authorize]
	[Route("api/[controller]")]
	public class ProductController : Controller
	{
		private readonly IMongoDatabase database = null;
		private readonly MongoClient client = null;

		public ProductController(DataAccess access)
		{
			client = access.InitializeClient();
			database = client.GetDatabase("ZeosApp", null);
		}


		[HttpGet("[action]")]
		public ActionResult<Product> GetProducts()
		{
			var products = database.GetCollection<Product>("Products");
			if (products == null)
			{
				return NotFound();
			}
			return new ObjectResult(products);
		}

		[HttpGet("[action]")]
		public ActionResult<Product> GetProduct(string name)
		{
			var product = database.GetCollection<Product>("Products");
			var result = product.Find(p => p.Name.Equals(name)).Single();
			if (result == null)
			{
				return NotFound();
			}

			return new ObjectResult(result);
		}

		[HttpGet("[action]")]
		public ActionResult<Product> SearchProduct(string name)
		{
			var products = database.GetCollection<Product>("Products");
			var result = products.Find(p => p.Name.Equals(name)).ToList();
			if (result == null)
			{
				return NotFound();
			}

			return new ObjectResult(result);
		}
	}
}
