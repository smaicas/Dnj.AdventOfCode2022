using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Day1;

[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser]
public class Solution
{
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <exception cref="InvalidOperationException"><paramref name="source" /> contains no elements.</exception>
    [Benchmark]
    public int ResolvePart1()
    {
        List<int> list = ReadFileLines("input.txt");
        return list.Max();
    }

    /// <exception cref="OverflowException">The sum is larger than <see cref="System.Int32.MaxValue">Int32.MaxValue</see>.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    [Benchmark]
    public int ResolvePart2()
    {
        List<int> list = ReadFileLines("input.txt");
        list.Sort();
        return list.TakeLast(3).Sum();
    }

    static List<int> ReadFileLines(string filePath)
    {
        using StreamReader reader = new(filePath);
        int sum = 0;
        List<int> result = new();
        while (reader.ReadLine() is { } line)
        {
            if (Environment.NewLine.Equals(line) || string.Empty.Equals(line))
            {
                result.Add(sum);
                sum = 0;
            }
            else
            {
                sum += int.Parse(line);
            }
        }

        return result;
    }
}
