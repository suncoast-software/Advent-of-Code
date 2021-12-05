using AOC._2015.Day3;
using AOC._2021.Benchmarks.Day5;
using AOC._2021.Day5;
using BenchmarkDotNet.Running;

//Day5_Benchmark benchmark = new();

//var results = BenchmarkRunner.Run<Day5_Benchmark>();

Day3 day = new();
var partOneResult = day.Part_One();
//var partTwoResult = await day.Solve_Part2(3);
//var partTwoResult = await day.Part_Two();
Console.WriteLine(partOneResult);
//Console.WriteLine(partTwoResult);