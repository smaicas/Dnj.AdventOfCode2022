// Solution

using Day4;
Console.WriteLine("Advent of Code 2022 - Day 4");
Console.WriteLine(Environment.NewLine);
Solution resolver = new();
Console.WriteLine($"Part 1: {resolver.ResolvePart1()}");
Console.WriteLine($"Part 2: {resolver.ResolvePart2()}");
Console.ReadKey();

// Benchmark
//using BenchmarkDotNet.Running;
//using Day4;
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

//    |       Method |     Mean |   Error |   StdDev |   Median | Rank |    Gen0 |   Gen1 | Allocated |
//    |------------- |---------:|--------:|---------:|---------:|-----:|--------:|-------:|----------:|
//    | ResolvePart2 | 358.7 us | 7.65 us | 22.43 us | 349.1 us |    1 | 67.8711 | 1.9531 | 554.57 KB |
//    | ResolvePart1 | 436.3 us | 8.56 us |  8.80 us | 432.2 us |    2 | 86.9141 | 2.4414 |  711.8 KB |