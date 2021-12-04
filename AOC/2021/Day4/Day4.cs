using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Day4
{
    public class Day4: Day
    {
        private string? _input;

        public Day4()
        {
            Setup(4);
        }

        public int Solve_Part1()
        {
            var lines = _input.Split(new String[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
           
            return 0;
        }

        public int Solve_Part2()
        {
            var lines = _input.Split(new String[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            return 0;
        }

        public void Setup(int day)
        {
            Task.Run(async () =>
            {
                 _input = await GetInputForDay(day);
            });
        }

    }
}
