using System;
using System.Collections.Generic;
using System.IO;

namespace AOC
{ 
    class Program
    {  
        
        static void Main(string[] args)
        {
            var inputLines = new List<string>(File.ReadAllText(@"INPUTHERE").Split("\n", StringSplitOptions.RemoveEmptyEntries));
            int riskScoreSum = 0;

            for(int y = 0; y < inputLines.Count; y++)
            {
                for(int x = 0; x < inputLines[0].Length; x++)
                {
                    int currentValue = int.Parse(inputLines[y][x].ToString());
                    int[] compareValuesX = {x + 1, x - 1};
                    int[] compareValuesY = {y + 1, y - 1};

                    int passedCounter = 0;
                    int lowCounter = 0;            
                    string display = $"{currentValue}";

                    foreach(int value in compareValuesX)
                    {
                        if(value >= 0 && inputLines[0].Length > value)
                        {
                            passedCounter++;
                            if(int.Parse(inputLines[y][value].ToString()) > currentValue)
                            {
                                lowCounter++;
                            }
                        }
                    }
                    foreach(int value in compareValuesY)
                    {
                        if(value >= 0 && inputLines.Count > value)
                        {
                            passedCounter++;
                            if(int.Parse(inputLines[value][x].ToString()) > currentValue)
                            {
                                lowCounter++;                                
                            }
                        }
                    }
                    if(lowCounter == passedCounter)
                    { 
                        display = "*";
                        riskScoreSum += currentValue + 1;                        
                    }  
                    Console.Write(display);
                }           
               Console.WriteLine();
            }
         Console.WriteLine(riskScoreSum);
        }
    }
}
    
