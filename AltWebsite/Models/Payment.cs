using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AltWebsite.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [DisplayName("Total Price")]
        public double TotalPrice { get; set; }

        [DisplayName("Price/ Day")]
        public double PricePerDay { get; set; }

        [DisplayName("Commision")]
        public double CommisionFee { get; set; }

        [DisplayName("Clean up fee")]
        public double CleanupFee { get; set; }

        [DisplayName("Profit")]
        public double Profit { get; set; }
    }
}