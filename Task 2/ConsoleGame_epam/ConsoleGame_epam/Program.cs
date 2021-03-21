using System;
using System.Collections.Generic;

namespace ConsoleGame_epam
{
    class Program
    {
        static void Main(string[] args)
        {
            Wall wall = new Wall(15, 15);
            wall.Drow();
             List<Enemy> koll = new List<Enemy>();
            //Enemy enemy1 = new Enemy();
            for (int i = 0; i < 5; i++)
            {
            //    enemy1.Write(ref wall);
                koll.Add(new Enemy());
            }
            foreach(Enemy enemy in koll)
            {
                enemy.Write(ref wall);
            }
            Player player = new Player(ref wall);
            






        }
        
    }
}
