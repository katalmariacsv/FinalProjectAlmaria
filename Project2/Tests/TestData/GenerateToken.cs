using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project2.DataModels;

namespace Project2.Tests.TestData
{
    public class GenerateToken
    {
        public static UserTokenModel CreateToken()
        {
            return new UserTokenModel
            {
                Username = "admin",
                Password = "password123"
            };
        }
    }
}
