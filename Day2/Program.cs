// ReSharper disable ComplexConditionExpression

//A - Piedra
//B - Papel
//C - Tijera

Console.WriteLine("Advent of Code 2022 - Day 2");
Console.WriteLine(Environment.NewLine);

// PART 1
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

Console.WriteLine($"Total Part 1: {total}");

// PART 2:
list = ReadFileLinesReplaceNumber("input.txt").ToList();
int total2 = 0;

foreach (string s in list)
{
    string[] split = s.Split(" ");
    int res = int.Parse(split[1]);
    total2 += res;

    switch (res)
    {
        case 0:
            total2 += split[0] switch
            {
                "A" => 3,
                "B" => 1,
                "C" => 2,
                _ => throw new ArgumentException("Bad parameters")
            };
            break;
        case 3:
            total2 += split[0] switch
            {
                "A" => 1,
                "B" => 2,
                "C" => 3,
                _ => throw new ArgumentException("Bad parameters")
            };
            break;
        case 6:
            total2 += split[0] switch
            {
                "A" => 2,
                "B" => 3,
                "C" => 1,
                _ => throw new ArgumentException("Bad parameters")
            };
            break;
    }
}
Console.WriteLine($"Total Part 2: {total2}");

static IEnumerable<string> ReadFileLinesWithReplace(string filePath)
{
    using StreamReader reader = new(filePath);

    while (reader.ReadLine() is { } line)
    {
        yield return line.Replace('X', 'A').Replace('Y', 'B').Replace('Z', 'C');
    }
}
static IEnumerable<string> ReadFileLinesReplaceNumber(string filePath)
{
    using StreamReader reader = new(filePath);

    while (reader.ReadLine() is { } line)
    {
        yield return line.Replace('X', '0').Replace('Y', '3').Replace('Z', '6');
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
