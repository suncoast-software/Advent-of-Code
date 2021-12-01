using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC.Config
{
    public class Configuration
    {
        public static string GetSecretJson()
        {
            var configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "secret.json");
            using var fs = File.OpenRead(configFile);
            using var sr = new StreamReader(fs, new UTF8Encoding(false));
            var json = sr.ReadToEnd();

            var configJson = JsonConvert.DeserializeObject<Config>(json);

            return configJson;
        }
    }
}
