using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Day6
{
    [MemoryDiagnoser]
    public class Day6: Day
    {
        private string? _input;

        public async Task<ulong> Part_One()
        {
            _input = await GetInputForDayAsync(6);
            return SolveBase();
            //var lines = _input.Split(new String[] { ",", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            //var fish = new List<int>();
            //var spawnedFish = new List<int>();

            //foreach (var line in lines)
            //    fish.Add(int.Parse(line));

            //for (int day = 0; day < 80; day++)
            //{
            //    for (int x = fish.Count() - 1; x >= 0; x--)
            //    {
            //        int fishLife = fish[x];
            //        if (fishLife > 0)
            //        {
            //            fish[x] = fishLife - 1;
            //        }
            //        else if (fishLife == 0)
            //        {
            //            fish[x] = 6;
            //            fish.Add(8);
            //        }
            //    }
            //}
            //return fish.Count();
        }

        [Benchmark]
        public ulong Part_Two()
        {
            _input = GetInputForDay(6);
            return SolveBase();
            //_input = GetInputForDay(6);
            //Span<ulong> initialCounts = stackalloc ulong[9];

            //var totalFish = 0ul;
            //for (var i = 0; i < _input.Length - 1; i += 2)
            //{
            //    initialCounts[_input[i] - '0']++;
            //    totalFish++;
            //}

            //var pivot = 0;
            //for (var i = 1; i <= 256; ++i)
            //{
            //    var count = initialCounts[pivot];
            //    totalFish += count;
            //    initialCounts[(pivot + 7) % 9] += count;
            //    pivot = (pivot + 1) % 9;
            //}

            //return totalFish;
        }

        private ulong SolveBase()
        {
            Span<ulong> initialCounts = stackalloc ulong[9];

            var totalFish = 0ul;
            for (var i = 0; i < _input.Length - 1; i += 2)
            {
                initialCounts[_input[i] - '0']++;
                totalFish++;
            }

            var pivot = 0;
            for (var i = 1; i <= 256; ++i)
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
