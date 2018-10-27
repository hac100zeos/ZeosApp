namespace ZeosApp.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using MongoDB.Driver;
	using ZeosApp.Models;

	[Authorize]
	[Route("api/[controller]")]
	public class ProductController : Controller
	{
		private readonly IMongoDatabase database = null;
		private readonly MongoClient client = null;

		public ProductController()
		{
			client = DataAccess.InitializeClient();
			database = client.GetDatabase("ZeosAppDB", null);
		}

		[HttpGet("[action]")]
		public ActionResult<Product> GetProducts()
		{
			var products = database.GetCollection<Product>("product");
			if (products == null)
			{
				return NotFound();
			}
			return new ObjectResult(products);
		}

		[HttpGet("[action]")]
		public ActionResult<Product> GetProduct(string name)
		{
			var product = database.GetCollection<Product>("product");
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
			var products = database.GetCollection<Product>("product");
			var result = products.Find(p => p.Name.Equals(name)).ToList();
			if (result == null)
			{
				return NotFound();
			}

			return new ObjectResult(result);
		}
	}
}
