using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleGame_epam
{
    class Player : Point
    {
      
        public Player(ref Wall wall)
        {

            Sprite = '*';
            Row = 2;
            Column = 2;
            while (true)
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
                    if ((Column < 1) | (Row < 1)) break;
                    else if ((Row > wall.Row + 1) | (Column > wall.Column)) break;
                    Write(Sprite, Row ,Column);
                }
                else
                {
                    Thread.Sleep(100);
                }
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
