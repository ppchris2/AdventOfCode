
using System.Linq;

var allLines = File.ReadAllLines("C:\\code\\advent-of-code-2023\\Day3\\input.txt");
var numberPositions = new List<Num>();
var specialChars = new List<SpecialChar>();
var lineCount = 0;

foreach (var line in allLines)
{
    var charToPosition = new List<(char, int)>();
    var i = 0;

    foreach(var cha in line)
    {
        if (char.IsDigit(cha))
        {
            charToPosition.Add((cha, i));
        }
        else if (cha == '.' && charToPosition.Count != 0)
        {
            var tt = new Num
            {
                Number = new string(charToPosition.Select(x => x.Item1).ToArray()),
                Positions = charToPosition.Select(x => x.Item2).ToArray(),
                Line = lineCount
            };
            numberPositions.Add(tt);
            charToPosition.Clear();
        }
        else if(!char.IsLetterOrDigit(cha) && cha != '.')
        {
            specialChars.Add(new SpecialChar
            {
                Line = lineCount,
                Position = i,
                Chara = cha
            });
            
            var tt = new Num
            {
                Number = new string(charToPosition.Select(x => x.Item1).ToArray()),
                Positions = charToPosition.Select(x => x.Item2).ToArray(),
                Line = lineCount
            };
            numberPositions.Add(tt);
            charToPosition.Clear();
        }

        if (charToPosition.Count != 0 && i == line.Length - 1)
        {
            var tt = new Num
            {
                Number = new string(charToPosition.Select(x => x.Item1).ToArray()),
                Positions = charToPosition.Select(x => x.Item2).ToArray(),
                Line = lineCount
            };
            numberPositions.Add(tt);
            charToPosition.Clear();
        }

        i++;
    }
    lineCount++;
}
var sum = 0;

foreach( var line in Enumerable.Range(0, allLines.Length))
{
    foreach(var lineChar in specialChars.Where(x => x.Line == line))
    {
        foreach(var t in numberPositions.Where(x =>
            x.Line == lineChar.Line ||
            x.Line == lineChar.Line - 1 ||
            x.Line == lineChar.Line + 1
        ).Where(x =>
            x.Positions.Any(y => lineChar.Position == y || lineChar.Position - 1 == y || lineChar.Position + 1 == y)
        ).Where(x =>
            !x.HasBeenUsed))
        {
            //for part 2
            //t.ChangeHasBeenUsed();
            sum += t.Value;
        }
    }
}
Console.WriteLine(sum);

//part 2
sum = 0;
foreach( var line in Enumerable.Range(0, allLines.Length))
{
    foreach(var possibleGear in specialChars.Where(x => x.Line == line && x.Chara == '*'))
    {
        var t = numberPositions.Where(x =>
            x.Line == possibleGear.Line ||
            x.Line == possibleGear.Line - 1 ||
            x.Line == possibleGear.Line + 1
        ).Where(x =>
            x.Positions.Any(y => possibleGear.Position == y || 
                                 possibleGear.Position - 1 == y || 
                                 possibleGear.Position + 1 == y)
        ).Where(x => !x.HasBeenUsed).ToArray();

        if (t.Length == 2)
        {
            sum += t[0].Value * t[1].Value;
            
        }
    }
}
Console.WriteLine(sum);


class Num
{
    public string Number { get; set; }
    public int Value => int.Parse(Number);
    public int[] Positions { get; set; }
    public int Line { get; set; }
    public bool HasBeenUsed { get; set; }

    public void ChangeHasBeenUsed()
    {
        HasBeenUsed = true;
    }
}

struct SpecialChar
{
    public int Position { get; set; }
    public int Line { get; set; }
    public char Chara { get; set; }
}