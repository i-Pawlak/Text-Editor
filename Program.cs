using System;
using System.Dynamic;
using System.Runtime.ExceptionServices;

namespace TextEditor_V1
{
    class Program
    {
        static void Main()
        {
            Console.Clear();

            List<string> words = [""];
//good code
            int x = Console.GetCursorPosition().Left;
            int y = Console.GetCursorPosition().Top;

            int CurrentLine = 0;
            int CurrentCharacter = 0;

            Console.SetCursorPosition(0, Console.CursorTop + 4);
            Console.Write((1) + String.Concat(Enumerable.Repeat(" ", 6 - Convert.ToInt32((CurrentLine).ToString().Length))) + ("|"));
            Console.SetCursorPosition(7, 4);

            //Save()


            while (true)
            {
                DisplayCursorPosition(ref x, ref y);
                Input(ref words, ref x, ref y, ref CurrentCharacter, ref CurrentLine);

            }
        }

        static void Input(ref List<string> words, ref int x, ref int y, ref int CurrentCharacter, ref int CurrentLine)
        {
            ConsoleKeyInfo key = (Console.ReadKey());



            if (key.Key == ConsoleKey.Enter)
            {
                CurrentLine++;
                Console.SetCursorPosition(0, Console.CursorTop + 1);
                Console.Write((Console.CursorTop - 3) + String.Concat(Enumerable.Repeat(" ", 6 - Convert.ToInt32((Console.CursorTop - 3).ToString().Length))) + ("|"));


                words.Add("");
            }

            else if (key.Key == ConsoleKey.Backspace && Console.CursorLeft != 7)
            {
                CurrentCharacter--;
                Console.SetCursorPosition((Console.CursorLeft - 1), Console.CursorTop);
                Console.Write(" ");
                Console.SetCursorPosition((Console.CursorLeft - 1), Console.CursorTop);
                words[CurrentLine] = words[CurrentLine][..(words[CurrentLine].Length - 1)];
            }

            else if (key.Key == ConsoleKey.Backspace && (Console.CursorLeft == 7))
            {
                CurrentLine--;
                PreviousLine(ref words);
            }

            else
            {
                words[CurrentLine] = words[CurrentLine] + key.KeyChar;
                CurrentCharacter++;
            }
            //Save(ref words, key.KeyChar);
        }

        /* static void Save(ref List<string> words, char key)
         {
             int CurrentLine = Console.CursorTop;
             // var Something = 1;
             // Something = 2;
             words[CurrentLine] = words[CurrentLine] + key;
         }*/

        static void DisplayCursorPosition(ref int x, ref int y)
        {

            int TempCursorLeft = Console.CursorLeft;
            int TempCursorTop = Console.CursorTop;

            CreateBox();
            
            Console.Write("\u2503 Cursor Position: " + (TempCursorLeft - 7).ToString() + "," + (TempCursorTop - 4).ToString() + " " + "\u2503");
            Console.SetCursorPosition(TempCursorLeft, TempCursorTop);
        }

        static void PreviousLine(ref List<string> words) // putting on previous line.
        {
            if (Console.CursorTop != 4)
            {
                Console.SetCursorPosition(words[Console.CursorTop - 5].Length + 7, Console.CursorTop - 1);
            }

        }

        static void LineNumbers()
        {
            int LineNumber = 0;

            while (LineNumber < Console.WindowHeight)
            {
                Console.SetCursorPosition(0, LineNumber);
                Console.Write(LineNumber);
                LineNumber++;
            }

        }

        static void CreateBox()
        {
            Console.SetCursorPosition(Console.WindowWidth - 31, 0);
            Console.WriteLine(" \u250f\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2513");
            Console.SetCursorPosition(Console.WindowWidth - 31, 2);
            Console.WriteLine(" \u2517\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u2501\u251b");
            Console.SetCursorPosition(Console.WindowWidth - 30, 1);
        }
    }
}
