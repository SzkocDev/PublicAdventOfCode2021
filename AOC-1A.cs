using System;
using System.IO;

namespace AOC1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputStrings = File.ReadAllLines(@"INPUTHERE");
            int[] inputIntegers = new int[inputStrings.Length];
            for (int i = 0; i < inputStrings.Length; i++)
            {
                inputIntegers[i] = Convert.ToInt32(inputStrings[i]);
            }

            int counter = 0;
            for(int i = 1; i < inputIntegers.Length; i++)
            {
                if(inputIntegers[i-1] < inputIntegers[i])
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
