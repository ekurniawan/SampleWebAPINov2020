using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebAPICore.Models
{
    //
    public class Barang
    {
        public string kodebarang { get; set; }
        public string namabarang { get; set; }
        public int stok { get; set; }
        public decimal hargabeli { get; set; }
        public decimal hargajual { get; set; }
    }
}
