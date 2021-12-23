using System;
using System.Collections.Generic;
using System.IO;

namespace AOC1
{

    class Program
    {
        static void Main(string[] args)
        {
            var splitInput = new List<int>(Array.ConvertAll(File.ReadAllText(@"INPUT").Split(","),x => Convert.ToInt32(x)));
            var fishList = new List<int>();
            int fishesToSpawn = 0;
            int days = 80;

            foreach(int input in splitInput)
            {
                fishList.Add(input);
            }
            for(int day = 1; day <= days; day++)
            {
                var exportList = new List<int>(fishList);
                for(int fishid = 0; fishid < fishList.Count; fishid++)
                {       
                    if(exportList[fishid] == 0)
                    {
                        exportList[fishid] = 7;
                        exportList.Add(8);
                    }
                    exportList[fishid] = exportList[fishid] - 1;
                }
                fishList = exportList;

                string test = $"After {day}:{fishList.Count}";

                Console.WriteLine(test);
            }
            
        }
    }
}
