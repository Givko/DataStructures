using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Solutions.Fundamentals.StacksAndQueues
{
    public static class CalculateSequenceWithQueue
    {
        //• S1 = N
        //• S2 = S1 + 1
        //• S3 = 2*S1 + 1
        //• S4 = S1 + 2
        //• S5 = S2 + 1
        //• S6 = 2*S2 + 1
        //• S7 = S2 + 2

        public static int[] CalculateSequence(int n)
        {
            var queue = new Queue<int>();
            queue.Enqueue(n);
            var result = new int[50];
            for (int i = 0; i < result.Length; i++)
            {
                var s = queue.Dequeue();
                result[i] = s;
                queue.Enqueue(s + 1);
                queue.Enqueue(2 * s + 1);
                queue.Enqueue(s + 2);
            }

            return result;
        }
    }
}
