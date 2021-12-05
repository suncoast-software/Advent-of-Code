using AOC._2021.Benchmarks.Day5;
using AOC._2021.Day5;
using BenchmarkDotNet.Running;

//Day5_Benchmark benchmark = new();

//var results = BenchmarkRunner.Run<Day5_Benchmark>();

Day5 day = new();
var partOneResult = await day.Solve_Part1(5);
//var partTwoResult = await day.Solve_Part2(3);
//var partTwoResult = await day.Part_Two();
Console.WriteLine(partOneResult);
//Console.WriteLine(partTwoResult);