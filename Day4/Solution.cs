using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Day4;
[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser]
public class Solution
{
    /// <exception cref="OverflowException"><paramref name="s" /> represents a number less than <see cref="System.Int32.MinValue">Int32.MinValue</see> or greater than <see cref="System.Int32.MaxValue">Int32.MaxValue</see>.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="s" /> is <see langword="null" />.</exception>
    /// <exception cref="FormatException"><paramref name="s" /> is not in the correct format.</exception>
    /// <exception cref="OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string.</exception>
    /// <exception cref="IOException">An I/O error occurs.</exception>
    /// <exception cref="FileNotFoundException">The file cannot be found.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid, such as being on an unmapped drive.</exception>
    /// <exception cref="ArgumentException"><paramref name="path" /> is an empty string ("").</exception>
    [Benchmark]
    public int ResolvePart1()
    {
        IEnumerable<string> lines = ReadFileLines("input.txt");
        return lines.Count();

        static IEnumerable<string> ReadFileLines(string filePath)
        {
            using StreamReader reader = new(filePath);

            while (reader.ReadLine() is { } line)
            {
                if (FullContained(line))
                {
                    yield return line;
                }

            }
        }
        static bool FullContained(string s)
        {
            string[] split = s.Split(',');
            if (int.Parse(split[0].Split("-")[0]) >= int.Parse(split[1].Split("-")[0]) &&
                int.Parse(split[0].Split("-")[1]) <= int.Parse(split[1].Split("-")[1])) return true;

            if (int.Parse(split[1].Split("-")[0]) >= int.Parse(split[0].Split("-")[0]) &&
                int.Parse(split[1].Split("-")[1]) <= int.Parse(split[0].Split("-")[1])) return true;

            return false;
        }
    }

    /// <exception cref="OverflowException"><paramref name="s" /> represents a number less than <see cref="System.Int32.MinValue">Int32.MinValue</see> or greater than <see cref="System.Int32.MaxValue">Int32.MaxValue</see>.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="s" /> is <see langword="null" />.</exception>
    /// <exception cref="FormatException"><paramref name="s" /> is not in the correct format.</exception>
    /// <exception cref="OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string.</exception>
    /// <exception cref="IOException">An I/O error occurs.</exception>
    /// <exception cref="FileNotFoundException">The file cannot be found.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid, such as being on an unmapped drive.</exception>
    /// <exception cref="ArgumentException"><paramref name="path" /> is an empty string ("").</exception>
    [Benchmark]
    public int ResolvePart2()
    {
        IEnumerable<string> lines = ReadFileLines("input.txt");
        return lines.Count();

        static IEnumerable<string> ReadFileLines(string filePath)
        {
            using StreamReader reader = new(filePath);

            while (reader.ReadLine() is { } line)
            {
                if (HasOverlappeds(line))
                {
                    yield return line;
                }
            }
        }

        static bool HasOverlappeds(string s)
        {
            string[] split = s.Split(',');

            if (int.Parse(split[0].Split("-")[0]) > int.Parse(split[1].Split("-")[0]))
            {
                if (int.Parse(split[0].Split("-")[0]) <= int.Parse(split[1].Split("-")[1])) return true;
            }
            else
            {
                if (int.Parse(split[0].Split("-")[1]) >= int.Parse(split[1].Split("-")[0])) return true;
            }
            return false;
        }
    }
}
