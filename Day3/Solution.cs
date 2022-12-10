using System.Text;
using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Day3;

[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser]
public class Solution
{
    /// <exception cref="RegexMatchTimeoutException">A time-out occurred. For more information about time-outs, see the Remarks section.</exception>
    /// <exception cref="ArgumentException">A regular expression parsing error occurred.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="input" /> or <paramref name="pattern" /> is <see langword="null" />.</exception>
    /// <exception cref="EncoderFallbackException">A fallback occurred (for more information, see Character Encoding in .NET)
    ///  -and-
    ///  <see cref="EncoderFallback" /> is set to <see cref="EncoderExceptionFallback" />.</exception>
    /// <exception cref="OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string.</exception>
    /// <exception cref="IOException">An I/O error occurs.</exception>
    /// <exception cref="FileNotFoundException">The file cannot be found.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid, such as being on an unmapped drive.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex" /> plus <paramref name="length" /> indicates a position not within this instance.
    ///  -or-
    ///  <paramref name="startIndex" /> or <paramref name="length" /> is less than zero.</exception>
    /// <exception cref="IndexOutOfRangeException"><paramref name="index" /> is greater than or equal to the length of this object or less than zero.</exception>
    [Benchmark]
    public int ResolvePart1()
    {
        const string data = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        IEnumerable<string> lines = ReadFileLines("input.txt");
        int total = 0;
        foreach (string line in lines)
        {
            int half = line.Length / 2;
            string part1 = line[..half];
            string part2 = line.Substring(half, half);
            string regex =
                @$"([{part1}])";
            Match match = Regex.Match(part2, regex);
            total += data.IndexOf(match.Value[0].ToString(), StringComparison.Ordinal) + 1;
        }
        return total;

        static IEnumerable<string> ReadFileLines(string filePath)
        {
            using StreamReader reader = new(filePath);

            while (reader.ReadLine() is { } line)
            {
                yield return line;
            }
        }
    }

    /// <exception cref="ArgumentOutOfRangeException">Enlarging the value of this instance would exceed <see cref="P:System.Text.StringBuilder.MaxCapacity" />.</exception>
    /// <exception cref="OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string.</exception>
    /// <exception cref="IOException">An I/O error occurs.</exception>
    /// <exception cref="RegexMatchTimeoutException">A time-out occurred. For more information about time-outs, see the Remarks section.</exception>
    /// <exception cref="ArgumentException">A regular expression parsing error occurred.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="values" /> is <see langword="null" />.</exception>
    /// <exception cref="IndexOutOfRangeException"><paramref name="index" /> is greater than or equal to the length of this object or less than zero.</exception>
    [Benchmark]
    public int ResolvePart2()
    {
        const string data = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        IEnumerable<string> lines = ReadFileLines("input.txt");
        int total = 0;
        foreach (string line in lines)
        {
            string[] split = line.Split(',');
            string regex =
                @$"([{split[0]}])";
            MatchCollection match = Regex.Matches(split[1], regex);
            regex = @$"([{string.Join("", match)}])";
            Match match2 = Regex.Match(split[2], regex);
            total += data.IndexOf(match2.Value[0].ToString(), StringComparison.Ordinal) + 1;
        }
        return total;

        static IEnumerable<string> ReadFileLines(string filePath)
        {
            using StreamReader reader = new(filePath);

            while (reader.ReadLine() is { } line)
            {
                StringBuilder sb = new();
                sb.Append(line);
                sb.Append(",");
                sb.Append(reader.ReadLine());
                sb.Append(",");
                sb.Append(reader.ReadLine());

                yield return sb.ToString();
            }
        }
    }
}
