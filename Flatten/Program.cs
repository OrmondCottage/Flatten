using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace IntercomCode.Flatten
{
    class Program
    {
        static void Main(string[] args)
        {
           

            int[][] test1 = new int[][] {
                                        new int[] {1,2},
                                        new int[] {3,4,5},
                                        new int[] {6},
                                        new int[] {7,8,9,10}
                                        };

            
            var flattened = Algorithms.RecursiveFlatten(test1);
        
            var resultAsArray = flattened.Cast<int>().ToArray();


            for (int i = 0; i < resultAsArray.Length; i++)
            {
                Console.WriteLine("FlattenedArray[{0}] = {1}", i, resultAsArray[i]);
            }
        }

    }
}
