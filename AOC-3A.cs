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
            int[] onesCounter = new int[inputStrings[0].Length];

            for (int i = 0; i < inputStrings.Length; i++)
            {
                int charIndex = 0;
                foreach(char ch in inputStrings[i])
                {
                    if (ch == '1')
                    {
                        onesCounter[charIndex] += 1;
                    }
                    charIndex++;
                }
            }

            string mostCommon = "";
            string leastCommon = "";

            foreach(int s in onesCounter)
            {
                if(s > 500)
                {
                    mostCommon += "1";
                    leastCommon += "0";
                }
                else
                {
                    mostCommon += "0";
                    leastCommon += "1";
                }
            }
            int solution = Convert.ToInt32(mostCommon,2) * Convert.ToInt32(leastCommon,2);
            Console.WriteLine($"{solution}");
            Console.ReadLine();
        }
    }
}
