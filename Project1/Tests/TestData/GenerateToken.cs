using Project1.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Tests.TestData
{
    public class GenerateToken
    {
        public static UserTokenModel userTokenDetails()
        {
            return new UserTokenModel
            {
                Username = "admin",
                Password = "password123"
            };
        }
    }
}
