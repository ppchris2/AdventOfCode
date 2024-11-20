// See https://aka.ms/new-console-template for more information


using System.Text;

var example = "00100\n11110\n10110\n10111\n10101\n01111\n00111\n11100\n10000\n11001\n00010\n01010";
var file = File.ReadAllLines("C:\\code\\AdventOfCode\\2021\\Day3\\input.txt");

var list = file//example.Split('\n')
    .Select(bits => bits
        .Select(x => short.Parse(x.ToString()))
        .ToArray()
    )
    .ToList();


var binary = Convert.ToUInt32(GetBitString(list, true), 2);
var binary2 = Convert.ToUInt32(GetBitString(list, false), 2);



var era = Test(list, 0, false);
var era2 = Test(list, 0, true);

binary = Convert.ToUInt32(era, 2);
binary2 = Convert.ToUInt32(era2, 2);

Console.WriteLine(binary * binary2);

string Test(List<short[]> bitNumber, int iteration, bool reverse)
{
    if (bitNumber.Count == 1)
    {
        return bitNumber.Single().Aggregate(new StringBuilder(), (builder, shorts) => builder.Append(shorts)).ToString();
    }
    
    var ones = bitNumber.Count(x => x[iteration] == 1);
    var zeros = bitNumber.Count(x => x[iteration] == 0);

    if ((reverse && ones >= zeros) || (!reverse && ones < zeros))
    {
        bitNumber = bitNumber.Where(x => x[iteration] == 1).Take(ones).ToList();
        return Test(bitNumber, iteration + 1, reverse);
    }

    bitNumber = bitNumber.Where(x => x[iteration] == 0).Take(zeros).ToList();
    return Test(bitNumber, iteration + 1, reverse);

}



string GetBitString(List<short[]> bitNumber, bool reverse)
{
    var bitString = "";
    for (var i = 0; i < bitNumber.FirstOrDefault()?.Length; i++)
    {
        var ones = list.Count(x => x[i] == 1);
        var zeros = list.Count(x => x[i] == 0);

        if (reverse)
        {
           if (ones >= zeros)
           {
               bitString += '1';
           }
           else
           {
               bitString += '0';
           } 
        }
        else
        {
            if (ones <= zeros)
            {
                bitString += '1';
            }
            else
            {
                bitString += '0';
            } 
        }
    }
    return bitString;
}

//part 2

