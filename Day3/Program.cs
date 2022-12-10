// Solution

using Day3;
Console.WriteLine("Advent of Code 2022 - Day 1");
Console.WriteLine(Environment.NewLine);
Solution resolver = new();
Console.WriteLine($"Part 1: {resolver.ResolvePart1()}");
Console.WriteLine($"Part 2: {resolver.ResolvePart2()}");
Console.ReadKey();

// Benchmark

//using BenchmarkDotNet.Running;
//using Day3;
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

//    |       Method |       Mean |    Error |   StdDev | Rank |     Gen0 |    Gen1 | Allocated |
//    |------------- |-----------:|---------:|---------:|-----:|---------:|--------:|----------:|
//    | ResolvePart1 |   925.5 us | 11.74 us |  9.16 us |    1 | 125.0000 | 14.6484 |      1 MB |
//    | ResolvePart2 | 1,055.5 us | 14.70 us | 20.13 us |    2 | 136.7188 | 17.5781 |    1.1 MB |