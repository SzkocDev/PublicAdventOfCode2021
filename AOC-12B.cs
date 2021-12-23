using System;
using System.Collections.Generic;
using System.IO;

namespace AOC
{ 
    class Map
    {  
        public List<string> listPoints = new List<string>();
        public List<List<string>> connectionsList = new List<List<string>>();
        public List<string> localPaths = new List<string>();
        int numberOfPaths = 0;

        public Map(List<string> inputArray, string smallCave)
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
            listPoints.Add($"{smallCave}double");

            for(int index = 0; index < listPoints.Count; index ++)
            {
                var workList = new List<string>();
                foreach(string input in inputArray)
                {
                    var workString = input.Split("-");
                    if(workString[0] == listPoints[index])
                    {
                        workList.Add(workString[1]);
                        if(workString[1] == smallCave)
                        {
                            workList.Add(listPoints[listPoints.Count - 1]);
                        }
                    }
                    else if(workString[1] == listPoints[index])
                    {
                        workList.Add(workString[0]);
                        if(workString[0] == smallCave)
                        {
                            workList.Add(listPoints[listPoints.Count - 1]);
                        }
                    }
                }
                connectionsList.Add(workList);
            }

            connectionsList[connectionsList.Count - 1] = connectionsList[listPoints.IndexOf(smallCave)];
            for(int i = 0; i < connectionsList.Count; i++)
            {
                Console.Write($"{listPoints[i]}- ");
                for(int j = 0; j < connectionsList[i].Count; j++)
                {
                    Console.Write($"{connectionsList[i][j]},");
                }
                Console.WriteLine();
            }
        }

        public void LookForPathsFrom(string start, List<string> usedPoints)
        {
            usedPoints.Add(start);           
            
            if(start == "end")
            {   
                if(localPaths.Contains(WritePath(usedPoints)) == false)
                {
                    localPaths.Add(WritePath(usedPoints));
                }
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
        public string WritePath(List<string> usedPoints)
        {
            string workLine = "";
            foreach(string usedPoint in usedPoints)
            {
                workLine += $"{usedPoint},".Replace("double","");
            }
            return workLine;
        }
    }
    
       
    class Program
    {

        static void Main(string[] args)
        {
            var inputLines = new List<string>(File.ReadAllText(@"INPUT").Split("\n", StringSplitOptions.RemoveEmptyEntries));
            var inputSplitSC = new List<string>();
            List<string> paths = new List<string>(); 

            foreach(string line in inputLines)
            {
                string[] split = line.Split("-");
                if(Char.IsUpper(split[0][0]) == false && split[0] != "start" & split[0] != "end" && inputSplitSC.Contains(split[0]) == false)
                {
                    inputSplitSC.Add(split[0]);
                }
                else if(Char.IsUpper(split[1][0]) == false && split[1] != "start" & split[1] != "end" && inputSplitSC.Contains(split[1]) == false)
                {
                    inputSplitSC.Add(split[1]);
                }
            }

            foreach(string smallCave in inputSplitSC)
            {
                Console.WriteLine(smallCave);
                Console.WriteLine();
                Map gameMap = new Map(inputLines, smallCave);
                Console.WriteLine();
                gameMap.LookForPathsFrom("start",new List<string>());  
                foreach(string path in gameMap.localPaths)
                {
                    if(paths.Contains(path) == false)
                    {
                        Console.WriteLine(path);
                        paths.Add(path);
                    }
                }         
                Console.WriteLine();     
            }
            Console.WriteLine(paths.Count);

        }
    }
}


    


    
