using AOC._2021.Benchmarks.Day3;
using AOC._2021.Day3;
using BenchmarkDotNet.Running;

//Day3_Benchmark benchmark = new();

//var results = BenchmarkRunner.Run<Day3_Benchmark>();


Day3 day = new();
var partOneResult = await day.Solve_Part1(3);
//var partTwoResult = await day.Solve_Part2(3);
//var partTwoResult = await day.Part_Two();
Console.WriteLine(partOneResult);
//Console.WriteLine(partTwoResult);