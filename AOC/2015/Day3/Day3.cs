using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2015.Day3
{
    public class Day3: Day
    { 
        public int Part_One()
        {
            var input = ReadInput(3).ToArray();
            var visited = new HashSet<(int, int)>();
            var delivered = 1;
            int y = 0;
            int x = 0;

            foreach (var item in input[0])
            {    
                switch (item)
                {
                    case '>':
                        x += 1;
                        break;
                    case 'v':
                        y -= 1;
                        break;
                    case '<':
                        x -= 1;
                        break;
                    case '^':
                        y += 1;
                        break;
                    default:
                        break;  
                }

                visited.Add((x, y));
                delivered++;
   
            }
            return visited.Count();
        }
    }
}
