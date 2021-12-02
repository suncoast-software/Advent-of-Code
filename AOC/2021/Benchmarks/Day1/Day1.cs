
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Benchmarks.Day1
{
    [MemoryDiagnoser]
    public class Day1: Day
    {
         private string? _input;
        [Benchmark]
        public int Part_One()
        {

            _input = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "2021", "Benchmarks", "Day1", "input.txt");
          
            var lines = _input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
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
    }
}
