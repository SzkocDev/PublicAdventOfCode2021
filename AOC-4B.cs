using System;
using System.Collections.Generic;
using System.IO;

namespace AOC1
{
    public class MatrixClass
    {
        public List<int> matrix = new List<int>();
        public List<int> pickedIndexList = new List<int>();
        public List<int> pickedValueList = new List<int>();
        public int winningDraw = -1;
        public bool winner = false;
    }


    class Program
    {
        static void LoadMatrixesToList(string[] input,List<MatrixClass> list)
        {
            
            for(int i = 1; i < input.Length; i++)
            {
                var currentMatrix = new List<int>();

                for(int k = 0; k < 5; k++)
                {
                    string line = input[i].Split("\n")[k];
                    
                    for(int j = 0; j < 5; j++)
                    {
                        currentMatrix.Add(Convert.ToInt32($"{line[0+j*3]}{line[1+j*3]}"));
                    }                                    
                }

                MatrixClass exportMatrixClass = new MatrixClass() {matrix = currentMatrix};
                list.Add(new MatrixClass() {matrix = currentMatrix});
            }
            int counter = 0;
            foreach(MatrixClass element in list)
            {
                foreach (int mark in element.matrix)
                {
                    Console.Write($"{mark} ");                    
                }                
                Console.WriteLine($" {counter} ");                
                counter++;
            }
        }
        static void CheckDrawnValue(int lookedForValue, List<MatrixClass> list, List<int[]> testsList)
        {
            foreach(var matrixClass in list)
            {
                if(matrixClass.matrix.Contains(lookedForValue) && matrixClass.winner == false)
                {
                    matrixClass.pickedIndexList.Add(matrixClass.matrix.IndexOf(lookedForValue));
                    matrixClass.pickedValueList.Add(lookedForValue);
                    RunTests(matrixClass, lookedForValue, list, testsList);
                }
                
            }
        }
        static void RunTests(MatrixClass data, int lastDraw, List<MatrixClass> list, List<int[]> testsList)
        {
            foreach(int[] test in testsList)
            {
                int validCounter = 0;
                string testa = "";
                foreach(int mark in test)
                {
                    validCounter = data.pickedIndexList.Contains(mark) ? validCounter + 1 : validCounter;
                }
                
                if(validCounter == 5 && data.winner == false)
                {
                    Console.WriteLine(testa + $"{lastDraw}");
                    data.winningDraw = lastDraw;
                    data.winner = true;
                    int sum = 0;
                    foreach(int value in data.matrix)
                    {
                        if(data.pickedValueList.Contains(value) == false)
                        {
                            sum += value;
                        }
                    }
                    Console.WriteLine($"BINGO! BINGO! BINGO! BINGO! BINGO! \n Last Draw: {lastDraw} Index: {list.IndexOf(data)} Sum: {sum}");
                    Console.WriteLine($"Solution: {sum*lastDraw}");
                }
            }
        }
        static void Main(string[] args)
        {
            string[] splitInput = File.ReadAllText(@"INPUTHERE").Split("\n\n");
            int[] drawInput = Array.ConvertAll(splitInput[0].Split(','), x => Convert.ToInt32(x));
            var inputMatrixClassList = new List<MatrixClass>();

            var testsList = new List<int[]>();
            for(int i = 0; i < 5; i++)
            {
                testsList.Add(new int[] {0+i*5, 1+i*5, 2+i*5, 3+i*5, 4+i*5});
                testsList.Add(new int[] {0+i, 5+i, 10+i, 15+i, 20+i});
            }
            
            LoadMatrixesToList(splitInput, inputMatrixClassList);

            foreach(int drawnValue in drawInput)
            {
                CheckDrawnValue(drawnValue, inputMatrixClassList, testsList);
            }
        }
    }
}
