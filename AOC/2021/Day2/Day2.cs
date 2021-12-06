using AOC._2021.Extensions;
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
        public async Task<int> Solve(int day)
        {
            _input = await GetInputForDayAsync(2);
            var lines = _input.Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
            var subDepth = 0;
            var position = 0;
            var aim = 0;
            foreach (var line in lines)
            {
                var command = line.Split(" ")[0];
                var amount = line.Split(" ")[1].ToInt();

               switch (command)
                {
                    case "down":
                        aim += amount;
                        break;

                    case "up":
                        aim -= amount;
                        break;

                    case "forward":
                        position += amount;
                        subDepth += aim * amount;
                        break;

                        default:
                        break;
                }
            }
            return subDepth * position;
        }
    }
}
