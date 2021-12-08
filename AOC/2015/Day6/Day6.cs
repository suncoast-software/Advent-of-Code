using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegExtract;

namespace AOC._2015.Day6
{
    public class Day6: Day
    {
        public int Part_One()
        {
            var _input = ReadInput(6);
            var test = _input.Extract<Instruction>(@"(toggle|turn on|turn off) ((\d+),(\d+)) through ((\d+),(\d+))");

            var lights = new int[1000,1000][];
            var count = 0;
            foreach  (var t in test)
            {
                int fromPosX = t.from.Item1;
                int fromPosY = t.from.Item2;

               switch (t.instr)
                {
                    case "turn on":
                        count++;
                        break;
                    case "toggle":
                        count++;
                        break;
                        default:
                        break;
                }
            }
            
            return count;
        }

        record Instruction(string instr, (int,int) from, (int,int) to);
        record Parts(string partOne, string partTwo);
    }
}
