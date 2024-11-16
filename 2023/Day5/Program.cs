using System.Collections;
using System.Collections.Concurrent;

var lines = File.ReadAllLines("C:\\Users\\ppchr\\Source\\Repos\\advent-of-code-2023\\Day5\\input.txt");

var previousLineCount = 0;
var seedToSoil = Array.Empty<Map>();
var soiToFertilizer = Array.Empty<Map>();
var fertilizerToWater =  Array.Empty<Map>();
var waterToLight =  Array.Empty<Map>();
var lightToTempruture =  Array.Empty<Map>();
var tempToHumidity =  Array.Empty<Map>();
var humToLocation =  Array.Empty<Map>();

while (previousLineCount + 1 != lines.Length)
{
    var lineBre = lines.Skip(previousLineCount + 2).TakeWhile(x => x != String.Empty).ToArray();
    previousLineCount += lineBre.Length + 1;

    var activeMapping = lineBre
        .Skip(1)
        .Select(line => line
            .Split(' ')
            .Select(long.Parse)
            .ToArray())
        .Select(split => new Map(split[0], split[1], split[2]))
        .ToArray();
    
    if (lineBre.Any(x => x.Contains("seed-to-soil")))
    { 
        seedToSoil = activeMapping;
    }
    else if (lineBre.Any(x => x.Contains("soil-to-fertilizer")))
    {
        soiToFertilizer = activeMapping; 
    }
    else if (lineBre.Any(x => x.Contains("fertilizer-to-water")))
    {
        fertilizerToWater = activeMapping; 
    }
    else if (lineBre.Any(x => x.Contains("water-to-light")))
    {
        waterToLight = activeMapping; 
    }
    else if (lineBre.Any(x => x.Contains("light-to-temperature")))
    {
        lightToTempruture =activeMapping; 
    }
    else if (lineBre.Any(x => x.Contains("temperature-to-humidity")))
    {
        tempToHumidity = activeMapping; 
    }
    else if (lineBre.Any(x => x.Contains("humidity-to-location")))
    {
        humToLocation = activeMapping; 
    }
    
}

var list = new ConcurrentBag<long>();
var i = 0;

Parallel.ForEach(lines[0].Split(' ').Where(x => x.All(char.IsDigit)).Select(long.Parse).Chunk(2).ToArray(), 
    new ParallelOptions { MaxDegreeOfParallelism = 10 },
    
    seedRange =>
    {
        var t = Enumerable.Range(seedRange[0], seedRange[1]);
        var lowest = long.MaxValue;

        Console.WriteLine($"Searching seed range");

        foreach (var seed in t)
        {
            
            var soil = Get(seedToSoil, seed);
            var fert = Get(soiToFertilizer,soil);
            var water = Get(fertilizerToWater,fert);
            var light = Get(waterToLight, water);
            var temp = Get(lightToTempruture, light);
            var hum = Get(tempToHumidity, temp);
            var loc = Get(humToLocation, hum);

            if (loc < lowest)
            {
                lowest = loc;
                //insideList.Add(loc);
            }
        }
        Console.WriteLine($"Found seed for range {i++}");
        //prev 39477886
        list.Add(lowest);
    });

Console.WriteLine("min "  + list.Min());

long Get(Map[] maps, long i)
{
    foreach (var map in maps)
    {
        if (map.Contains(i))
        {
            return map[i];
        }
    }

    return i;
}

struct Map
{
    public long Destination { get; set; }
    public long Source { get; set; }
    public long Range { get; set; }

    private long RangeOfSource => Source + Range;
    public Map(long destination, long source, long range)
    {
        Destination = destination;
        Source = source;
        Range = range;
    }

    public bool Contains(long i)
    {
        return RangeOfSource > i && Source <= i;
    }
    public long this[long i]
    {
        get
        {
            var stepsNeeded = i - Source;
            var dest = Destination + stepsNeeded;
            return dest;
        }
    }
}

public static class Enumerable {
    public static IEnumerable<long> Range(long start, long count) {
        var end = start + count;
        for(var current = start; current < end; ++current) {
            yield return current;
        }
    }
}







