using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZeosApp.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using MongoDB.Bson;
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
		public ActionResult<PackInstance> packInstanceID(string catID)
		{
			var packInstance = database.GetCollection<BsonDocument>("packInstance");
			var products = database.GetCollection<Product>("product");
			var result = products.Find(p => p.Category.Equals(catID)).Limit(3);

			Random r = new Random(553);
			string packInstanceID = r.ToString();

			var document = new BsonDocument
			{
				{"PackInstanceID", new BsonString(packInstanceID)},
				{"Price", new BsonString("100")},
				{"Products", new BsonArray(result.ToString()) },
			};

			packInstance.InsertOneAsync(document);

			if (result == null)
			{
				return NotFound();
			}

			return new ObjectResult(result);
		}

		[HttpPost("[action]")]
		public ActionResult<PackInstance> ProductPack(string packID)
		{
			var pack = database.GetCollection<Pack>("pack");
			var result = pack.Find(p => p.PackID.Equals(packID));

			if (result == null)
			{
				return NotFound();
			}

			return new ObjectResult(result);
		}

	}
}
