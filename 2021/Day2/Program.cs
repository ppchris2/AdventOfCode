// See https://aka.ms/new-console-template for more information

using System.Numerics;

var t = new Vector();
// C:\code\AdventOfCode\Day2\example.txt
var file = File.ReadAllLines("C:\\code\\AdventOfCode\\2021\\Day2\\input.txt");

foreach (var s in file)
{

    var split = s.Split(' ');

    switch (split[0])
    {
        case "forward":
            t.X += int.Parse(split[1]);
            break;
        case "down":
            t.Y += int.Parse(split[1]);
            break;
        case "up":
            t.Y -= int.Parse(split[1]);
            break;
    }
   
}
Console.WriteLine(t.X * t.Y);

//part 2 
// down X increases your aim by X units.
//     up X decreases your aim by X units.
//     forward X does two things:
// It increases your horizontal position by X units.
//     It increases your depth by your aim multiplied by X.


var tt = new Vector();

foreach (var s in file)
{

    var split = s.Split(' ');

    switch (split[0])
    {
        case "forward":
            tt.Y += tt.Z * int.Parse(split[1]);
            tt.X += int.Parse(split[1]);
            break;
        case "down":
            tt.Z += int.Parse(split[1]);
            break;
        case "up":
            tt.Z -= int.Parse(split[1]);
            break;
    }
   
}
Console.WriteLine(tt.X * tt.Y);

struct Vector
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
}