namespace DataStructures.Solutions.ListsAndComplexity
{
    public static class _02SortWords
    {
        public static void QuickSort(this string[] arr)
        {
            QuickSortInternal(arr, 0, arr.Length - 1);
        }

        private static void QuickSortInternal(string[] arr, int left, int right)
        {
            if (left < right)
            {
                var pivotIndex = Partition(arr, left, right);
                QuickSortInternal(arr, left, pivotIndex - 1);
                QuickSortInternal(arr, pivotIndex + 1, right);
            }
        }

        private static int Partition(string[] arr, int left, int right)
        {
            int i = left;
            string pivot = arr[right];
            string temp;

            for (int j = left; j <= right; j++)
            {
                if (arr[j].CompareTo(pivot) < 0)
                {
                    temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                    i++;
                }
            }

            temp = arr[right];
            arr[right] = arr[i];
            arr[i] = temp;
            return i;
        }
    }
}
