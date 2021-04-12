using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3._3.PIZZA_TIME
{
    class Pizzeria
    {
        
        User user = new User();
        int countPizza = 0;
      
        event VoidPizza PizzaEvent = delegate { };
        Pizza pizza;
        public Pizzeria()
        {

            Inter();
        }
        
        public Pizza GetPizza(string number, int countPizza)
        {
            PizzaEvent += Pizzeria_PizzaEvent1;
            switch (number)
            {
                case "1":
                    PizzaEvent?.Invoke();
                    pizza = new PizzaFlorentina();
                    PizzaEvent += Pizzeria_PizzaEvent;
                    pizza.CookPizza(countPizza);
                    PizzaEvent.Invoke();
                    break;
               
                default:
                    break;
            }         
            return pizza;
        }
        public void Inter()
        {
            while (true)
            {

                string piz;
                Console.WriteLine("Введите имя");

                user.Name = Console.ReadLine();
                Console.WriteLine($"{user.Name} введите номер пиццы");
                piz = Console.ReadLine();
                Console.WriteLine($"{user.Name} введите количество");
                while (!int.TryParse(Console.ReadLine(), out countPizza)) ;
                GetPizza(piz, countPizza);
            }
        }
        private void Pizzeria_PizzaEvent()
        {    
            PizzaEvent -= Pizzeria_PizzaEvent;
            for (int i = 0; i < countPizza; i++)
            {
                user.listpizza.Add(pizza);
            }
            PizzaEvent += Pizzeria_PizzaEventReady;
            PizzaEvent?.Invoke();


        }
        private void Pizzeria_PizzaEventReady()
        {
            Console.WriteLine($"{user.Name} ваша пицца готова");
            PizzaEvent = null;
        }
        private void Pizzeria_PizzaEvent1()
        {
            Console.WriteLine($"{user.Name} ваша пицца готовится");
            PizzaEvent = null;
        }


    }
}
