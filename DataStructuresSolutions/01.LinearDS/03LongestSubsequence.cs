using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.LinearDS
{
    public static class _03LongestSubsequence
    {
        public static (int occurences, int number) LongestSubsequence(this int[] numbers)
        {
            List<int> countedNumbers = new List<int>();
            int maxOccurences = 1;
            int maxOccuredNumber = numbers[0];

            for (int i = 1; i < numbers.Length - 1; i++)
            {
                int currentOccurences = 1;
                if (countedNumbers.Contains(numbers[i]))
                    continue;

                for (int j = i + 1; j < numbers.Length - 1; j++)
                {
                    if (numbers[j] == numbers[i])
                        currentOccurences++;
                }

                if (maxOccurences < currentOccurences)
                {
                    maxOccurences = currentOccurences;
                    maxOccuredNumber = numbers[i];
                }

                countedNumbers.Add(numbers[i]);
            }

            return (maxOccurences, maxOccuredNumber);
        }
    }
}
