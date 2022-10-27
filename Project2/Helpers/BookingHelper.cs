using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Project2.DataModels;
using Project2.Tests.TestData;
using Project2.Resources;

[assembly: Parallelize(Workers = 10, Scope = ExecutionScope.MethodLevel)]
namespace Project2.Helpers
{
    /// <summary>
    /// Class containing all methods for booking
    /// </summary>
    public class BookingHelper
    {
        /// <summary>
        /// Send POST request to add new booking
        /// </summary>
        ///
        public static async Task<BookingIdModel> AddNewBooking(RestClient client)
        {
            var newBookingData = GenerateBooking.CreateBooking();
            var postRequest = new RestRequest(Endpoints.PostBooking());

            //Send Post Request to add new user
            postRequest.AddJsonBody(newBookingData);
            postRequest.AddHeader("Content-Type", "application/json");
            postRequest.AddHeader("Accept", "application/json");

            var postResponse = await client.ExecutePostAsync<BookingIdModel>(postRequest);
            return postResponse.Data;
        }

        public static async Task<BookingModel> GetNewBooking(RestClient client, long bookingId)
        {
            var getRequest = new RestRequest(Endpoints.GetBookingId(bookingId));
            getRequest.AddHeader("Accept", "application/json");

            var getResponse = await client.ExecuteGetAsync<BookingModel>(getRequest);
            return getResponse.Data;

        }
    }
}
