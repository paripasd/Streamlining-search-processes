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
        // DELETE
        [HttpDelete("{id}")]
        public void DeleteById(string id)
        {
           _deleteDataAccess.DeleteById(id);
        }
    }
}
