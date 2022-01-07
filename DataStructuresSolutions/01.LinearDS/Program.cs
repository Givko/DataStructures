using _01.LinearDS;

var input = Console.ReadLine()
    ?.Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(num => int.Parse(num))
    .ToArray();
var occurences = input.CountOfOccurences();

foreach (var kvp in occurences)
{
    Console.WriteLine($"{kvp.Key} -> {kvp.Value} times");
}