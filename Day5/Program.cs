// See https://aka.ms/new-console-template for more information

var example = @"47|53
97|13
97|61
97|47
75|29
61|13
75|53
29|13
97|29
53|29
61|53
97|53
61|29
47|13
75|47
97|75
47|61
75|61
47|29
75|13
53|13

75,47,61,53,29
97,61,53,29,13
75,29,13
75,97,47,61,53
61,13,29
97,13,75,29,47";


///75,97,47,61,53
///
///
///
///
/// 



var file = File.ReadAllText("C:\\code\\AdventOfCode\\Day5\\input.txt");

var pages = example.Split('\n').Where(x => x.Contains(',')).Select(x => x.Split(','));
var rules = example.Split('\n').Where(x => x.Contains('|')).Select(x => x.Split('|')).ToArray();

var ok = false;
long count = 0;
foreach (var page in pages.Select(x => x.Select(int.Parse).ToArray()))
{
    ok = true;
    foreach (var rule in rules.Select(x => x.Select(int.Parse).ToArray()))
    {
        if(!FollowsRule((rule[0], rule[1]), page))
        {
            ok = false;
        }
    }

    if (ok)
    {
        count+= page[page.Length / 2];
    }
}
Console.WriteLine(count);

bool FollowsRule((int, int) rule, int[] pages)
{
    if (!pages.Contains(rule.Item1) || !pages.Contains(rule.Item2))
    {
        return true;
    }

    return pages.Index().Single(x => x.Item == rule.Item1).Index
           < pages.Index().Single(x => x.Item == rule.Item2).Index;
}

//part 2 


var notOrderedRows = new List<int[]>();
foreach (var page in pages.Select(x => x.Select(int.Parse).ToArray()))
{
    foreach (var rule in rules.Select(x => x.Select(int.Parse).ToArray()))
    {
        if(!FollowsRule((rule[0], rule[1]), page))
        {
            notOrderedRows.Add(page);
            break;
        }
    }
}


foreach (var row in notOrderedRows)
{
    foreach (var rule in rules.Select(x => x.Select(int.Parse).ToArray()))
    {
        var newRow = ForceFollowsRule((rule[0], rule[1]), row);
        // if(!FollowsRule((rule[0], rule[1]), page))
        // {
        //     notOrderedRows.Add(page);
        // }
    }
}

int[] ForceFollowsRule((int, int) rule, int[] pages)
{
    if (!pages.Contains(rule.Item1) && !pages.Contains(rule.Item2))
    {
        return pages;
    }

    var indexOfSmallerElement = pages.Index().Single(x => x.Item == rule.Item1).Index;
    var indexOfLargerElement = pages.Index().Single(x => x.Item == rule.Item2).Index;
    
    var temp = pages[indexOfLargerElement];
    
    
    pages[indexOfSmallerElement] = pages[indexOfLargerElement];
    
    // return pages.Index().Single(x => x.Item == rule.Item1).Index
    //        < pages.Index().Single(x => x.Item == rule.Item2).Index;
}