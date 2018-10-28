using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using ZeosApp.HelperFunctions;
using ZeosApp.Models;

namespace ZeosApp.Controllers
{
	using System;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using MongoDB.Driver;
	using ZeosApp.Models;

	[Authorize]
	[Route("api/[controller]")]
	public class PackInstanceController : Controller
	{
		private readonly IMongoDatabase database = null;
		private readonly MongoClient client = null;

		public PackInstanceController(DataAccess access)
		{
			client = access.InitializeClient();
			database = client.GetDatabase("ZeosApp", null);
		}

		[HttpPost("[action]")]
		public async Task<int> OpenPack(int catID)
		{
			var packInstance = database.GetCollection<PackInstance>("PackInstance");
			var product = database.GetCollection<Product>("Products");
			var result = await product.Find(p => p.CategoryId == catID).ToListAsync();

			Random random = new Random(553);
			// Any random integer
			int num = random.Next();

			var document = new PackInstance
			{
				PackInstanceID = num.ToString(),
				Price = 100,
				Products = result,
			};

			await packInstance.InsertOneAsync(document);

			return num;
		}

		[HttpPost("[action]")]
		public ActionResult<PackInstance> ProductPack(string packID)
		{
			var pack = database.GetCollection<PackInstance>("PackInstance");
			var result = pack.Find(p => p.PackInstanceID.Equals(packID)).Single();

			if (result == null)
			{
				return NotFound();
			}

			return new ObjectResult(result);
		}

		[HttpPost("[action]")]
		public ActionResult<PackInstance> Get()
		{
			var collection = database.GetCollection<BsonDocument>("PackInstance");

			var result = new DeserializeHelper().Deserialize(collection);

			if (result == null)
			{
				return NotFound();
			}

			return new ObjectResult(result);
		}
	}
}
