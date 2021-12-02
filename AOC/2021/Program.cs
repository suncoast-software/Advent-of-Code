using AOC._2021.Benchmarks.Day2;
using AOC._2021.Day2;
using BenchmarkDotNet.Running;

Day_Two_Benchmark benchmark = new();

var results = BenchmarkRunner.Run<Day_Two_Benchmark>();


//Day2 day = new();
//var partOneResult = await day.Solve(2);
//var partTwoResult = await day.Part_Two();
//Console.WriteLine(partOneResult);
//Console.WriteLine(partTwoResult);