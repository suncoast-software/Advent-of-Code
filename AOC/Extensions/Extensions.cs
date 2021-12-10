using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC.Extensions
{
    public static class Extensions
    {
        public static string[] ToLines(this string input) => input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries); 
        public static List<int> AsInt32s(this string[] input) => input.Select(x => int.Parse(x)).ToList();
        public static List<int> AsInt32s(this char[] input) => input.Select(x => int.Parse(x.ToString())).ToList();
    }
}
