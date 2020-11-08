﻿using System;
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
        //https://localhost:44313/api/Barang/DataPelanggan/123?nama=Budi
        [HttpGet]
        [Route("GetByName/{namaBarang}")]
        public IEnumerable<Barang> GetByName(string namaBarang)
        {
            var results = from b in lstBarang
                          where b.NamaBarang.ToLower().Contains(namaBarang.ToLower())
                          select b;

            return results;
        }


        //https://localhost:44313/api/Barang/GetByNamaDanStok/Key?stok=10
        [HttpGet]
        [Route("GetByNamaDanStok/{nama}")]
        public IEnumerable<Barang> GetByNamaDanStok(string nama,[FromQuery] int stok)
        {
            var results = from b in lstBarang
                          where b.NamaBarang.ToLower().Contains(nama.ToLower()) && b.Stok > stok
                          select b;
            return results;
        }

        // POST api/<BarangController>
        [HttpPost]
        public IActionResult Post(Barang barang)
        {
            return Ok($"KodeBarang: {barang.KodeBarang} - NamaBarang: {barang.NamaBarang} - Stok: {barang.Stok}");
        }

        // PUT api/<BarangController>/5
        [HttpPut("{KodeBarang}")]
        public IActionResult Put(string KodeBarang, Barang barang)
        {
            return Ok($"KodeBarang: {KodeBarang} - NamaBarang: {barang.NamaBarang} - Stok: {barang.Stok}");
        }

        // DELETE api/<BarangController>/5
        [HttpDelete("{KodeBarang}")]
        public IActionResult Delete(string KodeBarang)
        {
            return Ok($"Anda berhasil mendele data {KodeBarang}");
        }
    }
}
