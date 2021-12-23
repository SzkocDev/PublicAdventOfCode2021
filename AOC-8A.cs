using System;
using System.Collections.Generic;
using System.IO;

namespace AOC
{ 
    class Program
    {
        static void Main(string[] args)
        {
            var inputLines = new List<string>(File.ReadAllText(@"INPUTHERE").Split("\n",StringSplitOptions.RemoveEmptyEntries));
            var workValues = new List<string[]>();
            foreach(string value in inputLines)
            {
                workValues.Add(value.Split(" | ")[1].Split(" "));
            }

            int ones = 0, fours = 0, sevens = 0, eights = 0, others = 0;

            foreach(string[] valueArrays in workValues)
            {
                foreach(string value in valueArrays)
                {
                    switch(value.Length)
                    {
                    case 2:
                        ones++;
                        break;
                    case 4:
                        fours++;
                        break;
                    case 3:
                        sevens++;
                        break;
                    case 7:
                        eights++;
                        break;
                    default:
                        others++;
                        break;
                    }
                }
            }
            Console.WriteLine($"Sum:{ones + fours + sevens + eights} 1:{ones} 4:{fours} 7:{sevens} 8:{eights} others:{others}");
        }
    }
}
    
