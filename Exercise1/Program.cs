using System;
using System.Collections.Generic;

namespace Exercise1
{
    class Program
    {
/*
        that, given an array A of N integers, returns the smallest positive integer (greater than 0) that
        does not occur in A.
         
         For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.
            Given A = [1, 2, 3], the function should return 4.
            Given A = [−1, −3], the function should return 1.
        
        Write an efficient algorithm for the following assumptions:
        ● N is an integer within the range [1..100,000];
        ● each element of array A is an integer within the range [−1,000,000..1,000,000]
        */
        public static int Smallest(int[] numbers)
        {
            HashSet<int> set = new HashSet<int>();
            int index = 1;

            foreach(var number in numbers)
            {
                if(number > 0)
                {
                    set.Add(number);
                }
            }

            while(set.Contains(index))
            {
                index++;
            }

            return index;
        }

        static void Main(string[] args)
        {
            var numbers = new int[]{1,3,6,4,1,2};
            Console.WriteLine("{0}",Smallest(numbers));
        }
    }
}
