using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame_epam
{
    class Food : Point
    {
        public Food()
        {
            Sprite = '@';
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public void Write(ref Wall wall)
        {
            Random r = new Random();
            int y = r.Next(2, wall.Column);
            int x = r.Next(2, wall.Row);       
            Console.SetCursorPosition(x, y);
            Console.Write(Sprite);
        }
    }
}
