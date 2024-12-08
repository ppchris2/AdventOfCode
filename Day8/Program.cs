// See https://aka.ms/new-console-template for more information

using System.Drawing;
using System.Numerics;

var example = @"............
........0...
.....0......
.......0....
....0.......
......A.....
............
............
........A...
.........A..
............
............";

var input = File.ReadAllText("C:\\code\\AdventOfCode\\Day8\\input.txt");
var test = new Matrix(input);

test.Test();

Console.WriteLine(test.Draw());


class Matrix
{
    private Dictionary<char, List<Point>> _points = new(){{'#', []}};
    private int maxX = 0;
    private int maxY = 0;
    
    public Matrix(string input)
    {
        var split = input.Split(Environment.NewLine);
        int index;
        int i = 0;
        for ( index = 0; index < split.Length; index++)
        {
            var line = split[index];
            for ( i = 0; i < line.Length; i++)
            {
                var cha = line[i];
                if (cha == '.')
                {
                    continue;
                }
                if (!_points.TryGetValue(cha, out var value))
                {
                    _points.Add(cha, [new Point(i, index)]);
                }
                else
                {
                    value.Add(new Point(i, index));
                }
            }
        }

        maxY = index;
        maxX = i;
    }

    public void Test()
    {
        var list = new List<List<Point>>();
        var index = 1;
        // foreach (var kvp in _points)
        // {
        //     foreach (var point in kvp.Value.SelectMany((x, i) => kvp.Value.Skip(i + 1), (x, y) => Tuple.Create(x, y)))
        //     {
        //         var distance = GetDistance(point.Item1, point.Item2);
        //         if (point.Item1.X < point.Item2.X && point.Item1.Y < point.Item2.Y)
        //         {
        //             var newPoint1 = new Point(point.Item1.X - distance.X, point.Item1.Y - distance.Y); 
        //             var newPoint2 = new Point(point.Item2.X + distance.X, point.Item2.Y + distance.Y);
        //             list.Add(new List<Point>(){newPoint1, newPoint2});
        //
        //         }
        //         else
        //         {
        //             distance.X = -1 * distance.X;
        //             // distance.Y = -1 * distance.Y;
        //             
        //             var newPoint1 = new Point(point.Item1.X - distance.X, point.Item1.Y - distance.Y); 
        //             var newPoint2 = new Point(point.Item2.X + distance.X, point.Item2.Y + distance.Y);
        //             list.Add(new List<Point>(){newPoint1, newPoint2});
        //
        //         }
        //         
        //         // list.Add(newPoint2);
        //     }
        // }
        
        //part 2
        foreach (var kvp in _points)
        {
            foreach (var point in kvp.Value.SelectMany((x, i) => kvp.Value.Skip(i + 1), (x, y) => Tuple.Create(x, y)))
            {
                foreach (var distance in GetDistance2(point.Item1, point.Item2))
                {
                    if (point.Item1.X < point.Item2.X && point.Item1.Y < point.Item2.Y)
                    {
                        var newPoint1 = new Point(point.Item1.X - distance.X, point.Item1.Y - distance.Y); 
                        var newPoint2 = new Point(point.Item2.X + distance.X, point.Item2.Y + distance.Y);
                        list.Add(new List<Point>(){newPoint1, newPoint2});
        
                    }
                    else
                    {
                        var tt  = -1 * distance.X;
                        // distance.Y = -1 * distance.Y;
                    
                        var newPoint1 = new Point(point.Item1.X - tt, point.Item1.Y - distance.Y); 
                        var newPoint2 = new Point(point.Item2.X + tt, point.Item2.Y + distance.Y);
                        list.Add(new List<Point>(){newPoint1, newPoint2});
        
                    }
                }
               
            }
        }

        _points['#'].AddRange(list.SelectMany(x => x));
        // foreach (var point in list)
        // {
        //     _points.Add((index++).ToString()[0],point);
        //
        // }
    }

    // public int Count()
    // {
    //     return _points
    //          .Where(p => 
    //              p.Value.Contains(new Point(j, i))
    //          ).Key == "#";
    //     // return _points.Where(x => x.Key == '#').SelectMany(x => x.Value).ToHashSet().Count();
    // }

    public int Draw()
    {
        var count = 0;
        for (int i = 0; i < maxY; i++)
        {
            for (int j = 0; j < maxX; j++)
            {
                var t = _points
                    .FirstOrDefault(p => 
                        p.Value.Contains(new Point(j, i))
                    ).Key;
                
                if (t != default)
                {
                    if (t == '#')
                    {
                        count++;
                    }
                    Console.Write(t);
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();
        }
        return count;
    }
    private static Point GetDistance(Point point1,Point point2)
    {
        return new Point()
        {
            X =  Math.Abs(point1.X - point2.X),
            Y =  Math.Abs(point1.Y - point2.Y)
        };
    }
    private static IEnumerable<Point> GetDistance2(Point point1,Point point2)
    {
        var point  = new Point()
        {
            X =  Math.Abs(point1.X - point2.X),
            Y =  Math.Abs(point1.Y - point2.Y)
        };
        foreach (var i in Enumerable.Range(0,100))
        {
            yield return new Point(point.X * i, point.Y * i);
        }
        
    }
}

