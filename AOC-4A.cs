using System;
using System.Collections.Generic;
using System.IO;

namespace AOC1
{
    public class MatrixClass
    {
        public int[,] matrix = new int[5,5];
        public List<int> list = new List<int>();
    }
    class Program
    {

        static void Main(string[] args)
        {
            string[] splitInput = File.ReadAllText(@"INPUTHERE").Split("\n\n");
            int[] drawInput = Array.ConvertAll(splitInput[0].Split(','), x => Convert.ToInt32(x));
            var matrixClassList = new List<MatrixClass>();
            int winningIndex = -1;
            int winningDraw = -1;
            for(int i = 1; i < splitInput.Length; i++)
            {
                               
                int[,] currentMatrix = new int[5,5];
                int indexY = 0;
 
                for(int k = 0; k < 5; k++)
                {
                    string line = splitInput[i].Split("\n")[k];
                    var currentLine = new int[5];
                    for(int j = 0; j < 5; j++)
                    {                      
                        currentLine[j] = Convert.ToInt32($"{line[0+j*3]}{line[1+j*3]}");
                    }

                    int indexX = 0;
                    foreach(int mark in currentLine)
                    {
                        currentMatrix[indexY,indexX] = mark;
                        indexX++;
                    }   

                   indexY++;
                }
                MatrixClass exportMatrixClass = new MatrixClass(); 
                matrixClassList.Add(new MatrixClass() {matrix = currentMatrix});
            } 

            var testsList = new List<int[]>();
            for(int i = 0; i < 5; i++)
            {
                testsList.Add(new int[] {0+i*5, 1+i*5, 2+i*5, 3+i*5, 4+i*5});
                testsList.Add(new int[] {0+i, 5+i, 10+i, 15+i, 20+i});
            }

            bool winnerFound = false;
            foreach(int drawnNumber in drawInput)
            {
                for(int i = 0; i < matrixClassList.Count && winnerFound == false; i++)
                {
                    var matrixClass = matrixClassList[i]; 
                    for(int x = 0; x < 5 ; x++)
                    {
                        for(int y = 0; y < 5; y++)
                        {
                            if(drawnNumber == matrixClass.matrix[x,y])
                            {
                                matrixClass.list.Add(x+y*5);
                            }
                        }                        
                    }                    
                    foreach(int[] testarray in testsList)
                    {
                        int validCounter = 0;
                        foreach(int value in testarray)
                        {
                            validCounter = matrixClass.list.Contains(value) ? validCounter + 1 : validCounter;
                            if(validCounter == 5)
                            {
                                winnerFound = true;
                                winningIndex = i;
                                winningDraw = drawnNumber;
                            }
                        }
                    }
                                         
                }
            }
            int counter = 0;
            var winningList = new List<int>();
            foreach(int matrixValue in matrixClassList[winningIndex].matrix)
            {
                if(counter < 4)
                {
                    Console.Write($"[{matrixValue}]");
                    counter++;
                }
                else
                {
                    Console.Write($"[{matrixValue}]");
                    Console.WriteLine();
                    counter = 0;
                }
            }

            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    if(matrixClassList[winningIndex].list.Contains(j+i*5) == false)
                    {
                        winningList.Add(matrixClassList[winningIndex].matrix[j,i]);
                    }
                }
            }
            int winningSum = 0;
            foreach(int element in winningList)
            {
                winningSum += element;
            }
            Console.WriteLine($"{winningSum}*{winningDraw}= {winningSum*winningDraw}");
        }
    }
}

