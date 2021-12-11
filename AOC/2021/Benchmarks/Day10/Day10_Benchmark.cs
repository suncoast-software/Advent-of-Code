using AOC._2021.Extensions;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Benchmarks.Day10
{
    [MemoryDiagnoser]
    public class Day10_Benchmark: Day
    {
        [Benchmark]
        public int Part_One()
        {
            string? _input = GetInputForDay(10);
            var lines = _input.ToLines();

            var score = 0;

            foreach (var line in lines)
            {
                var cStack = new Stack<char>();
                foreach (var c in line.ToCharArray())
                {
                    if (c is '(' or '{' or '[' or '<')
                    {
                        cStack.Push(c);
                        continue;
                    }
                    cStack.TryPop(out var last);
                    score += c switch
                    {
                        ')' when last != '(' => 3,
                        ']' when last != '[' => 57,
                        '}' when last != '{' => 1197,
                        '>' when last != '<' => 25137,
                        _ => 0
                    };
                }
            }
            return score;
        }

        [Benchmark]
        public long Part_Two()
        {
            string? _input = GetInputForDay(10);
            var lines = _input.ToLines();
            var points = new List<long>();
            foreach (var line in lines)
            {
                var openBracketOrder = new Stack<char>();
                var invalid = false;

                foreach (var c in line)
                {
                    if (c is '(' or '[' or '{' or '<')
                    {
                        openBracketOrder.Push(c);
                        continue;
                    }

                    openBracketOrder.TryPop(out var last);
                    switch (c)
                    {
                        case ')' when last != '(':
                        case ']' when last != '[':
                        case '}' when last != '{':
                        case '>' when last != '<':
                            invalid = true;
                            break;
                    }

                    if (invalid) break;
                }
                if (invalid) continue;

                var score = 0L;
                foreach (var toClose in openBracketOrder)
                {
                    score *= 5;
                    score += toClose switch
                    {
                        '(' => 1,
                        '[' => 2,
                        '{' => 3,
                        '<' => 4,
                        _ => 0
                    };
                }

                points.Add(score);
            }

            var result = points.ToArray();
            Array.Sort(result);

            return result[result.Length / 2];
        }
    }
}
