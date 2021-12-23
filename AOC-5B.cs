using System;
using System.Collections.Generic;
using System.IO;

namespace AOC1
{
    class HydroventLine
    {
        public HydroventLine(string inputLine,int[,] map)
        {
            string[] workElements = inputLine.Split(" -> ");
            x1 = Convert.ToInt32(workElements[0].Split(",")[0]);
            y1 = Convert.ToInt32(workElements[0].Split(",")[1]);
            x2 = Convert.ToInt32(workElements[1].Split(",")[0]);
            y2 = Convert.ToInt32(workElements[1].Split(",")[1]);

            if(x1 == x2)
            {
                int biggerY = y1 > y2 ? y1 : y2;
                int smallerY = biggerY == y1 ? y2 : y1;
                for(int counter = smallerY; counter <= biggerY; counter++)
                {
                    WriteToMap(map, x1, counter);
                }
            }
            else if(y1 == y2)
            {
                int biggerX = x1 > x2 ? x1 : x2;
                int smallerX = biggerX == x1 ? x2 : x1;
                for(int counter = smallerX; counter <= biggerX; counter++)
                {
                    WriteToMap(map, counter, y1);
                }
            }
            else
            {
                int steps = x1 > x2 ? x1 - x2 : x2 - x1;
                int directionX = x1 > x2 ? -1 : 1;
                int directionY = y1 > y2 ? -1 : 1;
                for(int step = 0; step <= steps ; step++)
                {
                    WriteToMap(map, x1 + step * directionX, y1 + directionY * step);
                }
            }

            static void WriteToMap(int[,] map,int x, int y)
            {
                map[x,y] = map[x,y] + 1;
            }
        }
        public int x1 {get;set;}
        public int y1 {get;set;}
        public int x2 {get;set;}
        public int y2 {get;set;}
    }

    class Program
    {        

        static void Main(string[] args)
        {
            var splitInput = new List<String>(File.ReadAllText(@"/INPUTHERE").Split("\n"));
            var hydroventLineList = new List<HydroventLine>();
            var ventMapArray = new int[2111,2111];
            foreach (var line in new List<string>(splitInput))
            {
                if(line == "")
                {
                    splitInput.Remove(line);
                }
                else
                {
                   hydroventLineList.Add(new HydroventLine(line, ventMapArray));                   
                }
            }          
            int solution = 0;
            foreach(int value in ventMapArray)
            {
                if (value >= 2)
                {
                    solution++;
                }
            }
            Console.WriteLine($"Solution is:{solution}");
        }
    }
}
