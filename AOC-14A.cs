using System;
using System.Collections.Generic;
using System.IO;

namespace AOC
{ 
    class Strain
    {
        public string template;
        Dictionary<string,string> pairsDict;

        public Strain(Dictionary<string,string> inputDict, string inputTemplate)
        {
            template = inputTemplate;
            pairsDict = inputDict;
        }

        public void Insert(int amountOfCycles)
        {

            for(int cycle = 0; cycle < amountOfCycles; cycle++)
            {
                string workTemplate = "";
                for(int i = 0 ; i < template.Length - 1 ; i++)
                {

                    string pair = $"{template[i]}{template[i+1]}";
                    string pairAdded = i == 0 ? $"{template[i]}{pairsDict[pair]}{template[i+1]}" : $"{pairsDict[pair]}{template[i+1]}";
                    workTemplate += pairAdded;
                }
                template = workTemplate;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var inputLines = new List<string>(File.ReadAllText(@"INPUT").Split("\n", StringSplitOptions.RemoveEmptyEntries));
            var pairsDict = new Dictionary<string,string>();
            var countDict = new Dictionary<char,int>();
            string template = inputLines[0];
            Strain strain;

            foreach(string line in inputLines)
            {
                if(line.Contains(" -> "))
                {
                   var splitLine = line.Split(" -> ");
                   pairsDict.Add(splitLine[0],splitLine[1]); 
                }                
            }
            strain = new Strain(pairsDict, template);
            strain.Insert(10);

            foreach(char templateChar in strain.template)
            {
                if(countDict.ContainsKey(templateChar))
                {
                    countDict[templateChar] += 1;
                }
                else
                {
                    countDict.Add(templateChar, 1);
                }
            }
            
            int lowestValue = 9999;
            int highestValue = 0;
            foreach(KeyValuePair<char, int> pair in countDict)
            {
                Console.WriteLine(pair.Value);
                lowestValue = lowestValue < pair.Value ? lowestValue : pair.Value;
                highestValue = highestValue > pair.Value ? highestValue : pair.Value;
            }
            Console.WriteLine($"{highestValue - lowestValue}");
        }
    }
}


    


    
