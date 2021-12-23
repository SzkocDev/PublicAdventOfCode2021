using System;
using System.Collections.Generic;
using System.IO;

namespace AOC
{ 
    class WorkClass
    {
        public WorkClass(int[,] all, int[,] low)
        {
            allPointsArray = all;
            lowPointsArray = low;
        }
        public int[,] allPointsArray {get;set;}
        public int[,] lowPointsArray {get;set;} //also ignored
        public List<int> answersList = new List<int>();

        public void Print(int[,] array)
        {
            for(int y = 0; y < array.GetLength(1); y++)
            {
                for(int x = 0; x < array.GetLength(0); x++)
                {
                    string str = $"{array[x,y]}";
                    if(lowPointsArray[x,y] == 99)
                    {
                        str = "*";             
                    }
                    Console.Write(str);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public int CheckNearby(int x, int y)
        {
            int[] compareValuesX = {x + 1, x - 1};
            int[] compareValuesY = {y + 1, y - 1};
            int answerSum = 0;
            foreach(int value in compareValuesX)
            {
                if(value >= 0 && allPointsArray.GetLength(0) > value )
                {
                    if(allPointsArray[value,y] > allPointsArray[x,y] && allPointsArray[value,y] != 9 && lowPointsArray[value,y] == 99)
                    {
                        lowPointsArray[value,y] = allPointsArray[value,y];
                        answerSum++;
                        answerSum += CheckNearby( value, y);
                    }
                }
            }
            foreach(int value in compareValuesY)
            {856716
                if(value >= 0 && allPointsArray.GetLength(1) > value )
                {
                    if(allPointsArray[x,value] > allPointsArray[x,y] && allPointsArray[x,value] != 9 && lowPointsArray[x,value] == 99)
                    {
                       lowPointsArray[x,value] = allPointsArray[x,value];
                       answerSum++;
                       answerSum += CheckNearby( x, value);
                    }
                }
            } 
        return answerSum;
        }

    }
    class Program
    {  
        static void Main(string[] args)
        {
            var inputLines = new List<string>(File.ReadAllText(@"INPUTHERE").Split("\n", StringSplitOptions.RemoveEmptyEntries));
            var allArray = new int[inputLines[0].Length,inputLines.Count];
            var lowArray = new int[inputLines[0].Length,inputLines.Count];            

            for(int y = 0; y < inputLines.Count; y++)
            {
                for(int x = 0; x < inputLines[0].Length; x++)
                {
                    int currentValue = int.Parse(inputLines[y][x].ToString());                    
                    int[] compareValuesX = {x + 1, x - 1};
                    int[] compareValuesY = {y + 1, y - 1};
                    lowArray[x,y] = 99;
                    allArray[x,y] = currentValue;
                    int passedCounter = 0;
                    int lowCounter = 0;

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
                        lowArray[x,y] = currentValue; 
                    }  
                } 
            }
            var operationClass = new WorkClass(allArray, lowArray);
            operationClass.Print(allArray);
            for(int y = 0; y < operationClass.allPointsArray.GetLength(1); y++)
            {
                for(int x = 0; x < operationClass.allPointsArray.GetLength(0); x++)
                {
                    if(operationClass.lowPointsArray[x,y] == operationClass.allPointsArray[x,y])
                    {
                        var ans = operationClass.CheckNearby(x, y);
                        if(ans > 0)
                        {
                            ans++;
                            operationClass.answersList.Add(ans);
                        }
                    }
                }
            }
            //mess, should rewrite all later 15.12.2021
            operationClass.Print(operationClass.lowPointsArray);
            operationClass.answersList.Sort();
            int answer = operationClass.answersList[operationClass.answersList.Count - 1] * operationClass.answersList[operationClass.answersList.Count - 2] * operationClass.answersList[operationClass.answersList.Count - 3];   
            Console.WriteLine(answer);         
        }
    }
}
    
