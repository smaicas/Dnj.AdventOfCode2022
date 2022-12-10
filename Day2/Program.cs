// ReSharper disable ComplexConditionExpression

// Solution
using Day2;
Console.WriteLine("Advent of Code 2022 - Day 2");
Console.WriteLine(Environment.NewLine);
Solution resolver = new();
Console.WriteLine($"Total Part 1: {resolver.ResolvePart1()}");
Console.WriteLine($"Total Part 2: {resolver.ResolvePart2()}");
Console.ReadKey();

// Benchmark
//using BenchmarkDotNet.Running;
//using Day2;
//BenchmarkDotNet.Reports.Summary summary = BenchmarkRunner.Run<Solution>();
//Console.ForegroundColor = ConsoleColor.DarkCyan;
//Console.WriteLine("Benchmark ended!. Press any key to close");
//Console.ResetColor();
//Console.ReadKey();

//BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.1219/21H2)
//AMD Ryzen 9 3900X, 1 CPU, 24 logical and 12 physical cores
//    .NET SDK=7.0.100
//    [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
//DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2

//    |       Method |     Mean |   Error |  StdDev | Rank |    Gen0 |   Gen1 | Allocated |
//    |------------- |---------:|--------:|--------:|-----:|--------:|-------:|----------:|
//    | ResolvePart1 | 303.7 us | 5.80 us | 5.14 us |    1 | 53.2227 | 1.4648 | 437.48 KB |
//    | ResolvePart2 | 324.0 us | 4.08 us | 3.61 us |    2 | 45.8984 | 0.9766 | 378.89 KB |
