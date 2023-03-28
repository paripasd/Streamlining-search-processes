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

        [HttpGet("tree")]
        public ActionResult<IEnumerable<ReadDataAccess.Node>> GetTreeStructure()
		{
            return Ok(_readDataAccess.GetTreeStructure());
		}
	}
}
