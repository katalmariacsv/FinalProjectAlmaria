using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.DataModels
{
    public class BookingIdModel
    {
        [JsonProperty("bookingid")]
        public long Bookingid { get; set; }

        [JsonProperty("booking")]
        public BookingModel Booking { get; set; }
    }
}
