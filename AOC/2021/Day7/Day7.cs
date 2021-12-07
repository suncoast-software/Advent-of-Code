using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Day7
{
    public class Day7: Day
    {
        private string? _input;
        private string? _sample = "16,1,2,0,4,2,7,1,2,14";

        public async Task<long> Part_One()
        {
           _input = await GetInputForDayAsync(7);
           var fuels = _sample.Split(new string[] { ",", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            var positions = fuels;

            var maxPosition = positions.Max();
            var minPosition = positions.Min();

            long minimumFuel = int.MaxValue;
            
            for(int loc = minPosition; loc <= maxPosition; loc++)
            {
                long cost = CostToPos(fuels, loc);
                if (cost < minimumFuel)
                    minimumFuel = cost;
            }

            return minimumFuel;
        }

        public async Task<long> Part_Two()
        {
            _input = await GetInputForDayAsync(7);
            var fuels = _input.Split(new string[] { ",", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            var maxPosition = fuels.Max();
            var minPosition = fuels.Min();

            long minimumFuel = int.MaxValue;

            for (int loc = minPosition; loc <= maxPosition; loc++)
            {
                long cost = CostToPos2(fuels, loc);
                if (cost < minimumFuel)
                    minimumFuel = cost;
            }

            return minimumFuel;
        }

        private long CostToPos(List<int> pos, int toPos)
        {
            var cost = 0;
            foreach (var posItem in pos)
                cost += Math.Abs(posItem - toPos);

            return cost;
        }

        private long CostToPos2(List<int> pos, int toPos)
        {
            long cost = 0;
            foreach (var item in pos)
            {
                long dist = Math.Abs(toPos - item);
                cost += dist * (dist + 1) / 2L;
            }

            return cost;
        }
    }
}
