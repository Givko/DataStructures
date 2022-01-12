using DataStructures.Solutions;
using DataStructures.Solutions.BasicTreeDataStructures;
using DataStructures.Solutions.BinarySearchTreeAndHeaps;
using DataStructures.Solutions.StacksAndQueues;

//var input = Console.ReadLine()
//    ?.Split(' ', StringSplitOptions.RemoveEmptyEntries)
//    .Select(num => int.Parse(num))
//    .ToArray();

int[] pair = new[] { 1,2,3,4,5,6,7,8,9,8,7,6,5,6,5 };
var tree = new MaxHeap<int>();

for (int i = 0; i < pair.Length; i++)
{
    tree.Add(pair[i]);
}

tree.Print();