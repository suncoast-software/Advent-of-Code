using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Day3
{
    public class Day3: Day
    {
        public async Task<int> Solve_Part1(int day)
        {
            string? _input = await GetInputForDay(day);
            var lines = _input.Trim().Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var lineLength = lines[0].Length;
            var gammaBits = new StringBuilder(lineLength);
            var epsilonBits = new StringBuilder(lineLength);

            for (int i = 0; i < lineLength; i++)
            {
                var mostCommon = MostCommon(i, lines);
                gammaBits.Append(mostCommon);

                var leastCommon = LeastCommon(i, lines);
                epsilonBits.Append(leastCommon);
            }

            var gamma = Convert.ToInt32(gammaBits.ToString(), 2);
            var epsilon = Convert.ToInt32(epsilonBits.ToString(), 2);

            return gamma * epsilon;
        }

        public async Task<int> Solve_Part2(int day)
        {
            string? _input = await GetInputForDay(day);
            var lines = _input.Trim().Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            int lineLength = lines[0].Length;

            var oxygenNums = lines;
            for (int i = 0; i < lineLength; i++)
            {
                var mostCommon = MostCommon(i, oxygenNums);
                oxygenNums = oxygenNums.Count switch
                {
                    > 1 => oxygenNums.Where(x => x[i] == (mostCommon ?? '1')).ToList(),
                    _ => oxygenNums
                };
            }

            var co2Nums = lines;
            for (int i = 0; i < lineLength; i++)
            {
                var leastCommon = LeastCommon(i, co2Nums);
                co2Nums = co2Nums.Count switch
                {
                    > 1 => co2Nums.Where(x => x[i] == (leastCommon ?? '0')).ToList(),
                    _ => co2Nums
                };

            }

            var result = Convert.ToInt32(oxygenNums[0], 2) * Convert.ToInt32(co2Nums[0], 2);
            return result;
        }

        private static char? MostCommon(int index, List<string> bits)
        {
            var countZero = 0;
            var countOne = 0;
            foreach (var item in bits)
            {
                switch (item[index])
                {
                    case '0':
                        countZero += 1;
                        break;
                    default:
                        countOne += 1;
                        break;
                }
            }

            return countOne == countZero ? null : countOne > countZero ? '1' : '0';
        }

        private static char? LeastCommon(int index, List<string> bits)
        {
            var count0 = 0;
            var count1 = 0;
            foreach (var item in bits)
            {
                switch (item[index])
                {
                    case '0':
                        count0 += 1;
                        break;
                    default:
                        count1 += 1;
                        break;
                }
            }
             return count1 == count0 ? null : count1 > count0 ? '0' : '1';
        }
    }
}
