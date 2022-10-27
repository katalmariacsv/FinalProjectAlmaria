using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Project1.DataModels;
using Project1.Resources;
using Project1.Helpers;
using Project1.Tests.TestData;

[assembly: Parallelize(Workers = 10, Scope = ExecutionScope.MethodLevel)]
namespace Project1.Tests
{
    [TestClass]
    public class BookingTests
    {
        private BookingHelper bookingHelper;

        [TestMethod]
        public async Task GetBooking()
        {
            bookingHelper = new BookingHelper();

            var addBooking = await bookingHelper.AddNewBooking();
            var getResponse = JsonConvert.DeserializeObject<BookingIdModel>(addBooking.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(addBooking.StatusCode, HttpStatusCode.OK);

            var getCreatedBooking = await bookingHelper.GetBookingById(getResponse.BookingId);
            var getCreatedBookingResponse = JsonConvert.DeserializeObject<BookingModel>(getCreatedBooking.Content.ReadAsStringAsync().Result);

            var expectedData = GenerateBooking.CreateBooking();
            Assert.AreEqual(expectedData.Firstname, getCreatedBookingResponse.Firstname);
            Assert.AreEqual(expectedData.Lastname, getCreatedBookingResponse.Lastname);
            Assert.AreEqual(expectedData.Totalprice, getCreatedBookingResponse.Totalprice);
            Assert.AreEqual(expectedData.Depositpaid, getCreatedBookingResponse.Depositpaid);
            Assert.AreEqual(expectedData.Bookingdates.Checkin, getCreatedBookingResponse.Bookingdates.Checkin);
            Assert.AreEqual(expectedData.Bookingdates.Checkout, getCreatedBookingResponse.Bookingdates.Checkout);
            Assert.AreEqual(expectedData.Additionalneeds, getCreatedBookingResponse.Additionalneeds);

            await bookingHelper.DeleteBookingById(getResponse.BookingId);
        }

        [TestMethod]
        public async Task UpdateBooking()
        {
            bookingHelper = new BookingHelper();

            var addBooking = await bookingHelper.AddNewBooking();
            var getResponse = JsonConvert.DeserializeObject<BookingIdModel>(addBooking.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(addBooking.StatusCode, HttpStatusCode.OK);

            var getCreatedBooking = await bookingHelper.GetBookingById(getResponse.BookingId);
            var getCreatedBookingResponse = JsonConvert.DeserializeObject<BookingModel>(getCreatedBooking.Content.ReadAsStringAsync().Result);

            var updatedData = new BookingModel()
            {
                Firstname = "Team.put.updated",
                Lastname = "Spirit.put.updated",
                Totalprice = getCreatedBookingResponse.Totalprice,
                Depositpaid = getCreatedBookingResponse.Depositpaid,
                Bookingdates = getCreatedBookingResponse.Bookingdates,
                Additionalneeds = getCreatedBookingResponse.Additionalneeds
            };
            var updateBooking = await bookingHelper.UpdateBookingById(updatedData, getResponse.BookingId);
            var getUpdateBookingResponse = JsonConvert.DeserializeObject<BookingModel>(updateBooking.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(updateBooking.StatusCode, HttpStatusCode.OK);

            var getUpdatedBooking = await bookingHelper.GetBookingById(getResponse.BookingId);
            var getUpdatedBookingResponse = JsonConvert.DeserializeObject<BookingModel>(getUpdatedBooking.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(updatedData.Firstname, getUpdatedBookingResponse.Firstname);
            Assert.AreEqual(updatedData.Lastname, getUpdatedBookingResponse.Lastname);
            Assert.AreEqual(updatedData.Totalprice, getUpdatedBookingResponse.Totalprice);
            Assert.AreEqual(updatedData.Depositpaid, getUpdatedBookingResponse.Depositpaid);
            Assert.AreEqual(updatedData.Bookingdates.Checkin, getUpdatedBookingResponse.Bookingdates.Checkin);
            Assert.AreEqual(updatedData.Bookingdates.Checkout, getUpdatedBookingResponse.Bookingdates.Checkout);
            Assert.AreEqual(updatedData.Additionalneeds, getUpdatedBookingResponse.Additionalneeds);

            await bookingHelper.DeleteBookingById(getResponse.BookingId);
        }

        [TestMethod]
        public async Task DeleteCreatedBooking()
        {
            bookingHelper = new BookingHelper();

            var addBooking = await bookingHelper.AddNewBooking();
            var getResponse = JsonConvert.DeserializeObject<BookingIdModel>(addBooking.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(addBooking.StatusCode, HttpStatusCode.OK);

            var deleteBooking = await bookingHelper.DeleteBookingById(getResponse.BookingId);

            Assert.AreEqual(deleteBooking.StatusCode, HttpStatusCode.Created);
        }

        [TestMethod]
        public async Task GetRandomBookingId()
        {
            bookingHelper = new BookingHelper();
            Random random = new Random();
            int randomNumber = random.Next(9000000, 999999999);

            var getCreatedBooking = await bookingHelper.GetBookingById(randomNumber);

            Assert.AreEqual(getCreatedBooking.StatusCode, HttpStatusCode.NotFound);
        }
    }
}