using System;
using System.Collections.Generic;
using System.IO;

namespace AOC
{ 
    class Program
    {
        

        static void Main(string[] args)
        {
            var inputLines = new List<string>(File.ReadAllText(@"InputHere").Split("\n", StringSplitOptions.RemoveEmptyEntries));
            int points = 0;
            var pointsDict = new Dictionary<string,int>()
            {
                {")" , 3},
                {"]" , 57},
                {"}" , 1197},
                {">" , 25137}
            };

            var openersArray = new string[] {"(", "{", "<", "["};
            foreach(string line in inputLines)
            {
                var lineList = new List<string>();
                foreach(char sign in line)
                {
                    string signString = $"{sign}";
                    foreach(string s in lineList)
                    {
                        Console.Write(s);
                    }
                    Console.WriteLine($" {signString}");
                    if(openersArray.Any(signString.Contains))
                    {
                        lineList.Add(signString);                        
                    } 
                    else
                    {   
                        int prePoints = points;                  
                        switch(signString)
                        {
                            case ")":
                                if(lineList.Last() == "(")
                                {
                                    lineList.RemoveAt(lineList.Count - 1);
                                }
                                else 
                                {
                                    points += pointsDict[signString];
                                    Console.WriteLine($"{signString} was the bad one");
                                }
                                break;

                            case "}":
                                if(lineList.Last() == "{")
                                {
                                    lineList.RemoveAt(lineList.Count - 1);
                                } 
                                else 
                                {
                                    points += pointsDict[signString];
                                    Console.WriteLine($"{signString} was the bad one");
                                }
                                break;

                            case ">":
                                if(lineList.Last() == "<")
                                {
                                    lineList.RemoveAt(lineList.Count - 1);
                                }
                                else 
                                {
                                    points += pointsDict[signString];
                                    Console.WriteLine($"{signString} was the bad one");
                                }
                                break;

                            case "]":
                                if(lineList.Last() == "[")
                                {
                                    lineList.RemoveAt(lineList.Count - 1);
                                }
                                else 
                                {
                                    points += pointsDict[signString];
                                    Console.WriteLine($"{signString} was the bad one");
                                }
                                break;

                            default:
                                break;                            
                        }                 
                        if(prePoints < points)
                        {
                            break;
                        }       
                    }
                    foreach(string s in lineList)
                    {
                        Console.Write(s);
                    }
                    Console.WriteLine();


                }
                  Console.WriteLine(points);             
            }
             
        }
    }
}

    


    
