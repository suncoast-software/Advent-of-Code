using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Benchmarks.Day5
{
    [MemoryDiagnoser]
    public class Day5_Benchmark: Day
    {
        [Benchmark]
        public async Task<int> Solve_Part1()
        {
            var input = await GetInputForDayAsync(5);

            var parse = (string s) =>
            {
                var parts = s.Split(" -> ");
                var x1 = int.Parse(parts[0].Split(",")[0]);
                var y1 = int.Parse(parts[0].Split(",")[1]);
                var x2 = int.Parse(parts[1].Split(",")[0]);
                var y2 = int.Parse(parts[1].Split(",")[1]);

                return ((x1, y1), (x2, y2));
            };
            var lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries).Select(parse).ToArray();
            var grid = new Dictionary<(int x, int y), int>();

            for (int i = 0; i < lines.Length; i++)
            {
                ((var x1, var y1), (var x2, var y2)) = lines[i];

                if (x1 == x2)
                {
                    var beginning = Math.Min(y1, y2);
                    var end = Math.Max(y1, y2);
                    for (int y = beginning; y <= end; y++)
                    {
                        if (grid.ContainsKey((x1, y)))
                        {
                            grid[(x1, y)]++;
                        }
                        else
                        {
                            grid[(x1, y)] = 1;
                        }
                    }
                }
                else if (y1 == y2)
                {
                    var beginning = Math.Min(x1, x2);
                    var end = Math.Max(x1, x2);
                    for (int x = beginning; x <= end; x++)
                    {
                        if (grid.ContainsKey((x, y1)))
                        {
                            grid[(x, y1)]++;
                        }
                        else
                        {
                            grid[(x, y1)] = 1;
                        }
                    }
                }
                else if (Math.Abs(x2 - x1) == Math.Abs(y2 - y1))
                {
                    if (x1 < x2 && y1 < y2)
                    {
                        int y = y1;
                        for (int x = x1; x <= x2; x++)
                        {
                            if (grid.ContainsKey((x, y)))
                            {
                                grid[(x, y)]++;
                            }
                            else
                            {
                                grid[(x, y)] = 1;
                            }
                            y++;
                        }
                    }

                    if (x1 < x2 && y1 > y2)
                    {
                        int y = y1;
                        for (int x = x1; x <= x2; x++)
                        {
                            if (grid.ContainsKey((x, y)))
                            {
                                grid[(x, y)]++;
                            }
                            else
                            {
                                grid[(x, y)] = 1;
                            }
                            y--;
                        }
                    }

                    if (x1 > x2 && y1 < y2)
                    {
                        int y = y2;
                        for (int x = x2; x <= x1; x++)
                        {
                            if (grid.ContainsKey((x, y)))
                            {
                                grid[(x, y)]++;
                            }
                            else
                            {
                                grid[(x, y)] = 1;
                            }
                            y--;
                        }
                    }
                    if (x1 > x2 && y1 > y2)
                    {
                        int y = y2;
                        for (int x = x2; x <= x1; x++)
                        {
                            if (grid.ContainsKey((x, y)))
                            {
                                grid[(x, y)]++;
                            }
                            else
                            {
                                grid[(x, y)] = 1;
                            }
                            y++;
                        }
                    }
                }
            }
            var count = 0;
            foreach ((var pos, var countP) in grid)
            {
                if (countP >= 2)
                    count++;
            }
            return count;
        }
    }
}
