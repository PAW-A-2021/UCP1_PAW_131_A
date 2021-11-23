using System;
using System.Collections.Generic;

#nullable disable

namespace SewaLap.Models
{
    public partial class Lapangan
    {
        public Lapangan()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdLapangan { get; set; }
        public string NamaLapangan { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
