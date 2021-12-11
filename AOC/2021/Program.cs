using AOC._2021.Benchmarks.Day11;
using BenchmarkDotNet.Running;

Day11_Benchmark benchmark = new();
var results = BenchmarkRunner.Run<Day11_Benchmark>();

//Day11 day = new();
//var result = await day.Part_One();
//Console.WriteLine(result);
//Day10 day = new();
//var partOneResult = await day.Part_One();
//var partTwoResult = await day.Part_Two();
//var partTwoResult = await day.Part_Two();
//Console.WriteLine(partOneResult);
//Console.WriteLine(partTwoResult);