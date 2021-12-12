using AOC._2021.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC._2021.Day4
{
    public class Day4: Day
    {
        private string _input;

        public async Task<int> Part_One(int day)
        {
            var sample = @"7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19

 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7";
            _input = await GetInputForDayAsync(day);
            var parts = sample.Split("\r\n").ToList();
            var nums = parts[0].Split(',').AsInt32s();
            var boards = parts.Skip(1).Select(x =>
            new BingoBoard
            {
                Rows = x.Split("\n").Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries).AsInt32s()).ToList(),
                ColMatchCount = new Dictionary<int, int>(),
                RowMatchCount = new Dictionary<int, int>(),
                Lookup = new Dictionary<int, (int row, int col)>(),
                Matches = new Dictionary<(int row, int col), bool>()
            }).ToList();
            
            int val;
            foreach (var board in boards)
            {
                for (int rowNum = 0; rowNum < board.Rows.Count; ++rowNum)
                {
                    var row = board.Rows[rowNum];
                    for (int colNum = 0; colNum < row.Count; ++colNum)
                    {
                        val = row[colNum];
                        board.Lookup.Add(val, (rowNum, colNum));
                        board.Matches[(rowNum, colNum)] = false;
                        if (rowNum == 0)
                            board.ColMatchCount[colNum] = 0;
                        if(colNum == 0)
                            board.RowMatchCount[colNum] = 0;
                    }
                }
                
            }
            bool bingo = false;
            for (int i = 0; i < nums.Count; ++i)
            {
                val = nums[i];
                foreach (var board in boards)
                {
                    if(board.Lookup.TryGetValue(val, out var index))
                    {
                        board.Matches[index] = true;
                        if (++board.RowMatchCount[index.row] == BingoBoard.rowCount)
                        {
                            //Bingo
                            Bingo(board, val);
                            bingo = true;
                        }
                        else if (++board.ColMatchCount[index.col] == BingoBoard.colCount)
                        {
                            //Bingo
                            Bingo(board, val);
                            bingo = true;
                        }
                        if (bingo) break;
                    }
                }
                if (bingo) break;
            }
            if (!bingo) Console.WriteLine("Didn't find Bingo!");
            return 0;
        }
        void Bingo(BingoBoard board, int trigger)
        {
            int sumUnmarked = 0;
            for (int rowNum = 0; rowNum < board.Rows.Count; ++rowNum)
            {
                var row = board.Rows[rowNum];
                for (int colNum = 0; colNum < row.Count; ++colNum)
                {
                    if (!board.Matches[(rowNum, colNum)]) 
                        sumUnmarked += row[colNum];
                }
            }
            Console.WriteLine($"{sumUnmarked * trigger}");
        }

        public async Task<int> Part_Two(int day)
        {
            var lines = _input.Split(new String[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            return 0;
        }

       
    }
}
