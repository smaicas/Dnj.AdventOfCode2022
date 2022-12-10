// Solution

using Day5;
Console.WriteLine("Advent of Code 2022 - Day 5");
Console.WriteLine(Environment.NewLine);
Solution resolver = new();
Console.WriteLine($"Part 1: {resolver.ResolvePart1()}");
Console.WriteLine($"Part 2: {resolver.ResolvePart2()}");
Console.ReadKey();

// Benchmark
//using BenchmarkDotNet.Running;
//using Day5;
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

//    |       Method |     Mean |   Error |   StdDev | Rank |    Gen0 |   Gen1 | Allocated |
//    |------------- |---------:|--------:|---------:|-----:|--------:|-------:|----------:|
//    | ResolvePart1 | 419.4 us | 6.40 us |  5.34 us |    1 | 63.4766 | 2.4414 | 520.64 KB |
//    | ResolvePart2 | 481.6 us | 9.24 us | 13.54 us |    2 | 70.8008 | 2.9297 | 581.33 KB |