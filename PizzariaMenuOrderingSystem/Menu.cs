using PizzariaMenuOrderingSystem;
using System;
using System.Collections.Generic;

namespace PizzaDeliverySystem
{
    class Menu
    {
        private List<Pizza> pizzas;
        private List<ExtraTopping> extraToppings;
        private List<Beverage> beverages;

        public Menu()
        {
            pizzas = new List<Pizza>();
            extraToppings = new List<ExtraTopping>();
            beverages = new List<Beverage>();
        }

        public void AddPizza(Pizza pizza)
        {
            pizzas.Add(pizza);
        }

        public void AddExtraTopping(ExtraTopping extraTopping)
        {
            extraToppings.Add(extraTopping);
        }

        public void AddBeverage(Beverage beverage)
        {
            beverages.Add(beverage);
        }

        public void PrintMenu()
        {
            Console.WriteLine("Pizzas:");
            foreach (Pizza pizza in pizzas)
            {
                Console.WriteLine("- " + pizza.Name + " - $" + pizza.Price);
            }

            Console.WriteLine("Extra Toppings:");
            foreach (ExtraTopping topping in extraToppings)
            {
                Console.WriteLine("- " + topping.Name + " - $" + topping.Price);
            }

            Console.WriteLine("Beverages:");
            foreach (Beverage beverage in beverages)
            {
                Console.WriteLine("- " + beverage.Name + " - $" + beverage.Price);
            }
        }

        public Pizza GetPizza(int number)
        {
            foreach (Pizza pizza in pizzas)
            {
                if (pizza.Id == number)
                {
                    return pizza;
                }
            }
            return null;
        }

        public ExtraTopping GetExtraTopping(int number)
        {
            foreach (ExtraTopping topping in extraToppings)
            {
                if (topping.Id == number)
                {
                    return topping;
                }
            }
            return null;
        }

        public Beverage GetBeverage(int number)
        {
            foreach (Beverage beverage in beverages)
            {
                if (beverage.Id == number)
                {
                    return beverage;
                }
            }
            return null;
        }
    }
}