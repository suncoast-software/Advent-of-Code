using AOC._2015.Day5;
using AOC._2021.Benchmarks.Day5;
//using AOC._2021.Day5;
using BenchmarkDotNet.Running;

//Day5_Benchmark benchmark = new();

//var results = BenchmarkRunner.Run<Day5_Benchmark>();

Day5 day = new();
var partOneResult = day.Part_One();
//var partTwoResult = await day.Solve_Part2(3);
//var partTwoResult = day.Part_Two();
Console.WriteLine(partOneResult);
//Console.WriteLine(partTwoResult);