using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Known Bugs/Concerns/Things that could make game better:
            //      -The snake moves faster going through columns vs rows - could change Thread.Sleep but we kind of enjoy having different speeds - makes it more challenging.
            //      -Program breaks when snake goes out of bounds - would like to control this and add a game over message
            //      -If you eat the score and then eat the food, game breaks - simply create a 'scoreboard' grid area that is out of bounds
            //      -If food spawns on snake, game breaks - refactor FoodGeneration()
            //      -Snake body does not grow
            //      -Snake can eat the border
            //      -Could refactor into more object-oriented approach
            //      -Grid flashing - try and optimize grid write speeds


            // Define playing grid as multidimensional array

            string[,] grid = new string[10, 20]
            {
                {"0", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#"} ,
                {"#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#"} ,
                {"#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#"} ,
                {"#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#"} ,
                {"#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#"} ,
                {"#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#"} ,
                {"#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#"} ,
                {"#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#"} ,
                {"#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#"} ,
                {"#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" }
            };

            Tuple<int, int> FindIndexOfFood()
            {
                for (int row = 1; row < 10; row++)
                {
                    for (int column = 1; column < 20; column++)
                    {
                        if (grid[row, column] == "o")
                        {
                            return Tuple.Create(row, column);
                        }
                    }
                }
                return null;
            }

            void FoodGeneration()
            {
                Random rand = new Random();
                int randomRow = rand.Next(1, 9);
                int randomColumn = rand.Next(1, 19);
                grid[randomRow, randomColumn] = "o";
            }

            void AddToScore()
            {
                int scoreInt = Int32.Parse(grid[0, 0]);
                int newScore = scoreInt + 1;
                grid[0, 0] = newScore.ToString();

            }

            void BuildGrid()
            {

                for (int row = 0; row < 10; row++)
                {
                    for (int column = 0; column < 20; column++)
                    {
                        Console.Write(grid[row, column]);
                    }
                    Console.WriteLine();
                }

            }

            void GoRightIfNoKeyPress()
            {
                var row = 0;
                var column = 0;
                var originalIndex = FindIndexOfFood();
                while (!Console.KeyAvailable)
                {
                    while (!Console.KeyAvailable && column < 20)
                    {
                        if (grid[row, column] == "S")
                        {
                            var updateIndex = FindIndexOfFood();
                            grid[row, column] = " ";
                            grid[row, column + 1] = "S";

                            if (updateIndex == null)
                            {
                                FoodGeneration();
                                AddToScore();
                                originalIndex = FindIndexOfFood();

                            }

                            Thread.Sleep(200);

                            Console.Clear();
                            BuildGrid();
                        }
                        column = column + 1;
                    }
                    column = 0;
                    row = row + 1;
                }
            }
            void GoLeftIfNoKeyPress()
            {
                var row = 0;
                var column = 19;
                var originalIndex = FindIndexOfFood();
                while (!Console.KeyAvailable)
                {
                    while (!Console.KeyAvailable && column > 0)
                    {
                        if (grid[row, column] == "S")
                        {
                            var updateIndex = FindIndexOfFood();
                            grid[row, column] = " ";
                            grid[row, column - 1] = "S";

                            if (updateIndex == null)
                            {
                                FoodGeneration();
                                AddToScore();
                                originalIndex = FindIndexOfFood();

                            }

                            Thread.Sleep(200);

                            Console.Clear();
                            BuildGrid();
                        }
                        column = column - 1;
                    }
                    column = 19;
                    row = row + 1;
                }
            }
            void GoDownIfNoKeyPress()
            {
                var row = 0;
                var column = 0;
                var originalIndex = FindIndexOfFood();
                while (!Console.KeyAvailable)
                {
                    while (!Console.KeyAvailable && column < 20)
                    {
                        if (grid[row, column] == "S")
                        {
                            var updateIndex = FindIndexOfFood();
                            grid[row, column] = " ";
                            grid[row + 1, column] = "S";

                            if (updateIndex == null)
                            {
                                FoodGeneration();
                                AddToScore();
                                originalIndex = FindIndexOfFood();

                            }

                            Thread.Sleep(200);

                            Console.Clear();
                            BuildGrid();
                        }
                        column = column + 1;
                    }
                    column = 0;
                    row = row + 1;
                }
            }
            void GoUpIfNoKeyPress()
            {
                var row = 9;
                var column = 0;
                var originalIndex = FindIndexOfFood();
                while (!Console.KeyAvailable)
                {
                    while (!Console.KeyAvailable && column < 20)
                    {
                        if (grid[row, column] == "S")
                        {
                            var updateIndex = FindIndexOfFood();
                            grid[row, column] = " ";
                            grid[row - 1, column] = "S";

                            if (updateIndex == null)
                            {
                                FoodGeneration();
                                AddToScore();
                                originalIndex = FindIndexOfFood();

                            }
                            
                            Thread.Sleep(200);

                            Console.Clear();
                            BuildGrid();
                        }
                        column = column + 1;
                    }
                    column = 0;
                    row = row - 1;
                }
            }


            // Initialization - define snake starting point, spawn food, build grid
            string snake = "S";
            grid[2, 2] = snake;

            FoodGeneration();
            BuildGrid();

            // User instructions
            Console.WriteLine("Press W for Up, A for Left, D for Right, S for Down.");
            Console.WriteLine("Eat the food!");

            while (true)
            {

                char input = Console.ReadKey().KeyChar;

                if (input == 'd')
                {
                    GoRightIfNoKeyPress();

                }

                if (input == 's')
                {
                    GoDownIfNoKeyPress();
                }

                if (input == 'w')
                {
                    GoUpIfNoKeyPress();
                }

                if (input == 'a')
                {
                    GoLeftIfNoKeyPress();
                }

            }
        }
    }
}