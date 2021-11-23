using System;
using System.Collections.Generic;

#nullable disable

namespace SewaLap.Models
{
    public partial class Transaksi
    {
        public int IdTransaksi { get; set; }
        public int? IdAdmin { get; set; }
        public int? IdLapangan { get; set; }
        public int? IdCustomer { get; set; }
        public string TotalTransaksi { get; set; }

        public virtual Admin IdAdminNavigation { get; set; }
        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual Lapangan IdLapanganNavigation { get; set; }
    }
}
