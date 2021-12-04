using Microsoft.VisualStudio.TestTools.UnitTesting;
using AOC;
using AOC._2021.Extensions;
using System.Text;
using System;

namespace Tests
{
    [TestClass]
    public class Day3Tests
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] input = new[] { "00100", "11110", "10110",
                                    "10111", "10101", "01111",
                                    "00111", "11100", "10000",
                                    "11001", "00010", "01010" };
             var lineLength = input[0].Length;

            var gammaBits = new StringBuilder(lineLength);
            var epsilonBits = new StringBuilder(lineLength);
           

            for (int i = 0; i < lineLength; i++)
            {
                var mostCommon = MostCommon(i, input);
                gammaBits.Append(mostCommon);

                var leastCommon = LeastCommon(i, input);
                epsilonBits.Append(leastCommon);
            }

            var gamma = gammaBits.BinaryToDecimal();
            var epsilon = epsilonBits.BinaryToDecimal();
            var total = gamma * epsilon;

            Assert.AreEqual(total, 198);
        }

        private static char? MostCommon(int index, string[] bits)
        {
            var countZero = 0;
            var countOne = 0;
            foreach (var item in bits)
            {
                switch (item[index])
                {
                    case '0':
                        countZero += 1;
                        break;
                    default:
                        countOne += 1;
                        break;
                }
            }

            return countOne == countZero ? null : countOne > countZero ? '1' : '0';
        }

        private static char? LeastCommon(int index, string[] bits)
        {
            var countZero = 0;
            var countOne = 0;
            foreach (var item in bits)
            {
                switch (item[index])
                {
                    case '0':
                        countZero += 1;
                        break;
                    default:
                        countOne += 1;
                        break;
                }
            }
            return countOne == countZero ? null : countOne > countZero ? '0' : '1';
        }
    }
}