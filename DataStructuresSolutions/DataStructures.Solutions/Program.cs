using DataStructures.Solutions;
using DataStructures.Solutions.Advanced.BAndRedAndBlackTrees;

int[] pair = new[] { 1, 2, 3, 4, -1, -2, 5, 8, -3,-10,-8,7,9 };
var tree = new RedAndBlackTree<int>();

for (int i = 0; i < pair.Length; i++)
{
    Console.WriteLine();
    Console.WriteLine();
    tree.Add(pair[i]);
    Console.WriteLine();
    Console.WriteLine();
}
