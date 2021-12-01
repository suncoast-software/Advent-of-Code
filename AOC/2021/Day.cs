using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021
{
    public class Day
    { 
        internal static async Task<string> GetInputForDay(int day)
        {
            string input;

            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "2021", $"Day{day}", "input.txt");
            if (!File.Exists(fileName))
            {
                string url = $"https://adventofcode.com/2021/day/{day}/input";
                var cookies = new CookieContainer();
                cookies.Add(new Cookie()
                {
                    Domain = ".adventofcode.com",
                    Name = "session",
                    Value = "53616c7465645f5fdca0523b10cb01cb6bc720f3468a09b24c17d0b62b43d5ad22a55618c70306bd211e339b7548577e"
                });
                using var handler = new HttpClientHandler() { CookieContainer = cookies };
                using var client = new HttpClient(handler);
                input = await client.GetStringAsync(url);
                await File.WriteAllTextAsync(fileName, input);
            }
            else
            {
                input = await File.ReadAllTextAsync(fileName);
            }

            return input;
        }
    }
}
