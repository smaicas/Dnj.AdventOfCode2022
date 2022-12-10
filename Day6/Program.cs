// Solution

using Day6;
Console.WriteLine("Advent of Code 2022 - Day 6");
Console.WriteLine(Environment.NewLine);
Solution resolver = new();
Console.WriteLine($"Part 1: {resolver.ResolvePart1()}");
Console.WriteLine($"Part 2 - 1: {resolver.ResolvePart2()}");
Console.WriteLine($"Part 2 - 2: {resolver.ResolvePart2WithSort()}");
Console.WriteLine($"Part 2 - 3: {resolver.ResolvePart2WithMaxASCII()}");
Console.ReadKey();

//Benchmark
//using BenchmarkDotNet.Running;
//using Day6;
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

//    |       Method |     Mean |    Error |   StdDev |   Median | Rank |     Gen0 |   Gen1 |  Allocated |
//    |------------- |---------:|---------:|---------:|---------:|-----:|---------:|-------:|-----------:|
//    | ResolvePart1 | 141.2 us |  2.53 us |  4.44 us | 139.4 us |    1 |  45.1660 | 2.4414 |   369.1 KB |
//    | ResolvePart2 | 693.4 us | 13.86 us | 35.53 us | 678.0 us |    2 | 156.2500 | 8.7891 | 1282.61 KB |