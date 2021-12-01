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
            for (var i = 0; i < _input.Length - 1; i++)
            {
                if (int.Parse(_input[i + 1]) > int.Parse(_input[i]))
                    increased++;
            }
            return increased;
        }

        public int Part_Two()
        {
            _input = ReadInput(1);
            var increased = 0;
            for (var i = 0; i < _input.Length - 3; i++)
            {
                var groupOne = int.Parse(_input[i]) + int.Parse(_input[i + 1]) + int.Parse(_input[i + 2]);
                var groupTwo = int.Parse(_input[i + 1]) + int.Parse(_input[i + 2]) + int.Parse(_input[i + 3]);
                if (groupTwo > groupOne)
                    increased++;
            }
            return increased;
        }
    }
}
