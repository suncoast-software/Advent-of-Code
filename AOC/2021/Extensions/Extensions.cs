using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Extensions
{
    public static class Extensions
    {
        public static int ToInt(this String str)
        {
            if (int.TryParse(str, out int result))
                return result;

            return 0;
        }
    }
}
