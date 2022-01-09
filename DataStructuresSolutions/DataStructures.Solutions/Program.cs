using DataStructures.Solutions;
using DataStructures.Solutions.StacksAndQueues;

//var input = Console.ReadLine()
//    ?.Split(' ', StringSplitOptions.RemoveEmptyEntries)
//    .Select(num => int.Parse(num))
//    .ToArray();
var n = int.Parse(Console.ReadLine());
var m = int.Parse(Console.ReadLine());

var shortestPath = SequenceNM.FindShortestPath(n, m);
Console.WriteLine(string.Join("->", shortestPath));