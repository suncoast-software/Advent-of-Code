using AOC._2021.Benchmarks.Day2;
using AOC._2021.Day3;
using BenchmarkDotNet.Running;

//Day_Two_Benchmark benchmark = new();

//var results = BenchmarkRunner.Run<Day_Two_Benchmark>();


Day3 day = new();
//var partOneResult = await day.Solve_Part1(3);
var partTwoResult = await day.Solve_Part2(3);
//var partTwoResult = await day.Part_Two();
//Console.WriteLine(partOneResult);
Console.WriteLine(partTwoResult);