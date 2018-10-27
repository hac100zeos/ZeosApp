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

		public PackController()
		{
			DataAccess.InitializeClient();
		}

		[HttpGet("[action]")]
		public ActionResult<Pack> Packs()
		{
			var packs = database.GetCollection<Pack>("pack");
			
			if (packs == null)
			{
				return NotFound();
			}
			return new ObjectResult(packs);
		}


	}
}
