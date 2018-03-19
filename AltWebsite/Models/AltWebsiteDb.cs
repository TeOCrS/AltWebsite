using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

namespace AltWebsite.Models
{
    public class AltWebsiteDb: DbContext
    {
        public DbSet<Tourist> Tourists { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<TouristInfo> TouristInfos { get; set; }
    }
}