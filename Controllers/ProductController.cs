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

		public ProductController(DataAccess access)
		{
			client = access.InitializeClient();
			database = client.GetDatabase("ZeosApp", null);
		}

		[HttpGet("[action]")]
		public ActionResult<Product> GetAll()
		{
			var products = database.GetCollection<Product>("Products");
			var result = products.Find(p => true).ToEnumerable();
			if (result == null)
			{
				return NotFound();
			}
			return new ObjectResult(result);
		}

		[HttpGet("[action]")]
		public ActionResult<Product> Get(string name)
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
		public ActionResult<Product[]> Search(string query)
		{
			var products = database.GetCollection<Product>("Products");
			var result = products.Find(p => p.Name.Contains(query)).ToList();
			if (result == null)
			{
				return NotFound();
			}
			return new ObjectResult(result);
		}
	}
}
