//using AOC._2015.Day5;
//using AOC._2021.Benchmarks.Day5;
//using AOC._2015.Benchmark.Day5;
//using AOC._2015.Benchmarks.Day5;
using AOC._2021.Benchmarks.Day6;
using AOC._2021.Day6;
using BenchmarkDotNet.Running;
//using BenchmarkDotNet.Running;

Day6_Benchmark benchmark = new();
var results = BenchmarkRunner.Run<Day6_Benchmark>();


//Day6 day = new();
//var partOneResult = await day.Part_One();
//var partTwoResult = await day.Solve_Part2(3);
//var partTwoResult = day.Part_Two();
//Console.WriteLine(partOneResult);
//Console.WriteLine(partTwoResult);