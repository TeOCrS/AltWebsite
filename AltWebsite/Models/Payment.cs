using System.ComponentModel;

namespace AltWebsite.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [DisplayName("Price/ Day")]
        public double PricePerDay { get; set; }

        [DisplayName("Commision")]
        public double CommisionFee { get; set; }

        [DisplayName("Clean up fee")]
        public double CleanupFee { get; set; }
    }
}