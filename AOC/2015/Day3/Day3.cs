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

        public int Part_Two()
        {
            var input = ReadInput(3).ToArray();
            var visited = new HashSet<(int, int)>();
            var santaPosX = 0;
            var santaPosY = 0;
            var roboSantaPosX = 0;
            var roboSantaPosY = 0;
            var count = 0;

            foreach (var item in input[0])
            { 
                switch (item)
                {
                    case '>':
                        if (count % 2 == 0)
                        {
                            santaPosX += 1;
                            count++;
                        }
                        else
                        {
                            roboSantaPosX += 1;
                            count++;
                        }

                        break;
                    case 'v':
                        if (count % 2 == 0)
                        {
                            santaPosY -= 1;
                            count++;
                        }
                        else
                        {
                            roboSantaPosY -= 1;
                            count++;
                        }

                        break;
                    case '<':
                        if (count % 2 == 0)
                        {
                            santaPosX -= 1;
                            count++;
                        }
                        else
                        {
                            roboSantaPosX -= 1;
                            count++;
                        }

                        break;
                    case '^':
                        if (count % 2 == 0)
                        {
                            santaPosY += 1;
                            count++;
                        }
                        else
                        {
                            roboSantaPosY += 1;
                            count++;
                        }

                        break;
                    default:
                        break;
                }
                visited.Add((santaPosX, santaPosY));
                visited.Add((roboSantaPosX, roboSantaPosY));
            }
            return visited.Count();
        }
    }
}
