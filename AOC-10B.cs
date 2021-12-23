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
            var answersList = new List<string>();
            int scoresIndex = 0;
            var scores = new List<long>();

            var openersArray = new string[] {"(", "{", "<", "["};
            foreach(string line in inputLines)
            {
                var lineList = new List<string>();
                string answerString = "";
                bool corrupted = false;

                foreach(char sign in line)
                {
                    string signString = $"{sign}";
                    if(openersArray.Any(signString.Contains))
                    {
                        lineList.Add(signString);                        
                    } 
                    else
                    {                     
                        switch(signString)
                        {
                            case ")":
                                if(lineList.Last() == "(")
                                {
                                    lineList.RemoveAt(lineList.Count - 1);
                                }
                                else
                                {
                                    corrupted = true;
                                }
                                break;

                            case "}":
                                if(lineList.Last() == "{")
                                {
                                    lineList.RemoveAt(lineList.Count - 1);
                                }
                                else
                                {
                                    corrupted = true;
                                }

                                break;

                            case ">":
                                if(lineList.Last() == "<")
                                {
                                    lineList.RemoveAt(lineList.Count - 1);
                                }
                                else
                                {
                                    corrupted = true;
                                }
                                break;

                            case "]":
                                if(lineList.Last() == "[")
                                {
                                    lineList.RemoveAt(lineList.Count - 1);
                                }
                                else
                                {
                                    corrupted = true;
                                }
                                break;

                            default:
                                break;                            
                        }    
                    }
                    answerString = "";
                    foreach(string s in lineList)
                    {
                        answerString += s;
                    } 
                }
                if(corrupted == false)
                {
                   answersList.Add(answerString);      
                }
            }

            

            foreach(string ans in answersList)
            {   
                long totalScore = 0;

                for(int i = 1; i <= ans.Length; i ++)
                {
                    int index = ans.Length - i;
                    switch(Convert.ToString(ans[index]))
                    {
                        case "(":
                            totalScore = 5 * totalScore + 1;
                            break;
                        case "[":
                            totalScore = 5 * totalScore + 2;                        
                            break;
                        case "{":
                            totalScore = 5 * totalScore + 3;
                            break;
                        case "<":
                            totalScore = 5 * totalScore + 4;
                            break;
                    }                    
                }
                scores.Add(totalScore);
            }
            scores.Sort();
            foreach(long element in scores)
            {
                Console.WriteLine(element);
            }
            scoresIndex = (scores.Count - 1) / 2;
            Console.WriteLine(scores[scoresIndex]);
             
        }
    }
}

    


    
