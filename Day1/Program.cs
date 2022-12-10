Console.WriteLine("Advent of Code 2022 - Day 1");
Console.WriteLine(Environment.NewLine);

List<int> list = ReadFileLines("input.txt");
// PART 1
int max = list.Max();

// PART 2
list.Sort();

int result = list.TakeLast(3).Sum();

Console.WriteLine($"Part 1: Max = {max}");
Console.WriteLine($"Part 2: Sum 3 max = {result}");

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

