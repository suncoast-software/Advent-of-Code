using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Day8
{
    public class Day8: Day
    {
        private string? _input;
		public async Task<int> Part_One()
        {
            _input = await GetInputForDayAsync(8);

            var lines = _input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var count = 0;

            foreach (var line in lines)
            {
                var outputs = line.Trim().Split(" | ")[1].Split(' ');

                foreach (var output in outputs)
                {
                    if (output.Length is 2 or 3 or 4 or 7)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public async Task<int> Part_Two()
        {
            _input = await GetInputForDayAsync(8);
            var lines = _input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var stdPattern = "abcefg cf acdeg acdfg bdcf abdfg abdefg acf abcdefg abcdfg";
            var stdPatternSplit = stdPattern.Split(' ');

            var parsed = new string[lines.Length][];
            for (var i = 0; i < lines.Length; i++)
            {
                parsed[i] = lines[i].Split("|");
            }

            var dict = new Dictionary<string, int>();
            for (var i = 0; i < stdPatternSplit.Length; i++)
            {
                dict[FindPattern(stdPatternSplit[i], CountCharacters(stdPattern))] = i;
            }

            var total = 0;
            for (var i = 0; i < parsed.Length; i++)
            {
                var results = parsed[i][1].Trim().Split(" ");
                var count = CountCharacters(parsed[i][0]);
                var resolved = new int[results.Length];

                for (var s = 0; s < results.Length; s++)
                {
                    var pattern = FindPattern(results[s], count);
                    resolved[s] = dict[pattern];
                }

                total += int.Parse(string.Join("", resolved));
            }

            return total;

        }

        private Dictionary<char, int> CountCharacters(string line)
        {
            var counts = new Dictionary<char, int>();
            line = line.Replace(" ", "");
            for (var c = 0; c < line.Length; c++)
            {
                if (!counts.ContainsKey(line[c]))
                    counts.Add(line[c], 0);

                counts[line[c]]++;
            }

            return counts;
        }

        private string FindPattern(string segments, Dictionary<char, int> count)
        {
            var pattern = new int[segments.Length];
            for (var c = 0; c < segments.Length; c++)
            {
                pattern[c] = count[segments[c]];
            }
            Array.Sort(pattern);

            return string.Join("", pattern);
        }
    }
}
