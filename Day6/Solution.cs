using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Day6;
[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser]
public class Solution
{
    /// <exception cref="FileNotFoundException">The file cannot be found.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid, such as being on an unmapped drive.</exception>
    /// <exception cref="IOException"><paramref name="path" /> includes an incorrect or invalid syntax for file name, directory name, or volume label.</exception>
    /// <exception cref="ArgumentException"><paramref name="path" /> is an empty string ("").</exception>
    /// <exception cref="ArgumentNullException"><paramref name="path" /> is <see langword="null" />.</exception>
    /// <exception cref="OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex" /> plus <paramref name="length" /> indicates a position not within this instance.
    ///  -or-
    ///  <paramref name="startIndex" /> or <paramref name="length" /> is less than zero.</exception>
    [Benchmark]
    public int ResolvePart1()
    {
        return ReadFileLines("input.txt");
        static int ReadFileLines(string filePath)
        {
            using StreamReader reader = new(filePath);
            string? line = reader.ReadLine();
            int result = 0;
            if (line == null) return result;
            for (int i = 0; i < line.Length - 3; i++)
            {
                string substring = line.Substring(i, 4);
                if (!HasDuplicatesWithHashSet(substring)) continue;
                result = i + 4;
                break;
            }

            return result;
        }
    }

    /// <exception cref="FileNotFoundException">The file cannot be found.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid, such as being on an unmapped drive.</exception>
    /// <exception cref="IOException"><paramref name="path" /> includes an incorrect or invalid syntax for file name, directory name, or volume label.</exception>
    /// <exception cref="ArgumentException"><paramref name="path" /> is an empty string ("").</exception>
    /// <exception cref="ArgumentNullException"><paramref name="path" /> is <see langword="null" />.</exception>
    /// <exception cref="OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string.</exception>
    [Benchmark]
    public int ResolvePart2()
    {
        return ReadFileLines("input.txt");
        static int ReadFileLines(string filePath)
        {
            using StreamReader reader = new(filePath);
            string? line = reader.ReadLine();
            int result = 0;
            if (line == null) return result;
            for (int i = 0; i < line.Length - 3; i++)
            {
                string substring = line.Substring(i, 14);
                if (!HasDuplicatesWithHashSet(substring)) continue;
                result = i + 14;
                break;
            }

            return result;
        }
    }

    /// <exception cref="FileNotFoundException">The file cannot be found.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid, such as being on an unmapped drive.</exception>
    /// <exception cref="IOException"><paramref name="path" /> includes an incorrect or invalid syntax for file name, directory name, or volume label.</exception>
    /// <exception cref="ArgumentException"><paramref name="path" /> is an empty string ("").</exception>
    /// <exception cref="OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string.</exception>
    [Benchmark]
    public int ResolvePart2WithSort()
    {
        return ReadFileLines("input.txt");
        static int ReadFileLines(string filePath)
        {
            using StreamReader reader = new(filePath);
            string? line = reader.ReadLine();
            int result = 0;
            if (line == null) return result;
            for (int i = 0; i < line.Length - 3; i++)
            {
                string substring = line.Substring(i, 14);
                if (!HasDuplicatesWithSorting(substring)) continue;
                result = i + 14;
                break;
            }

            return result;
        }
    }

    /// <exception cref="FileNotFoundException">The file cannot be found.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid, such as being on an unmapped drive.</exception>
    /// <exception cref="IOException"><paramref name="path" /> includes an incorrect or invalid syntax for file name, directory name, or volume label.</exception>
    /// <exception cref="ArgumentException"><paramref name="path" /> is an empty string ("").</exception>
    /// <exception cref="OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="path" /> is <see langword="null" />.</exception>
    [Benchmark]
    public int ResolvePart2WithMaxASCII()
    {
        return ReadFileLines("input.txt");
        static int ReadFileLines(string filePath)
        {
            using StreamReader reader = new(filePath);
            string? line = reader.ReadLine();
            int result = 0;
            if (line == null) return result;
            for (int i = 0; i < line.Length - 3; i++)
            {
                string substring = line.Substring(i, 14);
                if (!HasDuplicatesWithMaxLength(substring)) continue;
                result = i + 14;
                break;
            }

            return result;
        }
    }

    private static bool HasDuplicatesWithHashSet(string substring)
    {
        HashSet<char> charSet = new();

        foreach (char t in substring)
        {
            charSet.Add(t);
        }
        return charSet.Count == substring.Length;
    }

    private static bool HasDuplicatesWithSorting(string str)
    {
        char[] chArray = str.ToCharArray();

        // Using sorting
        Array.Sort(chArray);

        for (int i = 0; i < chArray.Length - 1; i++)
        {

            // if the adjacent elements are not
            // equal, move to next element
            if (chArray[i] != chArray[i + 1])
                continue;

            // if at any time, 2 adjacent elements
            // become equal, return false
            else
                return false;
        }

        return true;
    }
    private static bool HasDuplicatesWithMaxLength(String str)
    {
        const int MAX_CHAR = 256;

        // If length is greater than 256,
        // some characters must have been repeated
        if (str.Length > MAX_CHAR)
            return false;

        bool[] chars = new bool[MAX_CHAR];
        for (int i = 0; i < MAX_CHAR; i++)
        {
            chars[i] = false;
        }
        foreach (int index in str.Select(t => (int)t))
        {
            /* If the value is already true, string
            has duplicate characters, return false */
            if (chars[index] == true)
                return false;

            chars[index] = true;
        }

        /* No duplicates encountered, return true */
        return true;
    }

}
