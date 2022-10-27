using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project2.DataModels;
using Project2.Helpers;
using Project2.Resources;
using RestSharp;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Project2.Tests
{
    [TestClass]
    public class Project2Tests : ApiBaseTest
    {
        private static List<BookingIdModel> userCleanUpList = new List<BookingIdModel>();

        [TestMethod]
        public async Task GetBooking()
        {
            //Arrange
            BookingIdModel BookingIdDetails = await BookingHelper.AddNewBooking(RestClient);
            userCleanUpList.Add(BookingIdDetails);

            //Act
            var demoResponse = await BookingHelper.GetNewBooking(RestClient, BookingIdDetails.Bookingid);

            //Assert
            //Assert.AreEqual(HttpStatusCode.OK, demoResponse.StatusCode, "Failed due to wrong status code.");
            Assert.AreEqual(BookingIdDetails.Booking.Firstname, demoResponse.Firstname);
            Assert.AreEqual(BookingIdDetails.Booking.Lastname, demoResponse.Lastname);
            Assert.AreEqual(BookingIdDetails.Booking.Totalprice, demoResponse.Totalprice);
            Assert.AreEqual(BookingIdDetails.Booking.Depositpaid, demoResponse.Depositpaid);
            Assert.AreEqual(BookingIdDetails.Booking.Bookingdates.Checkin, demoResponse.Bookingdates.Checkin);
            Assert.AreEqual(BookingIdDetails.Booking.Bookingdates.Checkout, demoResponse.Bookingdates.Checkout);
            Assert.AreEqual(BookingIdDetails.Booking.Additionalneeds, demoResponse.Additionalneeds);
        }

        [TestMethod]
        public async Task UpdateBooking()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public async Task DeleteCreatedBooking()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public async Task GetRandomBooking()
        {
            //Arrange
            var demoGetRequest = new RestRequest(Endpoints.GetBookingId(1230916));
            demoGetRequest.AddHeader("Accept", "application/json");

            //Act
            var demoResponse = await RestClient.ExecuteGetAsync<BookingModel>(demoGetRequest);

            //Assert
            Assert.AreEqual(HttpStatusCode.NotFound, demoResponse.StatusCode, "Failed due to wrong status code.");
        }

        [TestCleanup]
        public async Task TestCleanUp()
        {
            foreach (var data in userCleanUpList)
            {
                var deleteUserRequest = new RestRequest(Endpoints.GetBookingId(data.Bookingid));
            }
        }
    }
}
