using System.Net;

namespace AOC
{
    public class Day
    {
        public async Task<string> GetInputForDay(int day)
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
                    Value = Configuration.GetSecretJson().Secret
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

        public async Task<string> GetSampleInputForDay(int day)
        {
            string input;

            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "2021", $"Day{day}", "sample.txt");

            if (!File.Exists(fileName))
            {
                string url = $"https://adventofcode.com/2021/day/{day}/input";
                var cookies = new CookieContainer();
                cookies.Add(new Cookie()
                {
                    Domain = ".adventofcode.com",
                    Name = "session",
                    Value = Configuration.GetSecretJson().Secret
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
