using System;
using System.Threading;

namespace ConsoleGame_epam
{
    class Player : Point
    {

        public Player()
        {

            Sprite = '*';
            Row = 2;
            Column = 2;

        }
        public void Walk(ref Wall wall)
        {

            if (Console.KeyAvailable)
            {
                Write(' ', Row, Column);
                var command = Console.ReadKey().Key;
                switch (command)
                {
                    case ConsoleKey.DownArrow:
                        Column++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (Column > 0)
                        {
                            Column--;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (Row > 0)
                        {
                            Row--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        Row++;
                        break;
                }
                if ((Column < 1) | (Row < 1) | (Row > wall.Row ) | (Column > wall.Column+1))
                {
                    Console.Clear();
                    Console.Write("Вы проиграли");
                    Environment.Exit(0);
                }               
                Write(Sprite, Row, Column);
            }
            else
            {
                Thread.Sleep(100);
            }

        }
        public static void Write(char toWrite, int x = 0, int y = 0)
        {
            try
            {
                if (x >= 0 && y >= 0)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(toWrite);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
