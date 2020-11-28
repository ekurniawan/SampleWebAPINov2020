using SampleWebAPICore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace SampleWebAPICore.DAL
{
    public class BarangDAL 
    {
        private IConfiguration _config;
        public BarangDAL(IConfiguration config)
        {
            _config = config;
        }

        public BarangDAL()
        {
        }

        //mengambil connection string
        private string GetConnStr()
        {
            return _config.GetConnectionString("DefaultConnection");
        }

        public void Delete(string kodebarang)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Barang> GetAllBarang()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(GetConnStr()))
            {
                string strSql = @"select * from barang order by namabarang asc";
                var results = conn.Query<Barang>(strSql);
                return results;
            }
        }

        

        public IEnumerable<Barang> GetAll()
        {
            using(NpgsqlConnection conn = new NpgsqlConnection(GetConnStr()))
            {
                //data dari datatabase ditampung di list
                List<Barang> lstBarang = new List<Barang>();
                string strSql = @"select * from barang order by namabarang asc";
                NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn);
                conn.Open();
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lstBarang.Add(new Barang
                        {
                            kodebarang = dr["kodebarang"].ToString(),
                            namabarang = dr["namabarang"].ToString(),
                            stok = Convert.ToInt32(dr["stok"]),
                            hargabeli = Convert.ToInt64(dr["hargabeli"]),
                            hargajual = Convert.ToUInt64(dr["hargajual"])
                        });
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();

                return lstBarang;
            }
        }

        public Barang GetById(string kodebarang)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(GetConnStr()))
            {
                string strSql = @"select * from barang where kodebarang=@kodebarang";
                var param = new { kodebarang = kodebarang };
                var result = conn.QuerySingleOrDefault<Barang>(strSql,param);
                return result;
            }
        }

        public void Insert(Barang barang)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(GetConnStr()))
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
                }
                catch (NpgsqlException sqlEx)
                {
                    throw new Exception($"Error: {sqlEx.Message}");
                }
            }
        }

        public void Update(string kodebarang, Barang barang)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(GetConnStr()))
            {
                //cek apakah data yg akan diupdate ditemukan
                var result = GetById(kodebarang);
                if (result == null)
                {
                    throw new Exception($"Data dengan kode {barang.kodebarang} tidak ditemukan");
                }

                //jika ditemukan, update data
                string strSql = @"update barang set namabarang=@namabarang,stok=@stok,hargabeli=@hargabeli,
                hargajual=@hargajual where kodebarang=@kodebarang";
                var param = new
                {
                    namabarang = barang.namabarang,stok = barang.stok,hargabeli = barang.hargabeli,
                    hargajual = barang.hargajual,kodebarang = kodebarang
                };
                try
                {
                    conn.Execute(strSql, param);
                }
                catch (NpgsqlException sqlEx)
                {
                    throw new Exception($"Error: {sqlEx.Message}");
                }
            }
        }
    }
}
