using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2015.Day1
{
    public class Day1: Day
    {
        public string Part_One()
        {
            var input = ReadInput(1);
            var floor = 0;
            foreach (var item in input)
            {
                if (item.Equals('('))
                {
                    floor++;
                }
                else
                    floor--;
            }
            return floor.ToString();
        }

        public string Part_Two()
        {
            return "";
        }

    }
}
