using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltWebsite.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public double TotalPrice { get; set; }
        public double PricePerDay { get; set; }
        public double ComisionFee { get; set; }
        public double CleanupFee { get; set; }
    }
}