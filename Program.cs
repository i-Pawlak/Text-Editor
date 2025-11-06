namespace TextEditor_V1
{
    class Program
    {

        static void Main()
        {
            Console.Clear();

            int CurrentLine = 0;
            int CurrentCharacter = 0;
            
            List<string> lines = new List<string>();
            lines.Add("");

            while (true)
            {
                UpdateLines(ref lines, ref CurrentLine, ref CurrentCharacter);

                UpdateScreen(ref lines, ref CurrentLine);
            }
        }

        static void UpdateScreen(ref List<string> lines, ref int CurrentLine)
        
        {
            Console.SetCursorPosition(0, CurrentLine);
            
            for (int i = 0; i < lines.Count; i++)
                
            {
                Console.Write($"{string.Concat(Enumerable.Repeat(" ", 6 - i.ToString().Length))}{i}|{lines[i]}");
            }
        }

        static void UpdateLines(ref List<string> lines, ref int CurrentLine, ref int CurrentCharacter)
        {
            ConsoleKeyInfo UserInput = Console.ReadKey(true);
            MakeNewLine(ref lines, ref CurrentLine, ref UserInput);
                if (UserInput.Key == ConsoleKey.Backspace && CurrentCharacter > 0 )
                {
                    CurrentCharacter--;
                    lines[CurrentLine] = lines[CurrentLine].Substring(0, CurrentCharacter) +
                                         lines[CurrentLine].Substring(CurrentCharacter + 1);
                    Console.Clear();

                }

                else
                {
                    lines[CurrentLine] += UserInput.KeyChar;
                    CurrentCharacter++;
                }
        }

        static void MakeNewLine(ref List<string> lines, ref int CurrentLine, ref ConsoleKeyInfo UserInput)
        {
            if (UserInput.Key == ConsoleKey.Enter)
            {
                CurrentLine++;
                lines.Add("");
            }
        }
    }
}