﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.DataModels
{
    public class TokenModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
