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
                kodebarang = "KK001",
                namabarang = "Keyboard Logitech",
                stok = 12,
                hargabeli = 200000,
                hargajual = 250000
            };
            Barang barang2 = new Barang
            {
                kodebarang = "KK002",
                namabarang = "Keyboard Samsung",
                stok = 13,
                hargabeli = 2500000,
                hargajual = 3000000
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
                          where b.kodebarang == KodeBarang
                          select b).SingleOrDefault();
            return result;
        }

        //menambahkan custom route pada web api
        //https://localhost:44313/api/Barang/DataPelanggan/123?nama=Budi
        [HttpGet]
        [Route("GetByName/{namaBarang}")]
        public IEnumerable<Barang> GetByName(string namaBarang)
        {
            var results = from b in lstBarang
                          where b.namabarang.ToLower().Contains(namaBarang.ToLower())
                          select b;

            return results;
        }


        //https://localhost:44313/api/Barang/GetByNamaDanStok/Key?stok=10
        [HttpGet]
        [Route("GetByNamaDanStok/{nama}")]
        public IEnumerable<Barang> GetByNamaDanStok(string nama,[FromQuery] int stok)
        {
            var results = from b in lstBarang
                          where b.namabarang.ToLower().Contains(nama.ToLower()) && b.stok > stok
                          select b;
            return results;
        }

        // POST api/<BarangController>
        [HttpPost]
        public IActionResult Post(Barang barang)
        {
            return Ok($"KodeBarang: {barang.kodebarang} - NamaBarang: {barang.namabarang} - Stok: {barang.stok}");
        }

        // PUT api/<BarangController>/5
        [HttpPut("{KodeBarang}")]
        public IActionResult Put(string KodeBarang, Barang barang)
        {
            return Ok($"KodeBarang: {KodeBarang} - NamaBarang: {barang.namabarang} - Stok: {barang.stok}");
        }

        // DELETE api/<BarangController>/5
        [HttpDelete("{KodeBarang}")]
        public IActionResult Delete(string KodeBarang)
        {
            return Ok($"Anda berhasil mendele data {KodeBarang}");
        }
    }
}
