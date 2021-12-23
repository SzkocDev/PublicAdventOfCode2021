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
            var fishList = new long[9];
            long days = 256;

            foreach(int input in splitInput)
            {
                switch(input)
                {
                case 1:                
                    fishList[1]++;
                    break;                
                case 2:   
                    fishList[2]++;
                    break;
                case 3:   
                    fishList[3]++;
                    break;
                case 4:                 
                    fishList[4]++;
                    break;                
                default:                
                    fishList[5]++;
                    break;  
                }
            }
            for(int day = 1; day <= days; day++)
            {
                long youngAndOld = fishList[0];
                fishList[0] = fishList[1];
                fishList[1] = fishList[2];
                fishList[2] = fishList[3];
                fishList[3] = fishList[4];
                fishList[4] = fishList[5];
                fishList[5] = fishList[6];
                fishList[6] = fishList[7] + youngAndOld;
                fishList[7] = fishList[8];
                fishList[8] = youngAndOld;
            }   
            long sum = fishList[0] + fishList[1] + fishList[2] + fishList[3] + fishList[4] +fishList[5] + fishList[6] + fishList[7] + fishList[8];
            Console.WriteLine($"0:{fishList[0]} 1:{fishList[1]} 2:{fishList[2]} 3:{fishList[3]} 4:{fishList[4]} 5:{fishList[5]} 6:{fishList[6]} 7:{fishList[7]} 8:{fishList[8]}  Answer: {sum}");

        }
    }
}
