using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2015
{
    public class Day
    {
        public string[] ReadInput(int day)
        {
            var input = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "2015", $"Day{day}", "input.txt");
           // var input = AppDomain.CurrentDomain.BaseDirectory + $"\\2015\\Day{day}\\input.txt";
            var lines = File.ReadAllText(input).Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToArray();
            return lines;
        }
    }
}
