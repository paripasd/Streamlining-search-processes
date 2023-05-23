using CompanYoungAPI.DataAccess;
using CompanYoungAPI.Model;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult UpdateTagsByExpiry()
		{
            // checking all timeframes and setting the Expired and Expires Soon tag accordingly
            // Solr doesn't update tags on its own so we implemented our custom logic for it in the API
            bool step_one = _updateDataAccess.UpdateExpiresSoonTagPlus();
            bool step_two = _updateDataAccess.UpdateExpiredTagPlus();
            bool step_three = _updateDataAccess.UpdateExpiressoonTagByDate();
            bool step_four = _updateDataAccess.UpdateExpiredTagByDate();
            if (step_one && step_two && step_three && step_four)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
		}
    }
}
