using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPICore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleWebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarangController : ControllerBase
    {
        private List<Barang> lstBarang = new List<Barang>();

        //konstruktor 
        public BarangController()
        {
            Barang barang1 = new Barang
            {
                KodeBarang = "KK001",
                NamaBarang = "Keyboard Logitech",
                Stok = 12,
                HargaBeli = 200000,
                HargaJual = 250000
            };
            Barang barang2 = new Barang
            {
                KodeBarang = "KK002",
                NamaBarang = "Keyboard Samsung",
                Stok = 13,
                HargaBeli = 2500000,
                HargaJual = 3000000
            };
            lstBarang.Add(barang1);
            lstBarang.Add(barang2);
        }

        // GET: api/<BarangController>
        //Ienumerable return banyak object/misal tipe list
        [HttpGet]
        public IEnumerable<Barang> Get()
        {
            return lstBarang;
        }

        // GET api/<BarangController>/5
        [HttpGet("{KodeBarang}")]
        public Barang Get(string KodeBarang)
        {
            var result = (from b in lstBarang
                          where b.KodeBarang == KodeBarang
                          select b).SingleOrDefault();
            return result;
        }

        //menambahkan custom route pada web api
        [HttpGet]
        [Route("GetByName/{namaBarang}")]
        public IEnumerable<Barang> GetByName(string namaBarang)
        {
            var results = from b in lstBarang
                          where b.NamaBarang.Contains(namaBarang)
                          select b;

            return results;
        }

        // POST api/<BarangController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BarangController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BarangController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
