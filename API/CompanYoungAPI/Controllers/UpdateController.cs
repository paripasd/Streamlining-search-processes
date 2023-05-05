using CompanYoungAPI.DataAccess;
using CompanYoungAPI.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanYoungAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        private UpdateDataAccess _updateDataAccess;

        public UpdateController()
        {
            _updateDataAccess = new();
        }
        // PUT api/<UpdateController>/5
        [HttpPut]
        public ActionResult UpdateInstance([FromBody] DataEntry data)
        {
            bool success = _updateDataAccess.UpdateInstance(data);
            if (!success)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

		[HttpPut("expiry")]
        public void UpdateTagsByExpiry()
		{
            _updateDataAccess.UpdateExpiresSoonTagPlus();
            _updateDataAccess.UpdateExpiredTagPlus();
            _updateDataAccess.UpdateExpiressoonTagByDate();
			_updateDataAccess.UpdateExpiredTagByDate();
		}
    }
}
