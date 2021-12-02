using AOC._2021.Day2;
using BenchmarkDotNet.Running;

Console.WriteLine("Hello, Advent of Code 2021");

//Day1 benchmark = new Day1();

//var results = BenchmarkRunner.Run<Day1>();


Day2 day = new();
var partOneResult = await day.Solve(2);
//var partTwoResult = await day.Part_Two();
Console.WriteLine(partOneResult);
//Console.WriteLine(partTwoResult);