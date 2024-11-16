
// Time:      7  15   30
// Distance:  9  40  200

var example = new[] {new Race(7, 9), new Race(15, 40), new Race(30, 200)};
var input = new[] {new Race(41, 214), new Race(96, 1789), new Race(88, 1127), new Race(94, 1055)};
var inputPart2 = new[] {new Race2(41968894, 214178911271055)};
var possibleWaysToWin = new List<int>();

foreach (var line in inputPart2)
{

    var possibleButtonHoldingTimes = Enumerable.Range(1, line.Time - 1);

    var count = 0;
    foreach (var time in possibleButtonHoldingTimes)
    {
        var speed = time;
        var timeToMove = line.Time - time;

        var distanceTraveled = speed * timeToMove;
        if (distanceTraveled > line.Distance)
        {
            ++count;
        }
        
    }
    possibleWaysToWin.Add(count);
    ;
}

var t = possibleWaysToWin.Aggregate(1, (x, seed) => seed *= x);

Console.WriteLine(t);
struct Race(int time, int distance)
{
    public int Time { get; set; } = time;
    public int Distance { get; set; } = distance;
}

struct Race2(long time, long distance)
{
    public long Time { get; set; } = time;
    public long Distance { get; set; } = distance;
}

public static class Enumerable {
    public static IEnumerable<long> Range(long start, long count) {
        var end = start + count;
        for(var current = start; current < end; ++current) {
            yield return current;
        }
    }
}