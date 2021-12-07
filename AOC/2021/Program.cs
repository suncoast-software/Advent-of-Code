//using AOC._2015.Day5;
//using AOC._2021.Benchmarks.Day5;
//using AOC._2015.Benchmark.Day5;
//using AOC._2015.Benchmarks.Day5;
using AOC._2015.Day5;
using AOC._2021.Benchmarks.Day6;
using AOC._2021.Benchmarks.Day7;
using AOC._2021.Day6;
using AOC._2021.Day7;
using BenchmarkDotNet.Running;
//using BenchmarkDotNet.Running;

//Day7_Benchmark benchmark = new();
//var results = BenchmarkRunner.Run<Day7_Benchmark>();

Day5 day = new();
//var result = day.Part_Two();
//Console.WriteLine(result);
//Day7 day = new();
var partOneResult = day.Part_Two();
//var partTwoResult = await day.Part_Two();
//var partTwoResult = day.Part_Two();
Console.WriteLine(partOneResult);
//Console.WriteLine(partTwoResult);