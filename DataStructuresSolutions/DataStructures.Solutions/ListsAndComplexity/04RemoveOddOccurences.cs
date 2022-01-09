using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Solutions
{
    public static class _04RemoveOddOccurences
    {
        public static List<int> RemoveOddOccurences(this int[] numbers)
        {
            List<int> countedNumbers = new List<int>();
            List<int> evenOccurences = new List<int>();
            
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

                if (currentOccurences % 2 == 0)
                {
                    for (int k = 0; k < currentOccurences; k++)
                    {
                        evenOccurences.Add(numbers[i]);
                    }
                }

                countedNumbers.Add(numbers[i]);
            }

            return evenOccurences;
        }
    }
}
