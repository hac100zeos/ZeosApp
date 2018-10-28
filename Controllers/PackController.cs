using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZeosApp.Models;


namespace ZeosApp.Controllers
{

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
		public ActionResult<Pack> getPacks()
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
