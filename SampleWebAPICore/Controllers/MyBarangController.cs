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
        [HttpGet("{kodebarang}")]
        public Barang Get(string kodebarang)
        {
            var result = barangDal.GetById(kodebarang);
            return result;
        }

        // POST api/<MyBarangController>
        [HttpPost]
        public IActionResult Post(Barang barang)
        {
            try
            {
                barangDal.Insert(barang);
                return Ok($"Data {barang.namabarang} berhasil ditambah");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // PUT api/<MyBarangController>/5
        [HttpPut("{kodebarang}")]
        public IActionResult Put(string kodebarang,Barang barang)
        {
            try
            {
                barangDal.Update(kodebarang, barang);
                return Ok($"Data barang dengan kode {barang.kodebarang} berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // DELETE api/<MyBarangController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
