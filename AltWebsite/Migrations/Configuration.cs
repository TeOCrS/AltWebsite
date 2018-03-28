namespace AltWebsite.Migrations
{
    using AltWebsite.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AltWebsite.Models.AltWebsiteDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AltWebsiteDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var tourists = new List<Tourist>()
            {
                new Tourist()
                {
                     Comments = "test1",
                     Review = "10",
                     FirstName = "Martin",
                     LastName = "Martin",
                     Country = "England",
                     EmailAddress = "martin@gmail.com",
                     PreferedLanguage = "English"
                },
                new Tourist()
                {
                     Comments = "test2",
                     Review = "9",
                     FirstName = "Ana",
                     LastName = "Ana",
                     Country = "Germany",
                     EmailAddress = "ana@gmail.com",
                     PreferedLanguage = "German"
                }
            };

            context.Tourists.AddOrUpdate(tourists.ToArray());
            context.SaveChanges();

            var payments = new List<Payment>()
            {
                new Payment()
                {
                    PricePerDay = 35,
                    CommisionFee = 10,
                    CleanupFee = 8,
                },
                 new Payment()
                {
                    PricePerDay = 40,
                    CommisionFee = 10,
                    CleanupFee = 8,
                },
                  new Payment()
                {
                    PricePerDay = 45,
                    CommisionFee = 10,
                    CleanupFee = 8,
                }
            };

            context.Payments.AddOrUpdate(payments.ToArray());
            context.SaveChanges();

            var bookings = new List<Booking>()
            {
                new Booking()
                    {
                    StartDate = new DateTime(2017, 10, 5),
                    EndDate = new DateTime(2017,10,10),
                    Website = ComingFromWebsite.BookingCom,
                    PaymentId = 1,
                    TouristId = 1
                },

                new Booking()
                    {
                    StartDate = new DateTime(2017, 11, 5),
                    EndDate = new DateTime(2017,11,10),
                    Website = ComingFromWebsite.BookingCom,
                    PaymentId = 2,
                    TouristId = 2
                },

                new Booking()
                    {
                    StartDate = new DateTime(2017, 12, 5),
                    EndDate = new DateTime(2017,12,10),
                    Website = ComingFromWebsite.AirBnb,
                    PaymentId = 3,
                    TouristId = 2
                }
        };
            context.Bookings.AddOrUpdate(bookings.ToArray());
            context.SaveChanges();
        }
    }
}
