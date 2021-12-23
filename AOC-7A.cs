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
            int currentLowestFuelUsage = 999999;
            for(int targetPosition = 0; targetPosition < splitInput.Max(); targetPosition++ )
            {            
                int fuelRequired = 0;

                foreach(int currentPosition in splitInput)
                {
                    fuelRequired = currentPosition >= targetPosition ? fuelRequired + (currentPosition - targetPosition) : fuelRequired + (targetPosition - currentPosition);
                }
                if(fuelRequired < currentLowestFuelUsage)
                {
                    currentLowestFuelUsage = fuelRequired;                    
                }
                Console.WriteLine($"{fuelRequired}");


            }
            Console.WriteLine($"Answer: {currentLowestFuelUsage}");

        }
    }
}
    
