using System;
using System.Collections.Generic;
using System.IO;

namespace AOC1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputStrings = File.ReadAllLines(@"INPUT");
            int forward = 0;
            int down = 0;
            int aim = 0;
            for (int i = 0; i < inputStrings.Length; i++)
            {
                string[] currentLine = inputStrings[i].Split(' ');
                int movementInt = Convert.ToInt32(currentLine[1]);

                switch (currentLine[0])
                {
                    case "forward":
                        forward += movementInt;
                        down += movementInt * aim;
                        break;
                    case "up":
                        aim -= movementInt;
                        break;
                    case "down":
                        aim += movementInt;
                        break;
                    default:
                        Console.WriteLine("Wrong case!");
                        break;
                }
                Console.WriteLine($"{currentLine[0]}-{currentLine[1]} F:{forward} D: {down} A: {aim}");
            }
            int solution = forward * down;
            Console.WriteLine(solution);
            Console.ReadLine();
        }
    }
}
