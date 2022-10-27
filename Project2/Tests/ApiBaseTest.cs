using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Project2.DataModels;
using Project2.Helpers;
using RestSharp.Authenticators;

namespace Project2.Tests
{
    public class ApiBaseTest
    {
        public RestClient RestClient { get; set; }

        public BookingIdModel BookingIdDetails { get; set; }

        [TestInitialize]
        public void Initilize()
        {
            RestClient = new RestClient();
        }

        [TestCleanup]
        public void CleanUp()
        {

        }
    }
}
