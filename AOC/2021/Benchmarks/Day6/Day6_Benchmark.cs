using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Benchmarks.Day6
{
    [MemoryDiagnoser]
    public class Day6_Benchmark: Day
    {
        private string? _input;

        public ulong Part_One()
        {
            return SolveBase();
        }

        public ulong Part_Two()
        {
            return SolveBase();
        }

        [Benchmark]
        public ulong SolveBase()
        {
            _input = GetInputForDay(6);
            Span<ulong> initialCounts = stackalloc ulong[9];

            var totalFish = 0ul;
            for (var i = 0; i < _input.Length - 1; i += 2)
            {
                initialCounts[_input[i] - '0']++;
                totalFish++;
            }

            var pivot = 0;
            for (var i = 1; i <= 80; ++i)// <------- change 80 to 256 for Part Two
            {
                var count = initialCounts[pivot];
                totalFish += count;
                initialCounts[(pivot + 7) % 9] += count;
                pivot = (pivot + 1) % 9;
            }

            return totalFish;
        }
    }
}
