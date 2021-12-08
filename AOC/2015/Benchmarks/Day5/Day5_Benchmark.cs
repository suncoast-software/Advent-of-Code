using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC._2015.Benchmark.Day5
{
    [MemoryDiagnoser]
    public class Day5_Benchmark: Day
    {
        private string[]? _input;

        [Benchmark]
        public int Part_One()
        {
            _input = ReadInput(5);
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
            string[] badChars = new string[] { "ab", "cd", "pq", "xy" };
            var nice = new List<string>();
            for (int i = 0; i < _input.Length; i++)
            {
                var currentLine = _input[i];
                var vCount = currentLine.ToLower().Count(x => vowels.Contains(x)); // need to be 3 or more vowels
                var badMatch = CheckBadMatch(currentLine, badChars);
                var doubleChar = false; // needs to be true double char

                for (int x = 0; x < currentLine.Length - 1; x++)
                {
                    doubleChar = CheckDoubleMatch(currentLine[x], currentLine[x + 1]);
                    if (doubleChar)
                        break;
                }

               

                if (vCount > 2 && badMatch == false && doubleChar)
                    nice.Add(currentLine);
            }
            return nice.Count();
        }

        [Benchmark]
        public int Part_Two()
        {
            _input = ReadInput(5);
            var nice = new List<string>();
            for (int i = 0; i < _input.Length; i++)
            {
                var currentLine = _input[i];
                var cRes = @"(.).\1";
                var aRes = @"S*(\S\S)\S*\1\S*";
                var res = new Regex(cRes);
                var resTwo = new Regex(aRes);

                if (resTwo.IsMatch(currentLine) && res.IsMatch(currentLine))
                    nice.Add(currentLine);

            }

            return nice.Count();
        }

        private bool CheckBadMatch(string s1, string[] bad)
        {
            foreach (var item in bad)
            {
                if (s1.Contains(item))
                    return true;
            }
            return false;
        }

        private bool CheckDoubleMatch(char s1, char s2)
        {
            if (s1 == s2)
                return true;

            return false;
        }
    }
}
