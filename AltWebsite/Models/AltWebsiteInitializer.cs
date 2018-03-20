using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AltWebsite.Models
{
    public class AltWebsiteInitializer : System.Data.Entity.DropCreateDatabaseAlways<AltWebsiteDb>
    {
        protected override void Seed(AltWebsiteDb context)
        {

            var touristInfos = new List<TouristInfo>()
            {
                new TouristInfo()
                {
                     FirstName = "Martin",
                     LastName = "Martin",
                     Country = "England",
                     EmailAddress = "martin@gmail.com",
                     PreferedLanguage = "English"
                },
                                new TouristInfo()
                {
                     FirstName = "Ana",
                     LastName = "Ana",
                     Country = "Germany",
                     EmailAddress = "ana@gmail.com",
                     PreferedLanguage = "German"
                },
                                    new TouristInfo()
                {
                     FirstName = "Ana",
                     LastName = "Ana",
                     Country = "Germany",
                     EmailAddress = "ana@gmail.com",
                     PreferedLanguage = "German"
                }
            };

            context.TouristInfos.AddRange(touristInfos);
            context.SaveChanges();

            var tourists = new List<Tourist>()
            {
                new Tourist()
                {
                     Comments = "test1",
                     Review = "10",
                     TouristInfoId = 1
                },
                                new Tourist()
                {
                     Comments = "test2",
                     Review = "9",
                     TouristInfoId = 2
                }
            };
            context.Tourists.AddRange(tourists);
            context.SaveChanges();

            var payments = new List<Payment>()
            {
                new Payment()
                {
                    PricePerDay = 35,
                    CommisionFee = 10,
                    CleanupFee = 8,
                    TotalPrice = 150
                },
                 new Payment()
                {
                    PricePerDay = 40,
                    CommisionFee = 10,
                    CleanupFee = 8,
                    TotalPrice = 200
                },
                  new Payment()
                {
                    PricePerDay = 45,
                    CommisionFee = 10,
                    CleanupFee = 8,
                    TotalPrice = 250
                }
            };

            context.Payments.AddRange(payments);
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
            context.Bookings.AddRange(bookings);
            context.SaveChanges();


          

        }
    }
}