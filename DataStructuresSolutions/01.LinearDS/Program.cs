using _01.LinearDS;

var input = Console.ReadLine()
    ?.Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(num => int.Parse(num))
    .ToArray();
(int occurences, int number) = input.LongestSubsequence();

Console.WriteLine($"{number} - {occurences}");
