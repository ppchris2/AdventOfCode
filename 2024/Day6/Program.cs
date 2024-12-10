// See https://aka.ms/new-console-template for more information

using System.Drawing;

Console.WriteLine("Hello, World!");


var example=@"....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...";


var test = new Matrix(File.ReadAllText("C:\\code\\temp\\Day6\\input.txt"));

test.Move();
test.Draw();
Console.WriteLine(test.Touched.Count);


class Matrix
{
    public Matrix(string input)
    {
        var lines = input.Split('\n');
        MaxX = lines.Length;
        MaxY = lines.First().Length;
        
        for (var index = 0; index < lines.Length; index++)
        {
            var line = lines[index];
            
            for (var index1 = 0; index1 < line.Length; index1++)
            {
                var cha = line[index1];
                if (cha == '#')
                {
                    Obstacles.Add(new Point(index1, index));
                }

                if (cha is '^' or '>' or '<' or 'v')
                {
                    Soldier = new Soldier()
                    {
                        Movement = cha switch
                        {
                            'v' => Movement.Right,
                            '<' => Movement.Left,
                            '^' => Movement.Up,
                            '>' => Movement.Down,
                        },
                        Point = new Point(index1, index)
                    };
                }
            }
        }
    }
    
    private int MaxX { get; set; }
    private int MaxY { get; set; }
    private Soldier Soldier { get; set; }
    private List<Point> Obstacles { get; set; } = new List<Point>();

    public HashSet<Point> Touched { get; private set; } = new HashSet<Point>();

    public void Draw()
    {
        for (int i = 0; i < MaxY; i++)
        {
            for (int j = 0; j < MaxX; j++)
            {
                if (Obstacles.Any(x => x.X == j && x.Y == i))
                {
                    Console.Write('#');
                }
                else if(Touched.Any(x => x.X == j && x.Y == i))
                {
                    Console.Write('X');
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();
        }
    }
    public void Move()
    {
        while (true)
        {
            if (Soldier.Point.X >= MaxX || Soldier.Point.Y >= MaxY || Soldier.Point.X == 0 || Soldier.Point.Y == 0)
            {
                return;
            }

            if (!WillMoveInRock())
            {
                MoveSingle();
            }
            else
            {
                ChangeDirection();
                MoveSingle();
            }

            Touched.Add(Soldier.Point);
        }
    }

    private void ChangeDirection()
    {
        Soldier.Movement = Soldier.Movement switch
        {
            Movement.Up => Movement.Right,
            Movement.Down => Movement.Left,
            Movement.Left => Movement.Up,
            Movement.Right => Movement.Down,
        };
    }

    private void MoveSingle()
    {
        Soldier.Point = Soldier.Movement switch
        {
            Movement.Up => Soldier.Point with { Y = Soldier.Point.Y - 1 },
            Movement.Down => Soldier.Point with { Y = Soldier.Point.Y + 1 },
            Movement.Left => Soldier.Point with { X = Soldier.Point.X - 1 },
            Movement.Right => Soldier.Point with { X = Soldier.Point.X + 1 },
        };
    }

    private bool WillMoveInRock()
    {
        var nextPoint = Soldier.Movement switch
        {
            Movement.Up => Soldier.Point with { Y = Soldier.Point.Y - 1 },
            Movement.Down => Soldier.Point with { Y = Soldier.Point.Y + 1 },
            Movement.Left => Soldier.Point with { X = Soldier.Point.X - 1 },
            Movement.Right => Soldier.Point with { X = Soldier.Point.X + 1 },

        };
        return Obstacles.Any(x => x.X == nextPoint.X && x.Y == nextPoint.Y);
    }
}

class Soldier
{
    public Movement Movement { get; set; }
    public Point Point { get; set; }
}

enum Movement
{
    Up, Down, Left, Right
}