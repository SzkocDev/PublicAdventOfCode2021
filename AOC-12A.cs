using System;
using System.Collections.Generic;
using System.IO;

namespace AOC
{ 
    class Map
    {  
        public List<string> listPoints = new List<string>();
        public List<List<string>> connectionsList = new List<List<string>>();
        int numberOfPaths = 0;

        public Map(List<string> inputArray)
        {
            foreach(string arr in inputArray)
            {
                string[] point = arr.Split("-");

                if(listPoints.Contains(point[0]) == false)
                {
                    listPoints.Add(point[0]);
                }
                if(listPoints.Contains(point[1]) == false)
                {
                    listPoints.Add(point[1]);
                }
            }

            for(int index = 0; index < listPoints.Count; index ++)
            {
                var workList = new List<string>();
                foreach(string input in inputArray)
                {
                    var workString = input.Split("-");
                    if(workString[0] == listPoints[index])
                    {
                        workList.Add(workString[1]);
                    }
                    else if(workString[1] == listPoints[index])
                    {
                        workList.Add(workString[0]);
                    }
                }
                connectionsList.Add(workList);
            }
        }

        public void LookForPathsFrom(string start, List<string> usedPoints)
        {
            usedPoints.Add(start);           
            
            if(start == "end")
            {   
                numberOfPaths += 1;
                WritePath(usedPoints);
            }
            else
            {
                int indexOfCurrentPoint = listPoints.IndexOf(start);
                var availablePoints = new List<string>(connectionsList[indexOfCurrentPoint]);                

                foreach(string usedPoint in usedPoints)
                {
                    if(availablePoints.Contains(usedPoint) && Char.IsUpper(usedPoint[0]) == false)
                    {
                        availablePoints.Remove(usedPoint);
                    }                
                }

                foreach(string availablePoint in availablePoints)
                {
                    var passUsedPoint = new List<string>(usedPoints);
                    LookForPathsFrom(availablePoint, passUsedPoint);
                }

            }
        }
        public void WritePath(List<string> usedPoints)
        {
            foreach(string usedPoint in usedPoints)
            {
                Console.Write($"{usedPoint},");
            }
            Console.WriteLine($" {numberOfPaths}");
        }
    }
    
       
    class Program
    {      

        static void Main(string[] args)
        {
            var inputLines = new List<string>(File.ReadAllText(@"INPUT").Split("\n", StringSplitOptions.RemoveEmptyEntries));
            
            Map gameMap = new Map(inputLines); 

            for(int index = 0; index < gameMap.listPoints.Count; index ++)
            {
                Console.WriteLine($"Connections of {gameMap.listPoints[index]} are:");
                foreach(string element in gameMap.connectionsList[index])
                {
                    Console.Write($"{element}, ");
                }
                Console.WriteLine();
                Console.WriteLine("---------------");
            }

            gameMap.LookForPathsFrom("start",new List<string>());

        }
    }
}


    


    
