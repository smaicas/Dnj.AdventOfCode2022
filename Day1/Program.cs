
// Solution

using Day1;

Console.WriteLine("Advent of Code 2022 - Day 1");
Console.WriteLine(Environment.NewLine);
Solution resolver = new();
Console.WriteLine($"Part 1: Max = {resolver.ResolvePart1()}");
Console.WriteLine($"Part 2: Sum 3 max = {resolver.ResolvePart2()}");
Console.ReadKey();

// Benchmark
//BenchmarkDotNet.Reports.Summary summary = BenchmarkRunner.Run<Solution>();
//Console.ForegroundColor = ConsoleColor.DarkCyan;
//Console.WriteLine("Benchmark ended!. Press any key to close");
//Console.ResetColor();
//Console.ReadKey();

// * Summary *
//BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.1219/21H2)
//AMD Ryzen 9 3900X, 1 CPU, 24 logical and 12 physical cores
//    .NET SDK=7.0.100
//    [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
//DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2

//    |       Method |     Mean |    Error |   StdDev |   Median | Rank |   Gen0 |   Gen1 | Allocated |
//    |------------- |---------:|---------:|---------:|---------:|-----:|-------:|-------:|----------:|
//    | ResolvePart1 | 88.21 us | 1.762 us | 4.013 us | 86.34 us |    1 | 9.0332 | 0.2441 |  74.44 KB |
//    | ResolvePart2 | 92.39 us | 1.848 us | 4.532 us | 91.24 us |    2 | 9.0332 | 0.2441 |  74.57 KB |
