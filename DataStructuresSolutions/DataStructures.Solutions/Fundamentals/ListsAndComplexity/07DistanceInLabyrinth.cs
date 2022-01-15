using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Solutions.Fundamentals.ListsAndComplexity
{
    public class _07DistanceInLabyrinth
    {
        private static string[,] _Labyrinth = new string[,]
        {
            {"0","0","0","x","0","x"},
            {"0","x","0","x","0","x"},
            {"0","*","x","0","x","0"},
            {"0","x","0","0","0","0"},
            {"0","0","0","x","x","0"},
            {"0","0","0","x","0","x"}
        };

        private static int[] startPosition = new int[] { 2, 1 }; //row, col

        public static void MarkDistanceInCells()
        {
            Step(startPosition[0] - 1, startPosition[1], 1); //up
            Step(startPosition[0] + 1, startPosition[1], 1); //down
            Step(startPosition[0], startPosition[1] - 1, 1); //left
            Step(startPosition[0], startPosition[1] + 1, 1); //right

            for (int i = 0; i < _Labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < _Labyrinth.GetLength(1); j++)
                {
                    if (_Labyrinth[i, j] == "0")
                    {
                        _Labyrinth[i, j] = "u";
                    }

                    Console.Write($" {_Labyrinth[i, j]} ");
                }

                Console.WriteLine();
            }
        }

        public static void Step(int row, int col, int stepNumber)
        {
            //This check is valid only for the first step
            if (_Labyrinth[row, col] == "x" ||
                _Labyrinth[row, col] == "*" ||
                _Labyrinth[row, col] != "0" && int.Parse(_Labyrinth[row, col]) <= stepNumber)
            {
                return;
            }

            _Labyrinth[row, col] = stepNumber.ToString();

            //Up
            if (row - 1 >= 0 &&
                _Labyrinth[row - 1, col] != "x" &&
                _Labyrinth[row - 1, col] != "*" &&
                (_Labyrinth[row - 1, col] == "0" || int.Parse(_Labyrinth[row - 1, col]) > stepNumber + 1))
            {
                Step(row - 1, col, stepNumber + 1);
            }

            //Down
            if (row + 1 < _Labyrinth.GetLength(0) &&
                _Labyrinth[row + 1, col] != "x" &&
                _Labyrinth[row + 1, col] != "*" &&
                (_Labyrinth[row + 1, col] == "0" || int.Parse(_Labyrinth[row + 1, col]) > stepNumber + 1))
            {
                Step(row + 1, col, stepNumber + 1);
            }

            //Left
            if (col - 1 >= 0 &&
                _Labyrinth[row, col - 1] != "x" &&
                _Labyrinth[row, col - 1] != "*" &&
                (_Labyrinth[row, col - 1] == "0" || int.Parse(_Labyrinth[row, col - 1]) > stepNumber + 1))
            {
                Step(row, col - 1, stepNumber + 1);
            }

            //Right
            if (col + 1 < _Labyrinth.GetLength(1) &&
                _Labyrinth[row, col + 1] != "x" &&
                _Labyrinth[row, col + 1] != "*" &&
                (_Labyrinth[row, col + 1] == "0" || int.Parse(_Labyrinth[row, col + 1]) > stepNumber + 1))
            {
                Step(row, col + 1, stepNumber + 1);
            }
        }
    }
}