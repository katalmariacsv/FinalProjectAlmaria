using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.Resources
{
    /// <summary>
    /// Class containing all endpoints used in API tests
    /// </summary>
    public class Endpoints
    {
        //Base URL
        public const string baseURL = "https://restful-booker.herokuapp.com";

        public static string PostToken() => $"{baseURL}/auth";

        public static string PostBooking() => $"{baseURL}/booking";
        public static string GetBookingId(long bookingid) => $"{baseURL}/booking/{bookingid}";
        public static string DeleteBookingId(long bookingid) => $"{baseURL}/booking/{bookingid}";
    }
}
