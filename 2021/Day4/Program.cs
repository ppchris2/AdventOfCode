// See https://aka.ms/new-console-template for more information

using System.Numerics;

var file = File.ReadAllLines("C:\\code\\AdventOfCode\\2021\\Day4\\input.txt");

var bingoSeries = file[0].Split(',').Select(short.Parse).ToArray();

var bingoCards = new List<BingoCard>();

BingoCard card = new BingoCard();
foreach (var s in file.Skip(2))
{
    if (s == string.Empty)
    {
        bingoCards.Add(card);
        card = new BingoCard();
    }
    else
    {
        card?.AddRow(
            s.Split(' ')
                .Where(x => x != string.Empty)
                .Select(x =>
                {
                    return short.Parse(x);
                })
                .ToArray()
            );
    }
}
bingoCards.Add(card);
// part 1
// foreach (var series in bingoSeries)
// {
//     foreach (var singleCard in bingoCards)
//     {
//         singleCard.MarkNumber(series);
//         if (singleCard.HasWon())
//         {
//             var test = singleCard.GetSumOfUnvisitedNumbers();
//             Console.WriteLine(test * series);
//             return;
//         }
//     }
// }

//part 2 

var wonbingoCards = new List<BingoCard>();

foreach (var series in bingoSeries)
{
    foreach (var singleCard in bingoCards.Except(wonbingoCards))
    {
        singleCard.MarkNumber(series);
        
        
        
        if (singleCard.HasWon())
        {
            wonbingoCards.Add(singleCard);
        }
        if (wonbingoCards.Count == bingoCards.Count)
        {
            var test = singleCard.GetSumOfUnvisitedNumbers();
            Console.WriteLine(test * series);
        }
    }
}

class BingoCard
{
    public List<List<BingoNumber>> Board { get; set; } = new List<List<BingoNumber>>(5);

    public void MarkNumber(short number)
    {
        for (var i = 0; i < Board.Count; i++)
        {
            for (var j = 0; j < Board[0].Count; j++)
            {
                if (Board[i][j].Number == number)
                {
                    Board[i][j].Visited = true;
                }
            }
        }
    }
    
    public bool HasWon()
    {
        for (var i = 0; i < Board.Count; i++)
        {
            var visitedRowItem = 0;

            for (var j = 0; j < Board.Count; j++)
            {
                if (Board[i][j].Visited)
                {
                    visitedRowItem++;
                }

                if (visitedRowItem == Board.Count)
                {
                    return true;
                }
            }
        }
        
        for (var i = 0; i < Board.Count; i++)
        {
            var visitedColumnItem = 0;

            for (var j = 0; j < Board.Count; j++)
            {
                if (Board[j][i].Visited)
                {
                    visitedColumnItem++;
                }

                if (visitedColumnItem == Board.Count)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public int GetSumOfUnvisitedNumbers()
    {
        var sum = 0;
        for (var i = 0; i < Board.Count; i++)
        {
            for (var j = 0; j < Board[0].Count; j++)
            {
                if (!Board[i][j].Visited)
                {
                    sum += Board[i][j].Number;
                }
            }
        }
        return sum;
    }
    public void AddRow(short[] row)
    {
        Board.Add(row.Select(x => new BingoNumber(x)).ToList());
    }
}

class BingoNumber
{
    public BingoNumber( short number)
    {
        Visited = false;
        Number = number;
    }

    public short Number { get; private set; }
    public bool Visited { get; set; }
}