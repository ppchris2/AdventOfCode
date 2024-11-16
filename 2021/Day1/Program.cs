// See https://aka.ms/new-console-template for more information
var file = File.ReadAllLines("C:\\code\\AdventOfCode\\2021\\Day1\\input.txt").Select(x => Convert.ToInt16(x)).ToArray();
var count = 0;
foreach (var (i, line) in file.Index())
{
    if (i == 0)
    {
        continue;
    }

    if (line > file[i - 1])
    {
        count++;
    }
}
Console.WriteLine(count);

//part 2
var windowValue = 0;
count = 0;
var prevWindowValue = 0;
foreach (var (i, line) in file.Index())
{
    if (i <= 2)
    {
        continue;
    }
    windowValue = file[i - 2] + file[i - 1] + line;
    if (windowValue == 0)
    {
        continue;
    }

    if (windowValue > prevWindowValue)
    {
        count++;
    }
    prevWindowValue = windowValue;
}
Console.WriteLine(count);