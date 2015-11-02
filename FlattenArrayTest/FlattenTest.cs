using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntercomCode.Flatten;

namespace FlattenArrayTest
{
    [TestClass]
    public class FlattenTest
    {
        /// <summary>
        /// 1.1 Simple test of 
        /// </summary>
        [TestMethod]
        public void TestJaggedArray()
        {
            int[][] input = new int[][] {
                                        new int[] {1,2},
                                        new int[] {3,4,5},
                                        new int[] {6},
                                        new int[] {7,8,9,10}
                                        };
            int[] expectedResult = new int[] {1,2,3,4,5,6,7,8,9,10};

            var actualResult = Algorithms.RecursiveFlatten(input);
            var actualResultAsArray = actualResult.Cast<int>().ToArray();
            
            CollectionAssert.AreEqual(expectedResult, actualResultAsArray);

            Assert.AreEqual(expectedResult.Length, actualResultAsArray.Length, "Array Lengths Dont Match");
            for (int i = 0; i < expectedResult.Length; i++)
            {
                Assert.AreEqual(expectedResult[i], actualResultAsArray[i], "Array Contents dont match");
            }
                        
        }

        [TestMethod]
        public void Test2DArray()
        {
            int[][] input = new int[][] {
                                        new int[] {1,2},
                                        new int[] {3,4,5},
                                        new int[] {6},
                                        new int[] {7,8,9,10}
                                        };
            int[] expectedResult = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var actualResult = Algorithms.RecursiveFlatten(input);
            var actualResultAsArray = actualResult.Cast<int>().ToArray();

            CollectionAssert.AreEqual(expectedResult, actualResultAsArray);

            Assert.AreEqual(expectedResult.Length, actualResultAsArray.Length, "Array Lengths Dont Match");
            for (int i = 0; i < expectedResult.Length; i++)
            {
                Assert.AreEqual(expectedResult[i], actualResultAsArray[i], "Array Contents dont match");
            }

        }

        [TestMethod]
        public void TestEmptyArray()
        {
            int[][] input = new int[][] {
                                       
                                        };
            int[] expectedResult = new int[] { };

            var actualResult = Algorithms.RecursiveFlatten(input);
            var actualResultAsArray = actualResult.Cast<int>().ToArray();

            CollectionAssert.AreEqual(expectedResult, actualResultAsArray);

            Assert.AreEqual(expectedResult.Length, actualResultAsArray.Length, "Array Lengths Dont Match");
            for (int i = 0; i < expectedResult.Length; i++)
            {
                Assert.AreEqual(expectedResult[i], actualResultAsArray[i], "Array Contents dont match");
            }

        }
        /// <summary>
        /// 1.2
        /// Passing null should throw an exception
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNull()
        {
            int[][] input = null;
           
           
                var actualResult = Algorithms.RecursiveFlatten(input);
                var actualResultAsArray = actualResult.Cast<int>().ToArray();

                Assert.Fail("Exception Expected");
           
        }

    }
}
