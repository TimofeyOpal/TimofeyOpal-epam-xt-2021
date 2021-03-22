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
                    if (x == 15)
                    {
                        x -= 3;

                    }
                    else
                    {
                        x++;
                    }
                    WriteEnemy(Sprite, x, y);
                    break;
                case 2:
                    if (x == 1)
                    {
                        x += 3;

                    }
                    else
                    {
                        x--;


                    }
                    WriteEnemy(Sprite, x, y);
                    break;

                case 3:
                    if (y > 15)
                    {
                        y -= 3;

                    }
                    else
                    {
                        y++;
                    }

                    WriteEnemy(Sprite, x, y);
                    break;
                case 4:
                    if (y == 1)
                    {
                        y += 3;

                    }
                    else
                    {
                        y--;
                    }

                    WriteEnemy(Sprite, Row, Column);
                    break;
            }

            Thread.Sleep(50);


        }
        public void WriteEnemy(char toWrite, int x, int y)
        {
            try
            {

                Console.SetCursorPosition(x, y);
                Console.Write(toWrite);

            }
            catch (Exception)
            {
            }
        }

    }
}
