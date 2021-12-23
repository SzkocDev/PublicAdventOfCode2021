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
            int forward = 0;
            int down = 0;
            for (int i = 0; i < inputStrings.Length; i++)
            {
                string[] currentLine = inputStrings[i].Split(' ');
                int movementInt = Convert.ToInt32(currentLine[1]);

                switch (currentLine[0])
                {
                    case "forward":
                        forward += movementInt;
                        break;
                    case "up":
                        down -= movementInt;
                        break;
                    case "down":
                        down += movementInt;
                        break;
                    default:
                        Console.WriteLine("Wrong case!");
                        break;
                }
            }
            int solution = forward * down;
            Console.WriteLine(solution);
            Console.ReadLine();
        }
    }
}
