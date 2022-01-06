using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.LinearDS
{
    public static class _02SortWords
    {
        public static void QuickSort(this string[] numbers)
        {
            QuickSortInternal(numbers, 0, numbers.Length - 1);
        }

        private static void QuickSortInternal(string[] numbers, int left, int right)
        {
            if (left < right)
            {
                var pivotIndex = Partition(numbers, left, right);
                QuickSortInternal(numbers, left, pivotIndex - 1);
                QuickSortInternal(numbers, pivotIndex + 1, right);
            }
        }

        private static int Partition(string[] numbers, int left, int right)
        {
            int i = left;
            string pivot = numbers[right];
            string temp;

            for (int j = left; j <= right; j++)
            {
                if (numbers[j] < pivot)
                {
                    temp = numbers[j];
                    numbers[j] = numbers[i];
                    numbers[i] = temp;
                    i++;
                }
            }

            temp = numbers[right];
            numbers[right] = numbers[i];
            numbers[i] = temp;
            return i;
        }
    }
}
