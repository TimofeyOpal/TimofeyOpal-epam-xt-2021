using System;

namespace ConsoleGame_epam
{
    class Enemy : Point
    {

        public Enemy()
        {

            Sprite = '$';

        }
        public void Write(ref Wall wall)
        {
            Random r = new Random();
            int y = r.Next(2, wall.Column);
            int x = r.Next(2, wall.Row);
            Console.SetCursorPosition(x, y);
            Console.Write(Sprite);
        }
        public void Walk(ref Wall wall)
        {

        }

    }
}
