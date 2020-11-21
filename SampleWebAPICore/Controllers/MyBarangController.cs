using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SampleWebAPICore.DAL;
using SampleWebAPICore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyBarangController : ControllerBase
    {
        private BarangDAL barangDal;
        public MyBarangController(IConfiguration config)
        {
            barangDal = new BarangDAL(config);
        }

        // GET: api/<MyBarangController>
        [HttpGet]
        public IEnumerable<Barang> Get()
        {
            var results = barangDal.GetAllBarang();
            return results;
        }

        // GET api/<MyBarangController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MyBarangController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MyBarangController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MyBarangController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
