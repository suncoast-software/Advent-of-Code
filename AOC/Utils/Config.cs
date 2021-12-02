using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC.Utils
{
    public class Config
    {
        [JsonProperty("secret")]
        public string Secret { get; set; }

    }
}
