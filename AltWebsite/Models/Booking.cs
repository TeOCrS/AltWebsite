using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AltWebsite.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int PaymentId { get; set; }

        public int TouristId { get; set; }

        [DisplayName("Start Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime StartDate { get; set; }

        [DisplayName("End date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime EndDate { get; set; }

        [DisplayName("Interval")]
        public TimeSpan Interval { get; set; }

        [DisplayName("Booking website")]
        public ComingFromWebsite Website { get; set; }

        public virtual Tourist Tourist { get; set; }

        public virtual Payment Payment { get; set; }
    }
}