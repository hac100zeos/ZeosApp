namespace ZeosApp.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using MongoDB.Driver;
	using ZeosApp.Models;

	[Authorize]
	[Route("api/[controller]")]
	public class PackController : Controller
	{
		private readonly IMongoDatabase database = null;

		public PackController(DataAccess access)
		{
			access.InitializeClient();
		}

		[HttpGet("[action]")]
		public ActionResult<Pack> Packs()
		{
			var packs = database.GetCollection<Pack>("pack");

			return packs == null ? (ActionResult<Pack>)NotFound() : (ActionResult<Pack>)new ObjectResult(packs);
		}
	}
}
