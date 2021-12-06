using BenchmarkDotNet.Attributes;

namespace AOC._2021.Benchmarks.Day2
{
    [MemoryDiagnoser]
    public class Day_Two_Benchmark: Day
    {
        private string? _input;

        public Day_Two_Benchmark()
        {
            Setup();  
        }

        [Benchmark]
        public int Solve()
        {
           
            var lines = _input?.Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
            var subDepth = 0;
            var position = 0;
            var aim = 0;
            foreach (var line in lines)
            {
                var command = line.Split(" ")[0];
                var amount = line.Split(" ")[1];

                switch (command)
                {
                    case "down":
                        aim += int.Parse(amount);
                        break;

                    case "up":
                        aim -= int.Parse(amount);
                        break;

                    case "forward":
                        position += int.Parse(amount);
                        subDepth += aim * int.Parse(amount);
                        break;

                    default:
                        break;
                }
            }
            return subDepth * position;
        }

         [GlobalSetup]
        private void Setup()
        {
            Task.Run(async () =>
             {
                 _input = await GetInputForDayAsync(2);

             });
            
        }
    }
   
    
}
