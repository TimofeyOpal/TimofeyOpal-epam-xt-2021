﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _3._3._3.PIZZA_TIME
{
    class PizzaFlorentina : Pizza
    {          
       // protected override async void CookPizzaAsync(int count)
       // {
       //     await Task.Run(() => CookPizzar(count));
       // }

        public override void CookPizza(int count)
        {
            int countpizza = default;
            for (int i = 0; i < count; i++)
            {
                countpizza++;
                Thread.Sleep(1000);
                Console.WriteLine($"Пицца №'{countpizza}' Флорентина готова");
            }


        }


    }

}