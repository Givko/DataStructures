var input = Console.ReadLine()
    ?.Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(num => int.Parse(num))
    .ToArray()
    .QuickSort();

Console.WriteLine(string.Join(", ", sorted));
