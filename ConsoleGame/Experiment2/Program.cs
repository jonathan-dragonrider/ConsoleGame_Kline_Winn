using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetCursorPosition(left, top);

            void DrawScreen()
            {
                Console.Clear();
                Console.SetCursorPosition(_left, _top);
                Console.Write('*');
            }

            void AcceptInput()
            {
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        _left--;
                        break;
                    case ConsoleKey.RightArrow:
                        _left++;
                        break;
                    case ConsoleKey.UpArrow:
                        _top--;
                        break;
                    case ConsoleKey.DownArrow:
                        _top++;
                        break;

                }

            }

        private static int _left;
        private static int _top;

       
        
            Console.CursorVisible = false;
            while (true)
            {
                DrawScreen();
                AcceptInput();
            }
        
    }
}
