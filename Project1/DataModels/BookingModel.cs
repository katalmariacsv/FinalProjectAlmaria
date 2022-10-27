using Newtonsoft.Json;

namespace Project1.DataModels
{
    public class BookingModel
    {
        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("totalprice")]
        public long Totalprice { get; set; }

        [JsonProperty("depositpaid")]
        public bool Depositpaid { get; set; }

        [JsonProperty("bookingdates")]
        public BookingDatesModel Bookingdates { get; set; }

        [JsonProperty("additionalneeds")]
        public string Additionalneeds { get; set; }
    }
}
