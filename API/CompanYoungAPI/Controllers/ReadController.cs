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
        public ActionResult<DataEntry> Get()
        {
            return Ok(_readDataAccess.Get());
        }

		// GET: api/Read/5
		[HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Read
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Read/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Read/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
