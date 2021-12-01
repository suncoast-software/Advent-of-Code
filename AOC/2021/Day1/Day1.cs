using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Day1
{
    public class Day1: Day
    {
        private string? _input;
        private string? _testInput;

        public async Task<int> Part_One()
        {
            _input = await GetInputForDay(1);
            var lines = _input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var increased = 0;
            for (var i = 0; i < _input.Length - 1; i++)
            {
                if (i == 0)
                    continue;
                var currentLine = int.Parse(lines[i]);
                var previousLine = int.Parse(lines[i - 1]);
                if (currentLine > previousLine)
                    increased++;
            }
            return increased;
        }

        public async Task<int> Part_Two()
        {
            _input = await GetInputForDay(1);
            var lines = _input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            var increased = 0;
            var nums = lines.Select(x => int.TryParse(x, out int parsed)).ToArray();
            for (var i = 0; i < lines.Count() - 3; i++)
            {
                if(nums[i])
                {
                    var groupOne = int.Parse(lines[i]) + int.Parse(lines[i + 1]) + int.Parse(lines[i + 2]);
                    var groupTwo = int.Parse(lines[i + 1]) + int.Parse(lines[i + 2]) + int.Parse(lines[i + 3]);
                    if (groupTwo > groupOne)
                        increased++;
                     
                }
               
            }
            return increased;
        }
    }
}
