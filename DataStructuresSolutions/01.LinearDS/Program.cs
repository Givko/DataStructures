using _01.LinearDS;

var input = Console.ReadLine()
    ?.Split(' ', StringSplitOptions.RemoveEmptyEntries)
    //.Select(num => int.Parse(num))
    .ToArray();
input.QuickSort();

Console.WriteLine(string.Join(", ", input));
