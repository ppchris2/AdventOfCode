
var t =
    "MMMSXXMASM\nMSAMXMSMSA\nAMXSXMAAMM\nMSAMASMSMX\nXMASAMXAMM\nXXAMMXXAMA\nSMSMSASXSS\nSAXAMASAAA\nMAMMMXMMMM\nMXMXAXMASX";
var input = File.ReadAllText("C:\\code\\AdventOfCode\\Day4\\input.txt");

var lines = input.Split('\n');
var matrix = new char[lines[0].Length, lines.Length];

for (var i = 0; i < lines.GetLength(0); i++)
{
    for (var j = 0; j < lines.GetLength(0); j++)
    {
        matrix[i, j] = lines[i][j];
    }
}


var masks = new[]
{
    new[,] { { 'M','.','S' }, {'.', 'A', '.'}, { 'M','.','S' }},
    new[,] { { 'S','.','S' }, {'.', 'A', '.'}, { 'M','.','M' }},

    new[,] { { 'M','.','M' }, {'.', 'A', '.'}, { 'S','.','S' }},

    new[,] { { 'S','.','M' }, {'.', 'A', '.'}, { 'S','.','M' }}
};
var count = 0;
foreach (var mask in masks)
{
    count += Traverse( mask, matrix);
}

;
int Traverse(char[,] mask, char[,] matrix)
{
    var count = 0;

    for (var i = 1; i < matrix.GetLength(0) - 1; i++)
    {
        for (var y = 1; y < matrix.GetLength(1)-1; y++)
        {
            if (
                matrix[i, y] == mask[1, 1] &&
                matrix[i  - 1, y  - 1] == mask[0, 0] &&
                matrix[i + 1, y +1] == mask[2, 2] &&
                matrix[i -1, y + 1 ] == mask[0, 2] &&
                matrix[i + 1, y-1 ] == mask[2, 0] )
            {
                count++;
            }
        }   
    }
    return count;
}

Console.WriteLine("Hello, World!");