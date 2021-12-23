using System;
using System.Collections.Generic;
using System.IO;

namespace AOC1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputStrings = File.ReadAllLines(@"INPUTHERE");
            int[] inputIntegers = new int[inputStrings.Length];
            List<int> listOfSums = new List<int>();

            for (int i = 0; i < inputStrings.Length; i++)
            {
                inputIntegers[i] = Convert.ToInt32(inputStrings[i]);
            }


            for (int i = 2; i < inputIntegers.Length; i++)
            {
                listOfSums.Add(inputIntegers[i] + inputIntegers[i - 1] + inputIntegers[i - 2]);
            }

            int counter = 0;
            for (int i = 1; i < listOfSums.Count; i++)
            {
                if (listOfSums[i - 1] < listOfSums[i])
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
