using System.Text;

var file = File.ReadAllLines("C:\\code\\advent-of-code-2023\\Day12\\example.txt");

// foreach (var line in file)
// {
//     var t = line.Split(' ');
//
//     var test = new Line()
//     {
//         Input = t[0],
//         Groups = t[1].Split(',').Select(int.Parse).ToList()
//     };
//     ;
// }


var test = file.Select(x => x.Split(' ')).Select(x => new Line()
{
    Input = x[0],
    Groups = x[1].Split(',').Select(int.Parse).ToList()
}).ToList();

// .??..??...?##. 1,1,3 

// ..#...#...###. 1,1,3 
// ..#..#....###. 1,1,3 
// .#....#...###. 1,1,3 
// .#...#....###. 1,1,3 

foreach (var line in test)
{
    var listOfString = new List<string>();
    var stin = new StringBuilder();
    foreach (var ch in line.Input)
    {
        if (ch is '#' or '?')
        {
            stin.Append(ch);
        }
        else
        {
            listOfString.Add(stin.ToString());
            stin.Clear();
        }
        
    }
    listOfString.Add(stin.ToString());
    stin.Clear();
    
    line.ListOfContinousGroups = listOfString.Where(x => x != string.Empty).ToList();
    
    
    
    
    
    
}



class Line
{
    public string Input { get; set; }
    public List<string> ListOfContinousGroups { get; set; }
    public List<int> Groups { get; set; }
}