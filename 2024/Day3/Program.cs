// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

var example = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))\n".Split('\n');
var file = File.ReadAllLines("C:\\code\\temp\\Day3\\input.txt");


var regex = new Regex(@"mul\((\d+),(\d+)\)", RegexOptions.Compiled);
long sum = 0; 

foreach (var line in example)
{
    var tets = regex.Matches(line);
    foreach (Match match in tets)
    {
        sum += Convert.ToInt64(match.Groups[1].Value) * Convert.ToInt64(match.Groups[2].Value);
    }
}
//part 2
var regex2 = new Regex(@"mul\((\d+),(\d+)\)|do\(\)|don't\(\)", RegexOptions.Compiled);
var example2 = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))".Split('\n');
var enabled = true;

sum = 0; 

foreach (var line in file)
{
    var tets = regex2.Matches(line);

    foreach (Match match in tets)
    {
        if (match.ToString() == "do()")
        {
            enabled = true;
        }
        else if (match.ToString() == "don't()")
        {
            enabled = false;

        }
        else
        {
            sum += enabled ? Convert.ToInt64(match.Groups[1].Value) * Convert.ToInt64(match.Groups[2].Value) : 0;
        }
    }
}
;