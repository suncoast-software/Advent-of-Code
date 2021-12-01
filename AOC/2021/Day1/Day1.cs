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
            var result = lines.OrderBy(x => x).ToList();
            for (int i = 0; i < result.Count(); i++)
            {
                if (i == 0)
                    continue;
                var currentLine = int.Parse(result[i]);
                var previousLine = int.Parse(result[i - 1]);
                if (currentLine > previousLine)
                    increased++;
            }
            return increased;
        }

        public async Task<int> Part_Two()
        {
            _input = await GetInputForDay(1);
            var lines = _input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var increased = 0;
            var result = lines.OrderBy(x => x).ToList();
            for (int i = 0; i < result.Count() - 3; i++)
            {
                
                var currentLine = int.Parse(lines[i]);
                var secondLine = int.Parse(lines[i + 1]);
                var thirdLine = int.Parse(lines[i + 2]);
                var fourthLine = int.Parse(lines[i + 3]);
                var groupOne = new int[3];
                var groupTwo = new int[3];
                groupOne[0] = currentLine;
                groupOne[1] = secondLine;
                groupOne[2] = thirdLine;
                groupTwo[0] = secondLine;
                groupTwo[1] = thirdLine;
                groupTwo[2] = fourthLine;
                var groupOneTotal = groupOne.Sum();
                var groupTwoTotal = groupTwo.Sum();
                if (groupTwoTotal > groupOneTotal)
                    increased++;
            }
            return increased;
        }
    }
}
