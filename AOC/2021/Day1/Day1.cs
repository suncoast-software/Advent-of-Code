using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Day1
{
    public class Day1: Day
    {
        private string[]? _input;
        private string? _testInput;

        public int Part_One()
        {
            _input = ReadInput(1);
            var increased = 0;
            var result = _input.OrderBy(x => x).ToList();
            for (int i = 0; i < _input.Count(); i++)
            {
                if (i == 0)
                    continue;
                var currentLine = int.Parse(_input[i]);
                var previousLine = int.Parse(_input[i - 1]);
                if (currentLine > previousLine)
                    increased++;
            }
            return increased;
        }
    }
}
