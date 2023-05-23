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
		private CreateDataAccess _createDataAccess;

		public CreateController()
		{
            _createDataAccess = new();
		}

		[HttpPost]
		public ActionResult CreateInstance([FromBody] DataEntry data)
		{
			data.Id = Guid.NewGuid().ToString(); // new unique id is generated
			bool success = _createDataAccess.CreateInstance(data);
			string url = Url.Action("GetById", "Read", new { id = data.Id });
			if (success)
			{
                return Created(url, data); // feedback
			}
			else
			{
				return BadRequest();
			}
		}
	}
}
