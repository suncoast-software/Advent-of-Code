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
            var commands = _input.Extract<Instruction>(@"(toggle|turn on|turn off) ((\d+),(\d+)) through ((\d+),(\d+))");

            var lights = new int[1000, 1000];

            foreach  (var command in commands)
            { 
                for (int x = command.from.Item1; x <= command.to.Item1; x++)
                {
                    for (int y = command.from.Item2; y <= command.to.Item2; y++)
                    {
                        var indexY = y;
                        var indexX = x;
                        switch (command.instr)
                        {
                            case "turn on":
                                lights[indexX, indexY] = 1;
                                break;
                            case "toggle":
                                lights[indexX, indexY] = lights[indexX, indexY] == 0 ? 1 : 0;
                                break;
                            case "turn off":
                                lights[indexX, indexY] = 0;
                                break;

                                default:
                                break;
                        }
                    }
                }

            }
            var count = 0;
            var l = lights.Length;
            for (int i = 0; i <= lights.Length - 1; i++)
            {
                for (int y = 0; y <= lights.Length - 1; y++)
                {
                    if (lights[i, y] == 1)
                        count++;
                }
            }
            
            return count;
        }

        record Instruction(string instr, (int,int) from, (int,int) to);
        record Parts(string partOne, string partTwo);
    }
}
