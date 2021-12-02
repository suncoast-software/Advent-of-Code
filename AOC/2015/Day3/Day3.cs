using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2015.Day3
{
    public class Day3: Day
    { 
        public int Part_One()
        {
            var input = ReadInput(3);
            var visited = new List<char>();
            var delivered = 1;
            foreach (var item in input[0])
            {
                if (!visited.Contains(item))
                {
                    visited.Add(item);
                    int test = item switch
                    {
                        '^' => delivered++,
                        'V' => delivered--,
                        '>' => delivered++,
                        '<' => delivered--,
                        _ => 0
                    };
                }
                else
                {
                    
                }
                
            }
            return delivered;
        }
    }
}
