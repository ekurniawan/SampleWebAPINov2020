using SampleWebAPICore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using Microsoft.Extensions.Configuration;

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

        private string GetConnStr()
        {
            return _config.GetConnectionString("DefaultConnection");
        }

        public void Delete(string kodebarang)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Insert(Barang barang)
        {
            throw new NotImplementedException();
        }

        public void Update(string kodebarang, Barang barang)
        {
            throw new NotImplementedException();
        }
    }
}
