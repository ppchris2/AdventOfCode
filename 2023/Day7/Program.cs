var example = @"2233J 1
aabbJ 2";

//var input = File.ReadAllLines("C:\\Users\\ppchr\\Source\\Repos\\advent-of-code-2023\\Day7\\input.txt");

var games = example.Split('\n').Select(x =>
{
    var y = x.Split(' ').ToArray();
    return new Game() {Hand = y[0], Bid = int.Parse(y[1])};
});

var groups = games.GroupBy(x => x.FindTypePart2()).OrderByDescending(x => x.Key);
var rank = 1;
var result = 0;
foreach (var group in groups)
{
    var t = group.OrderByDescending(x => x.Hand, new Comp()).ToArray();
    foreach (var tt in t)
    {
        result += rank++ * tt.Bid;

    }
}
Console.WriteLine(result);

public class Comp : IComparer<string>
{
    public static List<char> Order = new List<char>
    {
        'A',
        'K',
        'Q',
        'J',
        'T',
        '9',
        '8',
        '7',
        '6',
        '5',
        '4',
        '3',
        '2'
    };

    public static List<char> OrderPart2 = new List<char>
    {
        'A',
        'K',
        'Q',
        'T',
        '9',
        '8',
        '7',
        '6',
        '5',
        '4',
        '3',
        '2',
        'J'
    };

    public int Compare(string? x, string? y)
    {
        foreach (var cha in x.Zip(y))
        {
            if (OrderPart2.IndexOf(cha.First) == OrderPart2.IndexOf(cha.Second))
            {
                continue; 
            }
            if (OrderPart2.IndexOf(cha.First) > OrderPart2.IndexOf(cha.Second))
            {
                return 1;
                
            }

            return -1;
        }

        return 0;
    }
}

class Game
{
    public string Hand { get; set; }
    public int Bid { get; set; }
    
    
    public Types FindType()
    {
        var doublePairs = Hand.GroupBy(c => c).Where(g=>g.Count() == 2).ToArray();
        var groups = Hand.GroupBy(c => c).Max(g=>g.Count());
        return groups switch
        {
            5 => Types.FiveOfKind,
            4 => Types.FourOfKind,
            3 when doublePairs.Count() == 1 => Types.FullHouse,
            3 => Types.ThreeOfKind,
            2  when doublePairs.Count() == 2 => Types.TwoPair,
            2 when doublePairs.Count() == 1 => Types.OnePair,
            _ => Types.NoPair
        };
    }

    public Types FindTypePart2()
    {
        //T3T3J
        var jokers = Hand.Where(x => x == 'J').Count();
        if(jokers == 5)
        {
            return Types.FiveOfKind;
        }
        var newHand = Hand.Replace("J", "");

        var doublePairs = newHand.GroupBy(c => c ).Where(g => { 
            if(g.Count() + jokers == 3 && jokers == 1)
            {
                return true;
            }
            return g.Count() + jokers == 2;
                //
        }).ToArray();
        var groups = newHand.GroupBy(c => c).Max(g => g.Count() + jokers);
        return groups switch
        {
            5 => Types.FiveOfKind,
            4 => Types.FourOfKind,
            3 when doublePairs.Count() != 0 => Types.FullHouse,
            3 => Types.ThreeOfKind,
            2 when doublePairs.Count() == 2 => Types.TwoPair,
            2 => Types.OnePair,
            _ => Types.NoPair
        };
    }

}

enum Types
{
    FiveOfKind,
    FourOfKind,
    FullHouse,
    ThreeOfKind,
    TwoPair,
    OnePair,
    NoPair
}
enum HandStrengths
{
    // A, K, Q, J, T, 9, 8, 7, 6, 5, 4, 3, 2
    
    
}