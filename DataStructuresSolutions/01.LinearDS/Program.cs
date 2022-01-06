var input = Console.ReadLine()
    ?.Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(num => int.Parse(num))
    .ToList();

var sorted = Sort(input);
Console.WriteLine(string.Join(", ", sorted));

void SumAndAverage(string[]? input)
{
    if (input == null || input.Length == 0)
    {
        Console.WriteLine("Sum=0; Average=0.00");
        return;
    }

    double sum = 0;
    for (int i = 0; i < input!.Length; i++)
    {
        sum += int.Parse(input[i]);
    }

    var average = sum / input.Length;
    Console.WriteLine($"Sum={sum}; Average={average:0.00}");
}

List<int> Sort(List<int>? input)
{
    if (input.Count == 0) return new List<int>();
    
    int pivot = input[0];
    List<int> leftThanPivot = new List<int>();
    List<int> rightThanPivot = new List<int>();
    for (int i = 1; i < input.Count; i++)
    {
        if (input[i] <= pivot)
        {
            leftThanPivot.Add(input[i]);
        }
        else
        {
            rightThanPivot.Add(input[i]);
        }
    }

    var leftSorted = Sort(leftThanPivot);
    var rightSorted = Sort(rightThanPivot);
    leftSorted.AddRange(rightSorted);
    return leftSorted;
}