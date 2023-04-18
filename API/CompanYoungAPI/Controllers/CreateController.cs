using System.Runtime.Intrinsics.X86;
using System.Xml;
using CompanYoungAPI.DataAccess;
using CompanYoungAPI.Model;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;

namespace CompanYoungAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CreateController : ControllerBase
	{
		private UpdateDataAccess _updateDataAccess;

		public CreateController()
		{
			_updateDataAccess = new();
		}

		[HttpPost]
		public ActionResult CreateInstance([FromBody] DataEntry data)
		{
			data.Id = Guid.NewGuid().ToString();
			_updateDataAccess.UpdateInstance(data);
			string url = Url.Action("GetById", "Read", new { id = data.Id });
			return Created(url, data);
		}
	}
}
