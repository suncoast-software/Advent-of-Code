using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOC._2021.Extensions;

namespace AOC._2021.Day10
{
    public class Day10: Day
    {
        private string? _input;

        public async Task<int> Part_One()
        {
            _input = await GetInputForDayAsync(10);
            var lines = _input.ToLines();
            var sample = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]".ToLines();

            
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

        public async Task<long> Part_Two()
        {
            _input = await GetInputForDayAsync(10);
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
