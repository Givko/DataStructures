namespace DataStructures.Solutions.Fundamentals.ListsAndComplexity
{
    public static class _01SumAndAverage
    {

        public static void SumAndAverage(this string[]? input)
        {
            if (input == null || input.Length == 0)
            {
                Console.WriteLine("Sum=0; Average=0.00");
                return;
            }

            double sum = 0;
            for (int i = 0; i < input!.Length; i++)
            {
                sum += int.Parse(input[i]);
            }

            var average = sum / input.Length;
            Console.WriteLine($"Sum={sum}; Average={average:0.00}");
        }
    }
}
