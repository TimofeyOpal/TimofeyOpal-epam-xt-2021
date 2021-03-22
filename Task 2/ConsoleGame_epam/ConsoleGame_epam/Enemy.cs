using System;
using System.Threading;

namespace ConsoleGame_epam
{
    class Enemy : Point
    {

        public Enemy()
        {

            Sprite = '$';

        }
        int x;
        int y;
        public void Write(ref Wall wall)
        {
            Random r = new Random();
            int y = r.Next(2, wall.Column);
            int x = r.Next(2, wall.Row);
            this.x = x;
            this.y = y;
            Console.SetCursorPosition(x, y);
            Console.Write(Sprite);
        }
        public void Walk(ref Wall wall)
        {

            Random random = new Random();
            int r = random.Next(1, 4);
            WriteEnemy(' ', x, y);
            switch (r)
            {
                case 1:
                    x++;
                    WriteEnemy(Sprite, x, y);
                    break;
                case 2:
                    x--;
                    WriteEnemy(Sprite, x, y);
                    break;
                case 3:
                    y--;
                    WriteEnemy(Sprite, x, y);
                    break;
                case 4:
                    y++;
                    WriteEnemy(Sprite, Row, Column);
                    break;
            }
            //if ((Column < 1) | (Row < 1)) break;
            //else if ((Row > wall.Row + 1) | (Column > wall.Column)) break;
            // WriteEnemy(Sprite, Row, Column);
            Thread.Sleep(1000);


        }
        public static void WriteEnemy(char toWrite, int x, int y)
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
