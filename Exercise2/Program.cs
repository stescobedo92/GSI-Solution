using System;

namespace Exercise2
{
    class Program
    {
        /*
        Find the bug(s) and modify one line on the incorrect implementation of the function solution that
        is supposed to return the smallest the element on the given non-empty list "numbers" which
        contains at most 1000 integers within the range [-1000..1000]
        Notice that the example test case "var numbers = <int>[-1, 1, -2, 2];" the attached code is
        already returning the correct answer (-2)        
        */
        public static int FindSmallest(int[] numbers){
            int small = numbers[0];
            for(int i = 1; i < numbers.Length;i++){
                if(numbers[i] < small ){
                    small = numbers[i];
                }
            }

            return small;
        }

        static void Main(string[] args)
        {
            var numbers = new int[]{-1,1,-2,2};
            Console.WriteLine("{0}",FindSmallest(numbers));
        }
    }
}
