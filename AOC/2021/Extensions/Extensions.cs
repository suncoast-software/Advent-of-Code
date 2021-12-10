using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Extensions
{
    public static class Extensions
    {
        public static string[] ToLines(this string input) => input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        public static List<int> AsInt32s(this string[] input) => input.Select(x => int.Parse(x)).ToList();
        public static List<int> AsInt32s(this char[] input) => input.Select(x => int.Parse(x.ToString())).ToList();

        public static int ToInt(this String str)
        {
            if (int.TryParse(str, out int result))
                return result;

            return 0;
        }

        public static int BinaryToDecimal(this StringBuilder value)
        {
            return Convert.ToInt32(value.ToString(), 2);
        }
    }
}
