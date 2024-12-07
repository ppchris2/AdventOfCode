// See https://aka.ms/new-console-template for more information


using System.Diagnostics;

var example = @"190: 10 19
3267: 81 40 27
83: 17 5
156: 15 6
7290: 6 8 6 15
161011: 16 10 13
192: 17 8 14
21037: 9 7 18 13
292: 11 6 16 20";

var stop = Stopwatch.GetTimestamp();
var file = File.ReadAllText("C:\\code\\AdventOfCode\\Day7\\input.txt");
var trees = file.Split('\n').Select(x => new Line(x)).ToArray();
    
var asd = trees.Where(x => x.IsOk).Aggregate(ulong.MinValue, (i, line) => i + line.Target);
Console.WriteLine(asd);
var test = Stopwatch.GetElapsedTime(stop);
;

class Line
{
   
    public bool IsOk {get; set;} = false;
    public ulong Target { get; set; }
    
    public Line(string line)
    {
        Target = ulong.Parse(line.Split(' ').Single(x => x.Contains(':')).Trim(':'));
        var numbers = line.Split(' ').Where(x => !x.Contains(':')).Select(ulong.Parse).ToArray();
        
        var tree = new BinaryTree();

        foreach (var (i, number) in numbers.Index())
        {
            
            if (tree.Add(number, Target, i == numbers.Length - 1))
            {
                IsOk = true;
                break;
            }
        }
    }
}

public class BinaryTree
{
    public Node? Root { get; private set; }

    public bool Add(ulong n, ulong target, bool final)
    {
        if (Root == null)
        {
            Root = new Node(n);
        }
        else
        {
            if(Root.Add(n, target, final))
            {
                return true;
            }
        }

        return false;
    }

}

public class Node
{
    
    private static readonly Func<ulong, ulong, ulong> mult = (ulong a, ulong b) => a * b;
    private static readonly Func<ulong, ulong, ulong> add = (ulong a, ulong b) => a + b;
    private static readonly Func<ulong, ulong, ulong> part2Nonsense = (ulong a, ulong b) => ulong.Parse(a.ToString() + b.ToString());

    public ulong Value { get; set; }
    public Node? Left { get; set; } = null!;
    public Node? Right { get; set; } = null!;
    public Node? Part2Nonsense { get; set; } = null!;

    public Node(ulong value)
    {
        Value = value;
    }

    public bool Add(ulong n, ulong target, bool final)
    {
       
        if (Left == null)
        {
            var leftValue = mult(Value, n);
            if (leftValue == target && final)
            {
                return true;
            }
            Left = new Node(leftValue);
        }
        else
        {
            if (Left.Add(n, target, final))
            {
                return true;
            }
        }
        
        
        if (Right == null)
        {
            var rightValue = add(Value, n);
            if (rightValue == target && final)
            {
                return true;
            }
            Right = new Node(rightValue);
        }
        else
        {
            if (Right.Add(n, target, final))
            {
                return true;
            }
        }
        
        if (Part2Nonsense == null)
        {
            var middle = part2Nonsense(Value, n);
            if (middle == target && final)
            {
                return true;
            }
            Part2Nonsense = new Node(middle);
        }
        else
        {
            if (Part2Nonsense.Add(n, target, final))
            {
                return true;
            }
        }
        return false;
    }
}