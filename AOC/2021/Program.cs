using AOC._2015.Day6;
using AOC._2021.Benchmarks.Day8;
using AOC._2021.Day8;
using AOC._2021.Day9;
using BenchmarkDotNet.Running;

//Day8_Benchmark benchmark = new();
//var results = BenchmarkRunner.Run<Day8_Benchmark>();

//Day8 day = new();
//var result = await day.Part_One();
//Console.WriteLine(result);
Day9 day = new();
var partOneResult = await day.Part_One();
//var partTwoResult = await day.Part_Two();
//var partTwoResult = await day.Part_Two();
Console.WriteLine(partOneResult);
//Console.WriteLine(partTwoResult);