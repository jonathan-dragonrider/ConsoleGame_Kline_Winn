using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Experimentation
{
    class TheOneThatWorks
    {
        static void Main(string[] args)
        {
            //string boundary = "####################\n" +
            //    "#123456789123456789#\n" +
            //    "#2                 #\n" +
            //    "#3                 #\n" +
            //    "#4                 #\n" +
            //    "#5                 #\n" +
            //    "#6                 #\n" +
            //    "#7                 #\n" +
            //    "#8                 #\n" +
            //    "####################\n";

            // Define playing grid with rows and columns - r x c

            // Rows - 10

            string sr0 = "####################"; 
            string sr1 = "#                  #";
            char[] r0 = sr0.ToCharArray();
            char[] r1 = sr1.ToCharArray();
            char[] r2 = sr1.ToCharArray();
            char[] r3 = sr1.ToCharArray();
            char[] r4 = sr1.ToCharArray();
            char[] r5 = sr1.ToCharArray();
            char[] r6 = sr1.ToCharArray();
            char[] r7 = sr1.ToCharArray();
            char[] r8 = sr1.ToCharArray();
            char[] r9 = sr0.ToCharArray();

            List<char[]> rows = new List<char[]>();
            rows.Add(r0);
            rows.Add(r1);
            rows.Add(r2);
            rows.Add(r3);
            rows.Add(r4);
            rows.Add(r5);
            rows.Add(r6);
            rows.Add(r7);
            rows.Add(r8);
            rows.Add(r9);

            // Columns - 20

            string sc0 = "#\n" +
                "#\n" +
                "#\n" +
                "#\n" +
                "#\n" +
                "#\n" +
                "#\n" +
                "#\n" +
                "#\n" +
                "#\n";
            string sc1 = "#\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "#\n";
            char[] c0 = sc0.ToCharArray(); 
            char[] c1 = sc0.ToCharArray();
            char[] c2 = sc1.ToCharArray();
            char[] c3 = sc1.ToCharArray();
            char[] c4 = sc1.ToCharArray();
            char[] c5 = sc1.ToCharArray();
            char[] c6 = sc1.ToCharArray();
            char[] c7 = sc1.ToCharArray();
            char[] c8 = sc1.ToCharArray();
            char[] c9 = sc1.ToCharArray();
            char[] c10 = sc1.ToCharArray();
            char[] c11 = sc1.ToCharArray();
            char[] c12 = sc1.ToCharArray();
            char[] c13 = sc1.ToCharArray();
            char[] c14 = sc1.ToCharArray();
            char[] c15 = sc1.ToCharArray();
            char[] c16 = sc1.ToCharArray();
            char[] c17 = sc1.ToCharArray();
            char[] c18 = sc1.ToCharArray();
            char[] c19 = sc0.ToCharArray();

            List<char[]> columns = new List<char[]>();
            columns.Add(c0);
            columns.Add(c1);
            columns.Add(c2);
            columns.Add(c3);
            columns.Add(c4);
            columns.Add(c5);
            columns.Add(c6);
            columns.Add(c7);
            columns.Add(c8);
            columns.Add(c9);
            columns.Add(c10);
            columns.Add(c11);
            columns.Add(c12);
            columns.Add(c13);
            columns.Add(c14);
            columns.Add(c15);
            columns.Add(c16);
            columns.Add(c17);
            columns.Add(c18);
            columns.Add(c19);


            // Playing grid multidimensional array

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

            FoodGeneration();

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

            void FoodGeneration() // In the future need this to be generated somewhere that is not part of the snake
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

            void GoRight() // old
            {
                for (int row = 0; row < 10; row++)
                {

                    for (int column = 0; column < 20; column++)
                    {
                        if (grid[row, column] == "S")
                        {
                            grid[row, column] = " ";
                            grid[row, column + 1] = "S";
                            Thread.Sleep(200);

                            Console.Clear();
                            BuildGrid();
                        }
                    }

                }
            }

            void GoDown() // old
            {
                for (int row = 0; row < 10; row++)
                {

                    for (int column = 0; column < 20; column++)
                    {
                        if (grid[row, column] == "S")
                        {
                            grid[row, column] = " ";
                            grid[row + 1, column] = "S";
                            Thread.Sleep(200);
                        }
                    }

                    Console.Clear();
                    BuildGrid();

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

                            // find original index of "o"
                            // if original index != find index
                            //      FoodGeneration();
                            //      AddToScore();

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
            // if (grid[row, column] == snakeHead)
            //      grid of column + 1 = snakeHead
            //      grid of column = snakeBodySegment - how to keep count of body segments
            //      body segment follows head - if head moves, body follows
            // while(IsHeadMoving) - updateIndex == null
            //      array of segments
            //      segmentIndexOne should go to head position minus 1 row/column - if head moves to the right, segment1 goes to grid[row, column - 1](of head); if head moves down, segment1 goes to grid[row - 1, column](of head)

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

            bool DoesBoundaryContainSnake() // doesnt work right now
            {
                for (int i = 0; i < 20; i++)
                {
                    if (grid[0, i] == "S")
                    {
                        return true;
                    }
                    if (grid[10, i] == "S")
                    {
                        return true;
                    }
                }
                for (int i = 0; i < 10; i++)
                {
                    if (grid[i, 0] == "S")
                    {
                        return true;
                    }
                    if (grid[i, 20] == "S")
                    {
                        return true;
                    }
                }
                return false;
            }

            // Define snake and starting position

            string snake = "S";
            grid[2, 2] = snake;

            ConsoleKeyInfo consoleKey;
            BuildGrid();

            Console.WriteLine("Press W for Up, A for Left, D for Right, S for Down.");
            Console.WriteLine("Eat the food!");


            while (true)
            {

                //Console.Clear();
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
