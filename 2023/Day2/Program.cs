
// only 12 red cubes, 13 green cubes, and 14 blue cubes

var lines = File.ReadAllLines("C:\\repos\\AdventOfCode\\2023\\Day2\\input.txt");
// Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green

var sum = 0;
var power = 0;
foreach (var line in lines)
{

    var t = line.Split(':');
    var gameId = int.Parse(t[0].Where(char.IsDigit).ToArray());

    var games = t[1].Split(';');
    var gameIsPossible = true;

    var minimumRed = 0;
    var minimumGreen = 0;
    var minimumBlue = 0;

    foreach (var game in games)
    {
        var round = game.Split(',');
        var red = int.Parse(round.FirstOrDefault(x => x.Contains("red"))?.Where(char.IsDigit).ToArray() ?? new[] { '0' });
        var blue = int.Parse(round.FirstOrDefault(x => x.Contains("blue"))?.Where(char.IsDigit).ToArray() ?? new[] { '0' });
        var green = int.Parse(round.FirstOrDefault(x => x.Contains("green"))?.Where(char.IsDigit).ToArray() ?? new[] { '0' });
        if (red > 12 || green > 13 || blue > 14)
        {
            gameIsPossible = false;
        }

        //part 2
        if (red > minimumRed)
        {
            minimumRed = red;
        }

        if (green > minimumGreen)
        {
            minimumGreen = green;
        }

        if (blue > minimumBlue)
        {
            minimumBlue = blue;
        }

    }
    if (gameIsPossible)
    {
        sum += gameId;
    }

    power += minimumBlue * minimumRed * minimumGreen;
}
Console.WriteLine(sum);
Console.WriteLine(power);
