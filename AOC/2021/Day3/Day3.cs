using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Day3
{
    public class Day3: Day
    {
        private string _input;

        public Day3()
        {
            Setup(3);
        }

        public async Task<int> Solve()
        {
           
            var lines = _input.Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

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
