using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Day4
{
    public class Day4: Day
    {
        private string _input;

        public async Task<int> Solve_Part1(int day)
        {
            _input = await GetInputForDayAsync(day);
            var lines = _input.Split(new String[] { "\r", "\n", " " }, StringSplitOptions.RemoveEmptyEntries);
            var nums = lines[0].Split(',').Select(int.Parse).ToList();
            var rawBoards = lines.Skip(1).Select((x, i) => (x, i)).GroupBy(x => x.i / 25);
            var matchCount = 0;
            var picked = new List<int>();
            var unMarked = new List<int>();
            foreach (var num in nums)
            {
                foreach (var board in rawBoards)
                {
                    unMarked.Clear();
                    for (int i = 0; i < board.Count(); i++)
                    {
                        var currentNum = int.Parse(board.ElementAt(i).x);
                        if (currentNum == num)
                        {
                            
                            matchCount++;
                            if (matchCount == 5)
                            {
                                var boardSum = unMarked.Sum();
                                var lastPicked = num;
                                Console.WriteLine("Winner");
                                Console.WriteLine($"{lastPicked}");
                                Console.WriteLine($"{ boardSum * lastPicked}");
                            }
                           
                        }
                        else
                        {
                            unMarked.Add(currentNum);
                        }
                        
                    }
                    picked.Add(num);
                }

            }
            Console.WriteLine($"{matchCount}");
            return 0;
        }

        public int Solve_Part2()
        {
            var lines = _input.Split(new String[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            return 0;
        }

       
    }
}
