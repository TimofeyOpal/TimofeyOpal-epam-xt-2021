﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleGame_epam
{
    class Program
    {



        static void Main(string[] args)
        {
            Wall wall = new Wall(15, 15);
            wall.Drow();
            List<Enemy> koll = new List<Enemy>();
            Console.CursorVisible = false;
            for (int i = 0; i < 4; i++)
            {
                koll.Add(new Enemy());
            }
            foreach (Enemy enemy in koll)
            {
                enemy.Write(ref wall);

            }
            Player player = new Player();


            while (true)
            {
                foreach (Enemy enemy in koll)
                {
                    enemy.Walk(ref wall);
                }
                player.Walk(ref wall);

            }

        }

    }
}