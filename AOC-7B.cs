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
            int currentLowestFuelUsage = 99999999;
            for(int targetPosition = 0; targetPosition < splitInput.Max(); targetPosition++ )
            {
                int fuelRequired = 0;

                foreach(int currentPosition in splitInput)
                {
                    int amountOfSteps = currentPosition >= targetPosition ? currentPosition - targetPosition : targetPosition - currentPosition;
                    int fuelToBeAdded = 0;
                    for(int step = 0; step <= amountOfSteps; step++)
                    {
                        fuelToBeAdded += amountOfSteps - (amountOfSteps - step);
                    }                
                    fuelRequired += fuelToBeAdded;  
                }
                if(fuelRequired < currentLowestFuelUsage)
                {
                    currentLowestFuelUsage = fuelRequired;                    
                }
            }
            Console.WriteLine($"Answer: {currentLowestFuelUsage}");

        }
    }
}
    
