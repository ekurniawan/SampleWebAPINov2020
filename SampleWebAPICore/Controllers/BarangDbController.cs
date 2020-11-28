using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Npgsql;
using Dapper;
using SampleWebAPICore.Models;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarangDbController : ControllerBase
    {
        private string strConn = string.Empty;
        private IConfiguration _config;
        public BarangDbController(IConfiguration config)
        {
            _config = config;
            strConn = _config.GetConnectionString("DefaultConnection");
        }

        // GET: api/<BarangDbController>
        [HttpGet]
        public IEnumerable<Barang> Get()
        {
            using(NpgsqlConnection conn = new NpgsqlConnection(strConn))
            {
                string strSql = @"select * from barang order by namabarang asc";
                var results = conn.Query<Barang>(strSql);
                return results;
            }
        }

        // GET api/<BarangDbController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BarangDbController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BarangDbController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BarangDbController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
