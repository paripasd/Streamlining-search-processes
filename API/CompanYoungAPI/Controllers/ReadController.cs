using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CompanYoungAPI.Model;
using CompanYoungAPI.DataAccess;

namespace CompanYoungAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadController : ControllerBase
    {
        private ReadDataAccess _readDataAccess;

        public ReadController()
        {
            _readDataAccess = new();
        }

        // GET: api/Read
        [HttpGet]
        public ActionResult<IEnumerable<DataEntry>> GetAll()
        {
            return Ok(_readDataAccess.GetAll());
        }

        [HttpPost]
        public ActionResult<IEnumerable<DataEntry>> GetAllByPath([FromBody] string[] path)
        {
            return Ok(_readDataAccess.GetAllByPath(path));
        }

		[HttpGet("{id}")]
        public ActionResult<DataEntry> GetById(string id)
		{
            return Ok(_readDataAccess.GetById(id));
		}

        [HttpGet("tree")]
        public ActionResult<IEnumerable<ReadDataAccess.Node>> GetTreeStructure()
		{
            return Ok(_readDataAccess.GetTreeStructure());
		}

		[HttpPost("search/{searchText}")]
        public ActionResult<IEnumerable<DataEntry>> GetBySearch(string searchText, [FromBody] string[] path)
		{
            return Ok(_readDataAccess.GetBySearch(searchText, path));
		}

		[HttpGet("uniquePaths")]
        public ActionResult<IEnumerable<string[]>> GetUniquePaths()
		{
            return Ok(_readDataAccess.GetUniquePaths());
		}

		[HttpGet("institutes")]
        public ActionResult<string> GetInstitutes()
		{
            return Ok(_readDataAccess.GetInstitutes());
		}

		[HttpGet("subpaths/{institute}")]
        public ActionResult<string[]> GetInstituteSubPaths(string institute)
		{
            return Ok(_readDataAccess.GetInstituteSubPaths(institute));
		}

        [HttpGet("cydata")]
        public ActionResult<int> CallServer() 
        {
            return Ok(609);
        }
    }
}
