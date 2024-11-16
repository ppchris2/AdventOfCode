//var input = @"0 3 6 9 12 15
//1 3 6 10 15 21
//10 13 16 21 30 45";

var input = File.ReadAllLines("C:\\Users\\ppchr\\Source\\Repos\\advent-of-code-2023\\Day9\\input.txt");


int res = 0;
foreach( var line in input)
{
    var pyramid = new Pyramid();
    var nums = new Nums(line);
    CreatePyramid(pyramid, nums);


    res += pyramid.GetFinalPart2();
}

Console.WriteLine(res);

Pyramid CreatePyramid(Pyramid pyramid, Nums nums)
{
    if(nums.Numbers.Count == 0 || nums.Numbers.All(x => x==0)) 
    { 
        return pyramid; 
    }

    if(pyramid.PyramidSteps.Count == 0)
    {
        var step = new Nums(nums.Numbers);
        pyramid.PyramidSteps.Add(step);
    }
    var nextStep = new Nums();

    for (var index = 0; index < nums.Numbers.Count - 1; index++)
    {
        var diff = nums[index + 1] - nums[index];

        nextStep.Numbers.Add(diff);
    }
    pyramid.PyramidSteps.Add(nextStep);

    return CreatePyramid(pyramid, nextStep);

}

class Pyramid
{
    public List<Nums> PyramidSteps { get; set; } = new List<Nums>();

    public uint GetFinal()
    {
        //var lastSteps = PyramidSteps.Select(x => x.Numbers.Last()).Order();

        //part2
        var lastSteps = PyramidSteps.Select(x => x.Numbers.Last()).Reverse();

        uint acc = 0;
        uint result = 0;
        foreach (var last in lastSteps)
        {
            result = (uint)last + acc;
            acc += (uint)last;
        }

        return result;
    }



    //10  13  16  21  30  45  
    //C  3   3   5   9  15  
    // B  0   2   4   6  
    //   A   2   2   2  
    //     0   0   0  

    //5  10  13  16  21  30  45
    //  5   3   3   5   9  15
    //   -2   0   2   4   6
    //      2   2   2   2
    //        0   0   0
    public int GetFinalPart2()
    {
        //var firstSteps = PyramidSteps.Re.Select(x => x.Numbers.First()).Order();
        foreach(var t in PyramidSteps)
        {
            t.Numbers.Reverse();
        }
       
        var firstSteps = PyramidSteps.Select(x => x.Numbers.Last()).Reverse();


        int acc = 0;
        int step = 0;
        foreach (var last in firstSteps)
        {
            step = last - acc;
            acc = step;
        }
        return step;
    }
}


struct Nums
{
    public List<int> Numbers { get; } = new List<int>();
    public Nums()
    {
        Numbers = new List<int>();
    }
    public Nums(string nums)
    {
        Numbers = nums.Split(' ').Select(int.Parse).ToList();
    }

    public Nums(List<int> nums)
    {
        Numbers = nums;
    }

    public int this[int i]
    {
        get { return Numbers[i]; }
        //set { arr[i] = value; }
    }
}