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
            var mostPopularIndex = new List<int>(Enumerable.Range(0,inputStrings.Length));
            var leastPopularIndex = new List<int>(Enumerable.Range(0,inputStrings.Length));
            

            for(int i = 0; i < inputStrings[0].Length; i++)                
            {
                var oneIndexes = new List<int>();
                var zeroIndexes = new List<int>();

                for (int j = 0; j < mostPopularIndex.Count; j++)
                {
                    if(inputStrings[mostPopularIndex[j]][i] == '1')
                    {
                        oneIndexes.Add(mostPopularIndex[j]);
                    }
                    else
                    {
                        zeroIndexes.Add(mostPopularIndex[j]);
                    }
                }  

                if(mostPopularIndex.Count > 1)
                {
                    mostPopularIndex = oneIndexes.Count >= zeroIndexes.Count ? oneIndexes : zeroIndexes;
                }

                oneIndexes = new List<int>();
                zeroIndexes = new List<int>();

                for (int j = 0; j < leastPopularIndex.Count; j++)
                {
                    if(inputStrings[leastPopularIndex[j]][i] == '1')
                    {
                        oneIndexes.Add(leastPopularIndex[j]);
                    }
                    else
                    {
                        zeroIndexes.Add(leastPopularIndex[j]);
                    }
                }  
                if(leastPopularIndex.Count > 1)
                {
                    leastPopularIndex = oneIndexes.Count < zeroIndexes.Count ? oneIndexes : zeroIndexes;
                }
            }
            Console.WriteLine($"{Convert.ToInt32(inputStrings[mostPopularIndex[0]],2)*(Convert.ToInt32(inputStrings[leastPopularIndex[0]],2))}");
        }
    }
}

