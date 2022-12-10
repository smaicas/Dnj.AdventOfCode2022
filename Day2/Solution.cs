using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
// ReSharper disable MethodTooLong
// ReSharper disable ComplexConditionExpression

namespace Day2;

[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser]
public class Solution
{
    /// <exception cref="ArgumentException">Bad parameters</exception>
    /// <exception cref="OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string.</exception>
    /// <exception cref="IOException">An I/O error occurs.</exception>
    /// <exception cref="FileNotFoundException">The file cannot be found.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid, such as being on an unmapped drive.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="path" /> is <see langword="null" />.</exception>
    [Benchmark]
    public int ResolvePart1()
    {
        IEnumerable<string> list = ReadFileLinesWithReplace("input.txt");
        int total = 0;
        foreach (string game in list)
        {
            string[] split = game.Split(' ');

            total = split[1] switch
            {
                "A" => total + 1,
                "B" => total + 2,
                "C" => total + 3,
                _ => throw new ArgumentException("Bad parameters")
            };

            RockPaperScissorsComparer comparer = new();

            total = comparer.Compare(split[0], split[1]) switch
            {
                0 => total + 3,
                1 => total + 0,
                -1 => total + 6,
                _ => throw new ArgumentException("Bad parameters")
            };

        }

        return total;

        static IEnumerable<string> ReadFileLinesWithReplace(string filePath)
        {
            using StreamReader reader = new(filePath);

            while (reader.ReadLine() is { } line)
            {
                if (line.Contains('X')) yield return line.Replace('X', 'A');
                else if (line.Contains('Y')) yield return line.Replace('Y', 'B');
                else if (line.Contains('Z')) yield return line.Replace('Z', 'C');
            }
        }
    }

    /// <exception cref="OverflowException"><paramref name="s" /> represents a number less than <see cref="System.Int32.MinValue">Int32.MinValue</see> or greater than <see cref="System.Int32.MaxValue">Int32.MaxValue</see>.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="s" /> is <see langword="null" />.</exception>
    /// <exception cref="FormatException"><paramref name="s" /> is not in the correct format.</exception>
    /// <exception cref="ArgumentException">Bad parameters</exception>
    /// <exception cref="FileNotFoundException">The file cannot be found.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid, such as being on an unmapped drive.</exception>
    /// <exception cref="IOException"><paramref name="path" /> includes an incorrect or invalid syntax for file name, directory name, or volume label.</exception>
    /// <exception cref="OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string.</exception>
    [Benchmark]
    public int ResolvePart2()
    {
        IEnumerable<string> list = ReadFileLinesReplaceNumber("input.txt");
        int total = 0;

        foreach (string s in list)
        {
            string[] split = s.Split(" ");
            int res = int.Parse(split[1]);
            total += res;

            switch (res)
            {
                case 0:
                    total += split[0] switch
                    {
                        "A" => 3,
                        "B" => 1,
                        "C" => 2,
                        _ => throw new ArgumentException("Bad parameters")
                    };
                    break;
                case 3:
                    total += split[0] switch
                    {
                        "A" => 1,
                        "B" => 2,
                        "C" => 3,
                        _ => throw new ArgumentException("Bad parameters")
                    };
                    break;
                case 6:
                    total += split[0] switch
                    {
                        "A" => 2,
                        "B" => 3,
                        "C" => 1,
                        _ => throw new ArgumentException("Bad parameters")
                    };
                    break;
            }
        }

        return total;

        static IEnumerable<string> ReadFileLinesReplaceNumber(string filePath)
        {
            using StreamReader reader = new(filePath);

            while (reader.ReadLine() is { } line)
            {
                if (line.Contains('X')) yield return line.Replace('X', '0');
                else if (line.Contains('Y')) yield return line.Replace('Y', '3');
                else if (line.Contains('Z')) yield return line.Replace('Z', '6');
            }
        }
    }
}
public class RockPaperScissorsComparer : IComparer<string>
{
    /// <exception cref="ArgumentException">Bad parameters</exception>
    public int Compare(string? x, string? y)
    {
        if (x == null || y == null) throw new ArgumentException("Somebody did not choose");

        if (x.Equals(y)) return 0;

        switch (x)
        {
            case "A" when y.Equals("B"):
                return -1;
            case "A" when y.Equals("C"):

            case "B" when y.Equals("A"):
                return 1;
            case "B" when y.Equals("C"):
                return -1;

            case "C" when y.Equals("B"):
                return 1;
            case "C" when y.Equals("A"):
                return -1;

            default:
                throw new ArgumentException("Bad parameters");
        }
    }
}
