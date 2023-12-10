﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fac.src.MySql
{
    public struct ModeloJsonMysql
    {

        [JsonProperty("datasource")]
        public string Datasource { get; private set; }

        [JsonProperty("port")]
        public uint Port { get; private set; }

        [JsonProperty("username")]
        public string Username { get; private set; }

        [JsonProperty("password")]
        public string Password { get; private set; }

        [JsonProperty("database")]
        public string Database { get; private set; }



    }
}
