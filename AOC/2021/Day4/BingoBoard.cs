using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Day4
{
    public class BingoBoard
    {
        public const int colCount = 5;
        public const int rowCount = 5;
        public List<List<int>> Rows { get; set; }
        public Dictionary<(int row, int col), bool> Matches { get; set; }
        public Dictionary<int, int> RowMatchCount { get; set; }
        public Dictionary<int, int> ColMatchCount { get; set; }
        public Dictionary<int, (int row, int col)> Lookup { get; set; }
    }
}
