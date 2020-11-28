﻿using System;
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

        //untuk get by id
        // GET api/<BarangDbController>/5
        [HttpGet("{kodebarang}")]
        public Barang Get(string kodebarang)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(strConn))
            {
                string strSql = @"select * from barang where kodebarang=@kodebarang";
                var param = new { kodebarang = kodebarang };
                var result = conn.QuerySingle<Barang>(strSql, param);
                return result;
            }
        }

        // POST api/<BarangDbController>
        [HttpPost]
        public IActionResult Post(Barang barang)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(strConn))
            {
                string strSql = @"insert into barang(kodebarang,namabarang,stok,hargabeli,hargajual) 
                values(@kodebarang,@namabarang,@stok,@hargabeli,@hargajual)";
                var param = new
                {
                    kodebarang = barang.kodebarang,
                    namabarang = barang.namabarang,
                    stok = barang.stok,
                    hargabeli = barang.hargabeli,
                    hargajual = barang.hargajual
                };
                try
                {
                    conn.Execute(strSql, param);
                    //ok ini adalah http status 200
                    return Ok($"Data barang {barang.kodebarang} berhasil ditambahkan ");
                }
                catch (NpgsqlException ex)
                {
                    return BadRequest($"Error: {ex.Message}");
                }
            }
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
