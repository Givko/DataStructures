using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Solutions.Fundamentals.ListsAndComplexity
{
    public static class _05CountOfOccurences
    {
        public static Dictionary<int, int> CountOfOccurences(this int[] numbers)
        {
            List<int> countedNumbers = new List<int>();
            Dictionary<int, int> occurences = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentOccurences = 1;
                if (countedNumbers.Contains(numbers[i]))
                    continue;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] == numbers[i])
                        currentOccurences++;
                }

                occurences.Add(numbers[i], currentOccurences);
                countedNumbers.Add(numbers[i]);
            }

            return occurences;
        }
    }
}
