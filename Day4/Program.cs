
var t =
    "MMMSXXMASM\nMSAMXMSMSA\nAMXSXMAAMM\nMSAMASMSMX\nXMASAMXAMM\nXXAMMXXAMA\nSMSMSASXSS\nSAXAMASAAA\nMAMMMXMMMM\nMXMXAXMASX";

var lines = t.Split('\n');
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

foreach (var mask in masks)
{
    Traverse( mask, matrix);
}

void Traverse(char[,] mask, char[,] matrix)
{
    var count = 0;

    for (var i = 1; i < matrix.GetLength(0) - 1; i++)
    {
        for (var y = 1; y < matrix.GetLength(1)-1; y++)
        {
            if (matrix[i + y - 1, i  - 1] == mask[i + y - 1, i  - 1] &&
                matrix[i + y, i ] == mask[i + y, i ] &&
                matrix[i + y + 1, i  + 1] == mask[i + y + 1, i  + 1] &&
                matrix[i + y + 1, i  - 1] == mask[i + y + 1, i  - 1] &&
                matrix[i + y + 1, i  - 1] == mask[i + y + 1, i  - 1])
            {
                count++;
            }
        }   
    }
}

Console.WriteLine("Hello, World!");