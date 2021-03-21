using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame_epam
{
    class Wall : Point
    {
        public Wall(int row, int column)
        {
            Sprite = '#';
            Row = row;
            Column = column;
        }
        public void Drow()
        {
            string newLine = Environment.NewLine;
            for (int i = 0; i <= Row; i++)
            {
                Console.Write(Sprite);
            }
            for (int i = 0; i <= Column; i++)
            {
                Console.Write(newLine);
                for (int j = 0; j <= Row; j++)
                {
                    if (j == 0)
                    {
                        Console.Write(Sprite);
                    }
                    if (j != Row)
                    {
                        Console.Write(" ");
                    }
                    if (j == Row )
                    {
                        Console.Write(Sprite);
                    }
                }
            }
            Console.Write(newLine);
            for (int i = 0; i <= Row; i++)
            {
                Console.Write(Sprite);
            }
        }
    }
}
