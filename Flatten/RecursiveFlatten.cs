
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntercomCode.Flatten
{
    public class Algorithms
    {
        /// <summary>
        /// Recursive function to flatten a jagged array
        /// e.g. 
        /// [{1,2}, {3,4,5}, {6}, {7,8,9,10}] -> [1,2,3,4,5,6,7,8,9,10]
        /// </summary>
        /// <param name="jaggedArray"></param>
        /// <returns></returns>
        public static IEnumerable RecursiveFlatten(IEnumerable jaggedArray)
        {
            // Normally we'd surround in try/catch but that doesnt work with yield so...
            if (null == jaggedArray)
            {
                throw new ArgumentNullException("jaggedArray");
            }

            foreach (var item in jaggedArray)
            {
                if (item is IEnumerable)
                {
                    foreach (var subitem in RecursiveFlatten((IEnumerable)item))
                    {
                        yield return subitem ;
                    }
                }
                else
                {
                    //it's an int
                    yield return item;
                }
            }
        }
       
   }
}
