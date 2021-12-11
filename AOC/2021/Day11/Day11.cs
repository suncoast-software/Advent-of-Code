using AOC._2021.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Day11
{
    public class Day11 : Day
    {


        public async Task<int> Part_One()
        {
            var _input = @"2566885432
3857414357
6761543247
5477332114
3731585385
1716783173
1277321612
3371176148
1162578285
6144726367".ToLines().Select(x => x.ToCharArray().AsInt32s()).ToList();

            HashSet<(int y, int x)> flashed = new();
            List<(int y, int x)> neighbors = new()
            {
                (-1, -1),
                (-1, 0),
                (-1, 1),
                (0, -1),
                (0, 1),
                (1, -1),
                (1, 0),
                (1, 1),
            };
            int flashCount = 0;
            int simSteps = 100;
            int rows = 10;
            int cols = 10;
            int mapSize = rows * cols;
            int lastRow = rows - 1;
            int lastCol = cols - 1;
            int targetX, targetY;
            Action<(int y, int x)>? increment = null;
            increment = (pos) =>
            {
                if (++_input[pos.y][pos.x] > 9 && !flashed.Contains(pos))
                {
                    ++flashCount;
                    flashed.Add(pos);
                    foreach (var offset in neighbors)
                    {
                        targetX = pos.x + offset.x;
                        targetY = pos.y + offset.y;
                        if (targetX >= 0 && targetX <= lastCol && targetY >= 0 && targetY <= lastRow)
                        {
                            increment((targetY, targetX));
                        }
                    }
                }
            };
            for (int step = 0; step < simSteps; ++step)
            {
                flashed.Clear();
                for (int y = 0; y < rows; ++y)
                {
                    for (int x = 0; x < cols; ++x)
                    {
                        increment((y, x));
                    }
                }
                if (flashed.Count > 0)
                {
                    foreach (var pos in flashed)
                    {
                        _input[pos.y][pos.x] = 0;
                    }
                }
            }
            return flashCount;
        }
  

    public async Task<int> Part_Two()
    {
        var _input = @"2566885432
3857414357
6761543247
5477332114
3731585385
1716783173
1277321612
3371176148
1162578285
6144726367".ToLines().Select(x => x.ToCharArray().AsInt32s()).ToList();

        HashSet<(int y, int x)> flashed = new();
        List<(int y, int x)> neighbors = new()
        {
            (-1, -1),
            (-1, 0),
            (-1, 1),
            (0, -1),
            (0, 1),
            (1, -1),
            (1, 0),
            (1, 1),
        };
        int flashCount = 0;
        int rows = 10;
        int cols = 10;
        int lastRow = rows - 1;
        int lastCol = cols - 1;
        int mapSize = rows * cols;
        int targetX, targetY;
        Action<(int y, int x)>? increment = null;
        increment = (pos) =>
        {
            if (++_input[pos.y][pos.x] > 9 && !flashed.Contains(pos))
            {
                ++flashCount;
                flashed.Add(pos);
                foreach (var offset in neighbors)
                {
                    targetX = pos.x + offset.x;
                    targetY = pos.y + offset.y;
                    if (targetX >= 0 && targetX <= lastCol && targetY >= 0 && targetY <= lastRow)
                    {
                        increment((targetY, targetX));
                    }
                }
            }
        };

        int stepCount = 0;
        while (flashed.Count != mapSize)
        {
            flashed.Clear();
            for (int y = 0; y < rows; ++y)
            {
                for (int x = 0; x < cols; ++x)
                {
                    increment((y, x));
                }
            }
            if (flashed.Count > 0)
            {
                foreach (var pos in flashed)
                {
                    _input[pos.y][pos.x] = 0;
                }
            }
            ++stepCount;
        }
        return stepCount;
    }
  }
}

