using System;
using System.Collections.Generic;
using System.IO;

namespace AOC
{ 
    class Program
    {   
        static string[] SortArray(string[] input)
        {  
            string[] array = input.OrderBy(x => x.Length).ToArray();
            return array;
        }

        static string SortString(string str)
        {
            char[] ch = str.ToArray();
            Array.Sort(ch);
            return new string(ch);
        }

        static bool CompareStrings(string value, string dictionaryValue)
        {
            char[] dictArray = dictionaryValue.ToCharArray();
            char[] valueArray = value.ToCharArray();
            int counter = 0;

            foreach(char ch in dictArray)
            {
                if(valueArray.Contains(ch))
                {
                    counter++;
                }
            }
            if(counter == dictArray.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static Dictionary<string, int> CreateDecodedDict(string[] inputArray)
        {
            var workDict = new Dictionary<string, int>()
            {
                {SortString(inputArray[0]), 1},
                {SortString(inputArray[1]), 7},
                {SortString(inputArray[2]), 4},
                {SortString(inputArray[9]), 8}
            };
            string fourWithoutOne = inputArray[2];
            foreach(char ch in inputArray[0].ToCharArray())
            {
               fourWithoutOne = fourWithoutOne.Replace($"{ch}", "");
            }

            foreach(string value in inputArray)
            {
                string sortedValue = SortString(value);
                if(value.Length == 6)
                {
                    if(CompareStrings(sortedValue, workDict.ElementAt(2).Key))
                    {
                        workDict.Add(sortedValue, 9);
                    }
                    else if(CompareStrings(value, fourWithoutOne))
                    {
                        workDict.Add(sortedValue, 6);
                    }
                    else
                    {
                        workDict.Add(sortedValue, 0);
                    }
                }
                if(value.Length == 5)
                {
                    if(CompareStrings(sortedValue, workDict.ElementAt(0).Key))
                    {
                        workDict.Add(sortedValue,3);
                    }
                    else if(CompareStrings(sortedValue, fourWithoutOne))
                    {
                        workDict.Add(sortedValue,5);
                    }
                    else 
                    {
                        workDict.Add(sortedValue,2);
                    }
                } 
            }
            return workDict;
         }
        static void Main(string[] args)
        {
            var inputLines = new List<string>(File.ReadAllText(@"INPUTHERE").Split("\n",StringSplitOptions.RemoveEmptyEntries));
            var answerLines = new List<string[]>();
            var valueLinesEncoded = new List<string[]>();
            var valueLinesDicts = new List<Dictionary<string, int>>();
            int solution = 0;
            foreach(string value in inputLines)
            {
                valueLinesEncoded.Add(SortArray(Array.ConvertAll(value.Split(" | ")[0].Split(" "), x => SortString(x))));
                answerLines.Add(Array.ConvertAll(value.Split(" | ")[1].Split(" "), x => SortString(x)));
            }    

            foreach(string[] encodedValueArray in valueLinesEncoded)
            {
                valueLinesDicts.Add(CreateDecodedDict(encodedValueArray));
            }
            
            for(int index = 0; index < answerLines.Count; index++)
            {
                string[] arr = answerLines[index];
                Console.WriteLine($"{valueLinesDicts[index][arr[0]]}{valueLinesDicts[index][arr[1]]}{valueLinesDicts[index][arr[2]]}{valueLinesDicts[index][arr[3]]}");
                solution += Convert.ToInt32($"{valueLinesDicts[index][arr[0]]}{valueLinesDicts[index][arr[1]]}{valueLinesDicts[index][arr[2]]}{valueLinesDicts[index][arr[3]]}");
            }
            Console.WriteLine($"Answer: {solution}");
        }
    }
}
    
