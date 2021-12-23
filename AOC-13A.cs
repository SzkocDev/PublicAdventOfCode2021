using System;
using System.Collections.Generic;
using System.IO;

namespace AOC
{   
    class Page
    {   
        public string[,] page;

        public Page(int width, int height)
        {
            page = new string[width + 1,height + 1];
        }

        public void Mark(int x, int y)
        {
            page[x, y] = "X";
        }
        
        public void Fold(string foldInfo)
        {
            var foldInfoSplit = foldInfo.Split("=", StringSplitOptions.RemoveEmptyEntries);
            bool vertical = foldInfoSplit[0] == "y" ? true : false;
            int startingLine = Convert.ToInt32(foldInfoSplit[1].ToString());
            

            if(vertical)
            {
                var workPage = new string[page.GetLength(0) , startingLine];
                
                for(int y = startingLine + 1; y < page.GetLength(1); y++)
                {
                    for(int x = 0; x < page.GetLength(0); x++)
                    {
                        if(page[x , y] == "X")
                        {
                            int moveY = startingLine - (y - startingLine);
                            page[x, moveY] = "X";
                        }
                    }
                }

                for(int y = 0; y < startingLine; y++)
                {
                    for(int x = 0; x < page.GetLength(0); x++)
                    {
                        workPage[x,y] = page[x,y];
                    }
                }
                page = workPage;
            }
            else 
            {
                var workPage = new string[startingLine , page.GetLength(1)];

                for(int y = 0; y < page.GetLength(1); y++)
                {
                    for(int x = startingLine + 1 ; x < page.GetLength(0); x++)
                    {
                        if(page[x , y] == "X")
                        {
                            int moveX = startingLine - (x - startingLine);
                            page[moveX, y] = "X";
                        }
                    }
                }

                for(int y = 0; y < page.GetLength(1); y++)
                {
                    for(int x = 0; x < startingLine; x++)
                    {
                        workPage[x,y] = page[x,y];
                    }
                }
                page = workPage;
            }
        }

        public void Print()
        {
            for(int y = 0; y < page.GetLength(1); y++)
            {
                for(int x = 0; x < page.GetLength(0); x++)
                {
                    if(page[x,y] != null)
                    {
                        Console.Write(page[x,y]);
                    } 
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            var inputLines = new List<string>(File.ReadAllText(@"Input").Split("\n", StringSplitOptions.RemoveEmptyEntries));
            var folds = new List<string>();
            var points = new List<string>();
            int pageSizeX = 0;
            int pageSizeY = 0;
            Page page;
            foreach(string line in inputLines)
            {
                if(line.Contains("fold along "))
                {
                    folds.Add(line.Replace("fold along ", ""));
                }
                else if(line.Contains(","))
                {
                    points.Add(line);
                    var splitLine = line.Split(",");                    
                    int newX = Convert.ToInt32(splitLine[0].ToString());
                    int newY = Convert.ToInt32(splitLine[1].ToString());
                    pageSizeX = pageSizeX > newX ? pageSizeX : newX;
                    pageSizeY = pageSizeY > newY ? pageSizeY : newY;
                }
            }

            page = new Page(pageSizeX, pageSizeY);

            foreach(string coords in points)
            {
                var split = coords.Split(",");   
                int x = Convert.ToInt32(split[0].ToString());
                int y = Convert.ToInt32(split[1].ToString());
                page.Mark(x,y);
            }
            page.Print();
            page.Fold(folds[0]);//did the second part on accident ;O
            page.Print();
            int counter = 0;
            foreach(string dot in page.page)
            {
                if(dot == "X")
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}


    


    
