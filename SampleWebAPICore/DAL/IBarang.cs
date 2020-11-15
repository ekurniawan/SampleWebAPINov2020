using SampleWebAPICore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPICore.DAL
{
    public interface IBarang
    {
        IEnumerable<Barang> GetAll();
        Barang GetById(string kodebarang);
        void Insert(Barang barang);
        void Update(string kodebarang, Barang barang);
        void Delete(string kodebarang);
    }
}
