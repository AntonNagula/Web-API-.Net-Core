using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Voucher
    {
        public int VoucherId { get; set; }
        public string Hotel { get; set; }
        public string Country { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }
        public bool HasFlight { get; set; }
    }
}
