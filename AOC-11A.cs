using System;
using System.Collections.Generic;
using System.IO;

namespace AOC
{ 
    class Matrix
    {
        public int[,] matrixArr = new int[10,10];
        public int[,] flashedArr = new int[10,10];
        public int flashes = 0;
        public Matrix(int[,] matrix)
        {
            matrixArr = matrix;
        }
        public void AddOne()
        {
            for(int y = 0; y < matrixArr.GetLength(1); y++)
            {
                for(int x = 0; x < matrixArr.GetLength(0); x++)
                {
                    matrixArr[x,y] += 1;
                }  
            }
        }
        public void Flash()
        {
            for(int y = 0; y < matrixArr.GetLength(1); y++)
            {
                for(int x = 0; x < matrixArr.GetLength(0); x++)
                {
                    if(matrixArr[x,y] >= 9)
                    {
                        flashedArr[x,y] = 99;                        

                        for(int ynew = -1; ynew < 2; ynew++)
                        {
                            for(int xnew = -1; xnew < 2; xnew++)
                            {
                                if(0 <=  xnew + x &&  xnew + x <=9 && 0 <= ynew + y && ynew + y <=9)
                                {
                                    matrixArr[xnew + x, ynew + y] += 1;
                                }
                            }

                        }
                        matrixArr[x,y] = 0; 

                    }  
                
                }
            }
            foreach(int element in matrixArr)
            {
                if(element >= 9)
                {
                    Flash();
                }
            }
       
        }
        public void CleanHouse()
        {
            for(int y = 0; y < flashedArr.GetLength(1); y++)
            {
                for(int x = 0; x < flashedArr.GetLength(0); x++)
                {   
                    if(flashedArr[x,y] == 99)
                    {
                        matrixArr[x,y] = -1;
                    }
                    
                }
            }
            flashedArr = new int[10,10];
        }

        public void CountFlashes()
        {
            for(int y = 0; y < matrixArr.GetLength(1); y++)
            {
                for(int x = 0; x < matrixArr.GetLength(0); x++)
                {   
                    if(matrixArr[x,y] == 0)
                    {
                        flashes += 1;
                    }
                    
                }
            }
        }

    class Program
    {
        
        static void Print(int[,] array)
        {
            for(int y = 0; y < array.GetLength(1); y++)
            {
                for(int x = 0; x < array.GetLength(0); x++)
                {
                    if(array[x,y] >= 10)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(array[x,y]);
                    }
                }
                Console.WriteLine();
            } 
            Console.WriteLine();
        }      
        
        
        static void Main(string[] args)
        {
            var inputLines = new List<string>(File.ReadAllText(@"INPUT").Split("\n", StringSplitOptions.RemoveEmptyEntries));
            var workArray = new int[10,10];
            int amountOfSteps = 100;

            for(int y = 0; y < workArray.GetLength(1); y++)
            {
                for(int x = 0; x < workArray.GetLength(0); x++)
                {
                    workArray[x,y] = Convert.ToInt32(inputLines[y][x].ToString());
                }            
            } 

            var workMatrix = new Matrix(workArray);
            Print(workMatrix.matrixArr);

            for(int step = 0; step < amountOfSteps; step++)
            {   
                workMatrix.AddOne();
                Print(workMatrix.matrixArr);
                workMatrix.CountFlashes();

                workMatrix.Flash();
                workMatrix.CleanHouse();  
            }
            Console.WriteLine(workMatrix.flashes);

        }
    }
}
}
