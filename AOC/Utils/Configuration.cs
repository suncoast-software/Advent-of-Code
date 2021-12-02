using AOC.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC
{
    public class Configuration
    {
        public static Config GetSecretJson()
        {
            var configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Utils", "secret.json");
            using var fs = File.OpenRead(configFile);
            using var sr = new StreamReader(fs, new UTF8Encoding(false));
            var json = sr.ReadToEnd();

            var configJson = JsonConvert.DeserializeObject<AOC.Utils.Config>(json);

            return configJson;
        }
    }
}
