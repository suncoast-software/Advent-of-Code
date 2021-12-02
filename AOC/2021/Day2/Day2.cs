using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Day2
{
    public class Day2: Day
    {
        private string _input;
        public async Task<int> Part_One(int day)
        {
            _input = await GetInputForDay(2);
            var lines = _input.Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
            var subDepth = 0;
            var position = 0;
            foreach (var line in lines)
            {
                var command = line.Split(" ")[0];
                var amount = line.Split(" ")[1];

                int depth = command switch
                {
                    "up" => subDepth -= int.Parse(amount),
                    "down" => subDepth += int.Parse(amount),
                    "forward" => position += int.Parse(amount),
                    _ => 0
                };
            }
            return subDepth * position;
        }
    }
}
