using System.Text.RegularExpressions;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Day5;
[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser]
public class Solution
{
    /// <exception cref="IOException">An I/O error occurs.</exception>
    /// <exception cref="OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="key" /> is <see langword="null" />.</exception>
    /// <exception cref="OverflowException"><paramref name="s" /> represents a number less than <see cref="System.Int32.MinValue">Int32.MinValue</see> or greater than <see cref="System.Int32.MaxValue">Int32.MaxValue</see>.</exception>
    /// <exception cref="FormatException"><paramref name="s" /> is not in the correct format.</exception>
    /// <exception cref="ArgumentException">An element with the same key already exists in the <see cref="Dictionary`2" />.</exception>
    /// <exception cref="RegexMatchTimeoutException">A time-out occurred.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="i" /> is less than 0 or greater than or equal to <see cref="P:System.Text.RegularExpressions.MatchCollection.Count" />.</exception>
    [Benchmark]
    public string ResolvePart1()
    {
        return ReadFileLines("input.txt");

        static string ReadFileLines(string filePath)
        {
            Dictionary<int, Stack<char>> stacks = new(); // LIFO

            using StreamReader reader = new(filePath);
            string? line;
            while ((line = reader.ReadLine()) != string.Empty)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i].Equals('['))
                    {
                        if (stacks.ContainsKey(i / 4))
                        {
                            stacks[i / 4].Push(line[i + 1]);
                        }
                        else
                        {
                            Stack<char> stack = new();
                            stack.Push(line[i + 1]);
                            stacks[i / 4] = stack;
                        }
                    }
                }
            }

            Dictionary<int, Stack<char>> orderedStacks = stacks.ToDictionary(stack => stack.Key,
                stack => new Stack<char>(stack.Value));

            const string reg = @"(\d+)";
            while ((line = reader.ReadLine()) != null)
            {
                MatchCollection matches = Regex.Matches(line, reg);
                int move = int.Parse(matches[0].Value);
                int from = int.Parse(matches[1].Value);
                int to = int.Parse(matches[2].Value);

                for (int i = 1; i <= move; i++)
                {
                    orderedStacks[to - 1].Push(orderedStacks[from - 1].Pop());
                }
            }

            return string.Join("", orderedStacks.OrderBy(x => x.Key).Select(x => x.Value.Pop()));
        }
    }

    /// <exception cref="FileNotFoundException">The file cannot be found.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid, such as being on an unmapped drive.</exception>
    /// <exception cref="IOException"><paramref name="path" /> includes an incorrect or invalid syntax for file name, directory name, or volume label.</exception>
    /// <exception cref="ArgumentException"><paramref name="path" /> is an empty string ("").</exception>
    /// <exception cref="ArgumentNullException"><paramref name="path" /> is <see langword="null" />.</exception>
    /// <exception cref="OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string.</exception>
    /// <exception cref="IndexOutOfRangeException"><paramref name="index" /> is greater than or equal to the length of this object or less than zero.</exception>
    /// <exception cref="OverflowException"><paramref name="s" /> represents a number less than <see cref="System.Int32.MinValue">Int32.MinValue</see> or greater than <see cref="System.Int32.MaxValue">Int32.MaxValue</see>.</exception>
    /// <exception cref="FormatException"><paramref name="s" /> is not in the correct format.</exception>
    /// <exception cref="RegexMatchTimeoutException">A time-out occurred.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="i" /> is less than 0 or greater than or equal to <see cref="P:System.Text.RegularExpressions.MatchCollection.Count" />.</exception>
    /// <exception cref="InvalidOperationException">The <see cref="Stack`1" /> is empty.</exception>
    [Benchmark]
    public string ResolvePart2()
    {
        return ReadFileLines("input.txt");

        static string ReadFileLines(string filePath)
        {
            Dictionary<int, Stack<char>> stacks = new(); // LIFO

            using StreamReader reader = new(filePath);
            string? line;
            while ((line = reader.ReadLine()) != string.Empty)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (!line[i].Equals('[')) continue;
                    if (stacks.ContainsKey(i / 4))
                    {
                        stacks[i / 4].Push(line[i + 1]);
                    }
                    else
                    {
                        Stack<char> stack = new();
                        stack.Push(line[i + 1]);
                        stacks[i / 4] = stack;
                    }
                }
            }

            Dictionary<int, Stack<char>> orderedStacks = new();
            foreach (KeyValuePair<int, Stack<char>> stack in stacks)
            {
                orderedStacks.Add(stack.Key, new Stack<char>(stack.Value));
            }

            const string reg = @"(\d+)";
            while ((line = reader.ReadLine()) != null)
            {
                MatchCollection matches = Regex.Matches(line, reg);
                int move = int.Parse(matches[0].Value);
                int from = int.Parse(matches[1].Value);
                int to = int.Parse(matches[2].Value);

                char[] arr = new char[move];
                for (int i = 0; i < move; i++)
                {
                    arr[i] = orderedStacks[from - 1].Pop();
                }

                foreach (char c in arr.Reverse())
                {
                    orderedStacks[to - 1].Push(c);
                }
            }

            return string.Join("", orderedStacks.OrderBy(x => x.Key).Select(x => x.Value.Pop()));
        }
    }
}
