using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.DataModels;

namespace Project1.Tests.TestData
{
    public class GenerateBooking
    {
        public static BookingModel CreateBooking()
        {
            return new BookingModel
            {
                Firstname = "Maria",
                Lastname = "Cruz",
                Totalprice = 100,
                Depositpaid = true,
                Bookingdates = new BookingDatesModel()
                {
                    Checkin = "2018-01-01",
                    Checkout = "2018-01-01"
                },
                Additionalneeds = "Breakfast"
            };
        }
    }
}
