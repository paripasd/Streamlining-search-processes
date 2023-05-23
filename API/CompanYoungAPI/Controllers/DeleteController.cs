using CompanYoungAPI.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CompanYoungAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        private DeleteDataAccess _deleteDataAccess;

        public DeleteController()
        {
            _deleteDataAccess = new();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteById(string id)
        {
           bool success = _deleteDataAccess.DeleteById(id);
            if (success)
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
