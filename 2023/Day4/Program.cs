var allLines = File.ReadAllLines("C:\\code\\advent-of-code-2023\\Day4\\input.txt");
var cummulativeScore = 0;

foreach (var line in allLines)
{
    var spl = line.Split(new[] {':', '|'});
    var winningNumbers = spl[1].Split(' ').Select(x => int.TryParse(x, out var r) ? (int?)r: null ).Where(x => x is not null).ToArray();
    var ownNumbers = spl[2].Split(' ').Select(x => int.TryParse(x, out var r) ? (int?)r: null ).Where(x => x is not null).ToHashSet();

    var score = 0;
    foreach (var winningNumber in winningNumbers)
    {
        if (ownNumbers.Contains(winningNumber))
        {
            if (score == 0)
            {
                score = 1;
            }
            else
            {
                score *= 2;
            }
        }

        
    }
    cummulativeScore += score;
}

var games = new List<Card>();

var winningCards = new List<int>();
foreach (var line in allLines)
{
    var spl = line.Split(new[] {':', '|'});
    
    var cardNumber = int.Parse(new String(spl[0].Where(char.IsDigit).ToArray()));
    
    var winningNumbers = spl[1].Split(' ').Select(x => int.TryParse(x, out var r) ? (int?) r : null)
        .Where(x => x is not null).ToArray();
    
    var ownNumbers = spl[2].Split(' ').Select(x => int.TryParse(x, out var r) ? (int?) r : null)
        .Where(x => x is not null).ToHashSet();

    games.Add(new Card()
    {
        CardNumber = cardNumber,
        WinningNumbers = winningNumbers,
        OwnNumbers = ownNumbers,
        Instances = 1
    });
}

for (var index = 0; index < games.Count; index++)
{
    var game = games[index];

    var count = game.Instances;
    do
    {
        var score = game.WinningNumbers
            .Count(winningNumber => game.OwnNumbers.Contains(winningNumber));
    
        foreach (var g in Enumerable.Range(game.CardNumber + 1, score))
        {
            var t = games.FirstOrDefault(x => x.CardNumber == g);
            if (t is not null)
            {
                t.Instances +=1;
            }
        }
    } while (--count != 0);
    
    
}

var sum = games.Sum(x => x.Instances);
;
class Card
{
    public int CardNumber { get; set; }
    public int Instances { get; set; }
    public int?[] WinningNumbers { get; set; }
    public HashSet<int?> OwnNumbers { get; set; }
}
