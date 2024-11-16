// var instructions = "LRLRLLRLRLRRLRLRLRRLRLRLLRRLRRLRLRLRLLRRRLRRRLLRRLRLRLRRRLRRLRRRLRLRLRRLRLLRLRLRRLRRRLRLRRLRRRLLRLRLRRRLRRRLRLRRRLRLRRRLLRRLLLRRRLLRRRLRRRLRRRLRLRLRLLRLRRLRLRLLLRRLRRLRRLRLRRLRRLLRRLRLRRRLRLRLLRRRLRRRLRRRLLLRRRLRLRLRRLRRRLRRRLRLRRRLRRLRRRLRLRRLLRRRLRRRLLLRRLRLRLRRLRRRLRRLRRLRLRRRR";
//
// var input = File.ReadAllLines("C:\\code\\advent-of-code-2023\\Day8\\input.txt");
// var tt = input.Select(x => {
//
//     var a = x.Replace("=", "").Replace("(", "").Replace(")", "").Replace(",", "").Split(' ').Where(X => X != "").ToArray();
//     return new Map(a[0], a[1], a[2]);
//     
// }).ToDictionary(x => x.Source, x => x);
//
// var current = tt.First(x => x.Key == "AAA").Value;
// var steps = 0;
// var foundIt = false;
// while (true)
// {
//     foreach (var nextStep in instructions.Select(dir => dir == 'L' ? current.Left : current.Right))
//     {
//         current = tt[nextStep];
//         steps++;
//
//         if (current.Source == "ZZZ")
//         {
//             foundIt = true;
//             break;
//         }
//     }
//
//     if (foundIt)
//     {
//         break;
//     }
// }
// Console.WriteLine(steps);
//
//
// struct Map
// {
//     public Map(string source, string left, string right)
//     {
//         Source = source;
//         Left = left;
//         Right = right;
//     }
//     public string Source { get; set; }
//     public string Left { get; set; }
//     public string Right { get; set; }
// }



//part 2
var instructions = "LRLRLLRLRLRRLRLRLRRLRLRLLRRLRRLRLRLRLLRRRLRRRLLRRLRLRLRRRLRRLRRRLRLRLRRLRLLRLRLRRLRRRLRLRRLRRRLLRLRLRRRLRRRLRLRRRLRLRRRLLRRLLLRRRLLRRRLRRRLRRRLRLRLRLLRLRRLRLRLLLRRLRRLRRLRLRRLRRLLRRLRLRRRLRLRLLRRRLRRRLRRRLLLRRRLRLRLRRLRRRLRRRLRLRRRLRRLRRRLRLRRLLRRRLRRRLLLRRLRLRLRRLRRRLRRLRRLRLRRRR";

var input = File.ReadAllLines("C:\\Users\\ppchr\\Source\\Repos\\advent-of-code-2023\\Day8\\input.txt");
var indexOfLetters = new Dictionary<char, int>();

var tt = input.Select(x => {

    var a = x.Replace("=", "").Replace("(", "").Replace(")", "").Replace(",", "").Split(' ').Where(X => X != "").ToArray();

    for (var index = 0; index < a.Length; index++)
    {
        var letters = a[index];
        var last = letters.Last();
        if (indexOfLetters.ContainsKey(last))
        {
            var newIndex = ++indexOfLetters[last];
            letters = $"{newIndex}{newIndex}{letters[0]}";
        }
        else
        {
            indexOfLetters.Add(last, 1);
            letters = $"{1}{1}{letters[0]}";

        }

        a[index] = letters;
    }

    return new Map(a[0], a[1], a[2]);
    
}).ToDictionary(x => x.Source, x => x);

;

struct Map
{
    public Map(string source, string left, string right)
    {
        Source = source;
        Left = left;
        Right = right;
    }
    public string Source { get; set; }
    public string Left { get; set; }
    public string Right { get; set; }
}