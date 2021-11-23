using System;
using System.Collections.Generic;

#nullable disable

namespace SewaLap.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdAdmin { get; set; }
        public string Username { get; set; }
        public string PasswordAdmin { get; set; }
        public string EmailAdmin { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
