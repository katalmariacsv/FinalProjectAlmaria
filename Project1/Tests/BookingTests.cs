using Newtonsoft.Json;
using System.Net;
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

            var addedData = GenerateBooking.CreateBooking();

            Assert.AreEqual(addedData.Firstname, getCreatedBookingResponse.Firstname, "First name does not match.");
            Assert.AreEqual(addedData.Lastname, getCreatedBookingResponse.Lastname, "Last name does not match.");
            Assert.AreEqual(addedData.Totalprice, getCreatedBookingResponse.Totalprice, "Total price does not match.");
            Assert.AreEqual(addedData.Depositpaid, getCreatedBookingResponse.Depositpaid, "Deposit paid does not match.");
            Assert.AreEqual(addedData.Bookingdates.Checkin, getCreatedBookingResponse.Bookingdates.Checkin, "Checkin does not match.");
            Assert.AreEqual(addedData.Bookingdates.Checkout, getCreatedBookingResponse.Bookingdates.Checkout, "Checkout does not match.");
            Assert.AreEqual(addedData.Additionalneeds, getCreatedBookingResponse.Additionalneeds, "Additional needs does not match.");

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
                Firstname = "Ana",
                Lastname = "Santos",
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

            Assert.AreEqual(updatedData.Firstname, getUpdatedBookingResponse.Firstname, "First name does not match.");
            Assert.AreEqual(updatedData.Lastname, getUpdatedBookingResponse.Lastname, "Last name does not match.");
            Assert.AreEqual(updatedData.Totalprice, getUpdatedBookingResponse.Totalprice, "Total price does not match.");
            Assert.AreEqual(updatedData.Depositpaid, getUpdatedBookingResponse.Depositpaid, "Deposit paid does not match.");
            Assert.AreEqual(updatedData.Bookingdates.Checkin, getUpdatedBookingResponse.Bookingdates.Checkin, "Checkin does not match.");
            Assert.AreEqual(updatedData.Bookingdates.Checkout, getUpdatedBookingResponse.Bookingdates.Checkout, "Checkout does not match.");
            Assert.AreEqual(updatedData.Additionalneeds, getUpdatedBookingResponse.Additionalneeds, "Additional needs does not match.");

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

            Assert.AreEqual(deleteBooking.StatusCode, HttpStatusCode.Created, "Status code does not match.");
        }

        [TestMethod]
        public async Task GetRandomBookingId()
        {
            bookingHelper = new BookingHelper();

            var getCreatedBooking = await bookingHelper.GetBookingById(1230916);

            Assert.AreEqual(HttpStatusCode.NotFound, getCreatedBooking.StatusCode, "Status code does not match.");
        }
    }
}