using DataStructures.Solutions;
using DataStructures.Solutions.BasicTreeDataStructures;
using DataStructures.Solutions.StacksAndQueues;

//var input = Console.ReadLine()
//    ?.Split(' ', StringSplitOptions.RemoveEmptyEntries)
//    .Select(num => int.Parse(num))
//    .ToArray();
var n = int.Parse(Console.ReadLine());
var tree = new Tree<int>();

for (int i = 0; i < n-1; i++)
{
   int[] pair = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(num => int.Parse(num)).ToArray();
    tree.AddChildTo(pair[0], pair[1]);
}

tree.PrintMiddleNodes();