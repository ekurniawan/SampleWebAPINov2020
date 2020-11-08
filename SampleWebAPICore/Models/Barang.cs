using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPICore.Models
{
    //
    public class Barang
    {
        public string KodeBarang { get; set; }
        public string NamaBarang { get; set; }
        public int Stok { get; set; }
        public decimal HargaBeli { get; set; }
        public decimal HargaJual { get; set; }
    }
}
