using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BayShore.Exercises
{
    public class Exercise4
    {

        public static void GameHeader()
        {
            Console.WriteLine("Exercise 4");
            Console.WriteLine("------------");
            Console.WriteLine("Write some code that evolves generations through the \"Game of life\"");
            Console.WriteLine();
            StartGame();

        }


        private static void StartGame()
        {
            int[,] grid = new int[,]
	          {
                { 0, 1, 0, 0, 0},
                { 1, 0, 0, 1, 1},
                { 1, 1, 0, 0, 1},
                { 0, 1, 0, 0, 0},
                { 1, 0, 0, 0, 1}, 
	          };

            LifeGrid lifeGrid = new LifeGrid(grid);

            Console.WriteLine("Generation 0");
            lifeGrid.DrawGeneration();
            Console.WriteLine();
            
            while (lifeGrid.AliveCells() > 0)
            {
                string response;

                Console.WriteLine();
                Console.WriteLine("Generation {0}", lifeGrid.GenerationCount);

                lifeGrid.ProcessGeneration();
                lifeGrid.DrawGeneration();

                Console.WriteLine();

                if (lifeGrid.AliveCells() == 0)
                {
                    Console.WriteLine("Every one died!");
                    Console.ReadLine();
                }
                else
                {
                   Console.WriteLine("Press <Enter> to contiune or n to quit.");
                   response = Console.ReadLine();
                   if (response == "n" || response == "N")
                        break;
                }
            }//while
            
        }//method startGame

    }//class


    public class LifeGrid
    {
        int[,] generation;
        int[,] lastGeneration;
        int generationCount;
        int width; //cols
        int height; //rows

        public int GenerationCount
        {
            get { return generationCount; }
        }


        public LifeGrid(int[,] newGrid)
        {
            generation = (int[,])newGrid.Clone();
            generationCount = 1;
            width = generation.GetLength(1);
            height = generation.GetLength(0);
            lastGeneration = new int[height, width];
        }


        public void DrawGeneration()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                    Console.Write("{0}", generation[y, x]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public int AliveCells()
        {
            int count = 0;

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    if (generation[y, x] == 1)
                        count++;

            return count;
        }


        public void ProcessGeneration()
        {
            int[,] nextGeneration = new int[height, width];

            lastGeneration = (int[,])generation.Clone();

            generationCount++;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (generation[y, x] == 0 && Neighbours(x, y) == 3)
                        nextGeneration[y, x] = 1;
                    if (generation[y, x] == 1 &&
                           (Neighbours(x, y) == 2 || Neighbours(x, y) == 3))
                        nextGeneration[y, x] = 1;
                }
            }

            generation = (int[,])nextGeneration.Clone();
        }




        private int Neighbours(int x, int y)
        {
            int count = 0;

            // Check for x - 1, y - 1
            if (x > 0 && y > 0)
            {
                if (generation[y - 1, x - 1] == 1)
                    count++;
            }

            // Check for x, y - 1
            if (y > 0)
            {
                if (generation[y - 1, x] == 1)
                    count++;
            }

            // Check for x + 1, y - 1
            if (x < width - 1 && y > 0)
            {
                if (generation[y - 1, x + 1] == 1)
                    count++;
            }

            // Check for x - 1, y
            if (x > 0)
            {
                if (generation[y, x - 1] == 1)
                    count++;
            }

            // Check for x + 1, y
            if (x < width - 1)
            {
                if (generation[y, x + 1] == 1)
                    count++;
            }

            // Check for x - 1, y + 1
            if (x > 0 && y < height - 1)
            {
                if (generation[y + 1, x - 1] == 1)
                    count++;
            }

            // Check for x, y + 1
            if (y < height - 1)
            {
                if (generation[y + 1, x] == 1)
                    count++;
            }

            // Check for x + 1, y + 1
            if (x < width - 1 && y < height - 1)
            {
                if (generation[y + 1, x + 1] == 1)
                    count++;
            }

            return count;
        }//neighbor

     

    }//class


}//namespace
