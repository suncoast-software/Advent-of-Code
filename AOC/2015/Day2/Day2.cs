using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2015.Day2
{
    public class Day2: Day
    {
        public string Part_One()
        {
            var input = ReadInput(2);
            var total = 0;
            var sides = new List<int>();
            for (int i = 0; i < input.Count(); i++)
            {
                sides.Clear();
                var items = input[i].Split(new char[] { 'x' });
                var lw = int.Parse(items[0]) * int.Parse(items[1]);
                var wh = int.Parse(items[1]) * int.Parse(items[2]);
                var hl = int.Parse(items[2]) * int.Parse(items[0]);
                sides.Add(lw);
                sides.Add(wh);
                sides.Add(hl);
                var smallest = sides.OrderBy(x => x);
                var sNum = smallest.ElementAt(0);
                var currentTotal = (lw * 2) + (wh * 2) + (hl * 2) + sNum;
                total += currentTotal;
                
            }
            return total.ToString();
        }

        public string Part_Two()
        {
            var input = ReadInput(2);
            var grandTotal = 0;
            var sides = new List<int>();
            for (int i = 0; i < input.Count(); i++)
            {
                sides.Clear();
                var items = input[i].Split(new char[] { 'x' });
                var length = int.Parse(items[0]);
                var width = int.Parse(items[1]);
                var height = int.Parse(items[2]);
                sides.Add(length);
                sides.Add(width);
                sides.Add(height);
                var sortedSides = sides.OrderBy(x => x);
                var shortest = sortedSides.ElementAt(0);
                int[] sumMe = new int[] { shortest, sortedSides.ElementAt(1), sortedSides.ElementAt(2) };
                var ribbonTotal = (shortest * 2) + (sumMe[1] * 2);
                var bowTotal = (int.Parse(items[0]) * int.Parse(items[1]) * height);
                var total = (bowTotal + ribbonTotal);
                grandTotal += total;
            }
            return grandTotal.ToString();
        }
    }
}
