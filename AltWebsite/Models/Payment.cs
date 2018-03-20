using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltWebsite.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public double PricePerDay { get; set; }
        public double CommisionFee { get; set; }
        public double CleanupFee { get; set; }
        public double NetAmount { get; set; }
    }
}