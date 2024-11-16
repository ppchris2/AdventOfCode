
using System.Drawing;
using System.Text;

var file = File.ReadAllLines("C:\\code\\advent-of-code-2023\\Day11\\input.txt");


var test = new StringBuilder();

var expandedRows = new HashSet<int>();
var expandedColumns = new HashSet<int>();

foreach (var columnIndex in Enumerable.Range(0, file.Length))
{
    var column = file.Aggregate(new StringBuilder(), (seed, acc)  => seed.Append(acc[columnIndex])).ToString();

    if (!column.Contains('#'))
    {
        test.AppendLine(column);
        expandedColumns.Add(columnIndex);
        // test.AppendLine(column);
    }
    else
    {
        test.AppendLine(column);
    }
}

var flippedExpandedString = test.ToString().Split('\n').Where(x => x != string.Empty);
test.Clear();

foreach (var lineIndex in Enumerable.Range(0, file.Length))
{
    var column = flippedExpandedString.Aggregate(new StringBuilder(), (seed, acc)  => seed.Append(acc[lineIndex])).ToString();

    if (!column.Contains('#'))
    {
        test.AppendLine(column);
        expandedRows.Add(lineIndex);

        // test.AppendLine(column);
    }
    else
    {
        test.AppendLine(column);
    }
}





var expandedGalaxy = test.ToString();

var line = 0;
var position = 0;
var galaxies = new List<(int, Point)>();
var galaxyIndex = 0;
foreach (var galaxyLine in expandedGalaxy.Split('\n'))
{
    
    foreach (var pos in galaxyLine)
    {
        if (pos == '#')
        {
            galaxies.Add((++galaxyIndex, new Point(position, line)));
        }

        position++;
    }

    position = 0;
    line++;
}

var query = galaxies.SelectMany((value, index) => galaxies.Skip(index + 1),
    (first, second) => new {One = first, Two = second}).ToArray();

long dis = 0;
foreach (var t in query)
{
    var (x1, x2) = (t.One.Item2.X, t.Two.Item2.X);
    var (y1, y2) = (t.One.Item2.Y, t.Two.Item2.Y);

    dis += GetDistance2(x1, y1, x2, y2, expandedRows, expandedColumns);
}

;
// ....1........
// .........2...
// 3............
// .............
// .............
// ........4....
// .5...........
// .##.........6
// ..##.........
// ...##........
// ....##...7...
// 8....9.......


static double GetDistance(double x1, double y1, double x2, double y2)
{
    return Math.Abs(x2 - x1) + Math.Abs(y2 - y1); //Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
}


static long GetDistance2(int x1, int y1, int x2, int y2, HashSet<int> expandedRows, HashSet<int> expandedColumns)
{
    long addedDistance = 0;
    var touchedXAxis = Enumerable.Range(x1 < x2 ? x1 : x2, Math.Abs(x2 - x1));
    var touchedYAxis = Enumerable.Range(y1 < y2 ? y1 : y2, Math.Abs(y2 - y1));

    // if (touchedXAxis.Any(expandedColumns.Contains))
    // {
        addedDistance += touchedXAxis.Count(expandedColumns.Contains) * 999_999;
    // }
    // if (touchedYAxis.Any(expandedRows.Contains))
    // {
        addedDistance += touchedYAxis.Count(expandedRows.Contains)* 999_999;
    // }
    return Math.Abs(x2 - x1) + Math.Abs(y2 - y1) + addedDistance; 
}


