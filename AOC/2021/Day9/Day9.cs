using AOC._2021.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Day9
{
    public class Day9: Day
    {
        private string? _input;
        private string? _sample;
       
        public async Task<long> Part_One()
        {
             _input = await GetInputForDayAsync(9);
            var sample = @"2199943210
                                 3987894921
                                 9856789892
                                 8767896789
                                 9899965678";
            var lines = _input.ToLines().Select(x => x.ToCharArray().AsInt32s()).ToArray();
            var rows = lines.Length;
            var cols = lines[0].Count;
            var lastRow = rows - 1;
            var lastCol = cols - 1;
            var val = 0;
            int danger = 0;
            List<(int x, int y, int val)> lowest = new();

            for (int y = 0; y < rows; ++y)
            {
                for (int x = 0; x < cols; ++x)
                {
                    val = lines[y][x];
                    if (x > 0 && val >= lines[y][x - 1]) continue;
                    if (x < lastCol && val >= lines[y][x + 1]) continue;
                    if (y > 0 && val >= lines[y - 1][x]) continue;
                    if (y < lastRow && val >= lines[y + 1][x]) continue;
                    lowest.Add((x, y, val));
                }
            }

            foreach (var point in lowest)
            {
                Console.WriteLine($"{point.x}, {point.y} => {point.val}");
                danger += point.val + 1;
            }
            var pTwo = await Part_Two(lines, lowest);
            Console.WriteLine($"Part 2 - {pTwo}");
            return danger;
        }

        public async Task<long> Part_Two(List<int>[] lines, List<(int x, int y, int val)> basins)
        {
            var rows = lines.Length;
            var cols = lines[0].Count;
            var lastRow = rows - 1;
            var lastCol = cols - 1;
            (int x, int y) target;
            List<(int x, int y, int size)> sizes = new();
            HashSet<(int x, int y)> parts = new(), newParts = new HashSet<(int x, int y)>();
            foreach (var basin in basins)
            {
                parts.Clear();
               
                parts.Add((basin.x, basin.y));
                do
                {
                    
                    newParts.Clear();
                    foreach (var part in parts)
                    {
                        target = (part.x - 1, part.y);
                        if (!parts.Contains(target) && target.x >= 0 && lines[target.y][target.x] < 9) newParts.Add(target);
                        target = (part.x + 1, part.y);
                        if (!parts.Contains(target) && target.x <= lastCol && lines[target.y][target.x] < 9) newParts.Add(target);
                        target = (part.x, part.y - 1);
                        if (!parts.Contains(target) && target.y >= 0 && lines[target.y][target.x] < 9) newParts.Add(target);
                        target = (part.x, part.y + 1);
                        if (!parts.Contains(target) && target.y <= lastRow && lines[target.y][target.x] < 9) newParts.Add(target);
                    }
                    if(newParts.Count > 0) parts.UnionWith(newParts);
                } while (newParts.Count > 0);
                sizes.Add((basin.x, basin.y, parts.Count));
            }
            foreach (var basin in sizes)
            {
                Console.WriteLine($"{basin.x}, {basin.y}, => {basin.size} parts");
            }
            var biggest = sizes.OrderByDescending(x => x.size).Take(3).ToList();
            return biggest[0].size * biggest[1].size * biggest[2].size;
        }
    }
}
