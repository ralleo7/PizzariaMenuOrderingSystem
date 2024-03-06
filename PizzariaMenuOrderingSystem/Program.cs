using PizzariaMenuOrderingSystem;
using System;
using System.Collections.Generic;

namespace PizzaDeliverySystem
{

    class Program
    {
        static List<Order> orders = new List<Order>();
        static Menu menu = MakeMenu();
        static Customer customer;

        static void Main(string[] args)
        {
            customer = ChooseCustomer();

            Console.WriteLine($"Welcome, {customer.Name}, to Big Mama pizzaria");

            while (true)
            {
                Console.WriteLine("Would you like to place an order, find existing orders, or exit? (order/find/exit)");
                string input = Console.ReadLine().ToLower();

                if (input == "exit")
                {
                    Console.WriteLine("Thank you for visiting! Have a great day!");
                    break;
                }
                else if (input == "order")
                {
                    PlaceOrder();
                }
                else if (input == "find")
                {
                    FindOrders();
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        static void PlaceOrder()
        {
            Order order = new Order();

            Console.WriteLine("Here is our menu:");
            menu.PrintMenu();

            while (true)
            {
                // Choose a pizza
                Console.WriteLine("Please choose a pizza by entering its number:");
                int pizzaChoice = Convert.ToInt32(Console.ReadLine());
                Pizza selectedPizza = menu.GetPizza(pizzaChoice);
                if (selectedPizza != null)
                {
                    order.AddPizza(selectedPizza);

                    // Ask for extra topping
                    while (true)
                    {
                        Console.WriteLine("Would you like to add extra toppings? (yes/no)");
                        string input = Console.ReadLine().ToLower();
                        if (input == "no")
                        {
                            break;
                        }
                        else if (input == "yes")
                        {
                            Console.WriteLine("Please choose an extra topping by entering its number:");
                            int toppingChoice = Convert.ToInt32(Console.ReadLine());
                            ExtraTopping selectedTopping = menu.GetExtraTopping(toppingChoice);
                            if (selectedTopping != null)
                            {
                                order.AddExtraTopping(selectedTopping);
                            }
                            else
                            {
                                Console.WriteLine("Invalid topping choice!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                    }

                    
                    Console.WriteLine("Would you like to add another pizza? (yes/no)");
                    string anotherPizzaInput = Console.ReadLine().ToLower();
                    if (anotherPizzaInput == "no")
                    {
                        break;
                    }
                    else if (anotherPizzaInput != "yes")
                    {
                        Console.WriteLine("Invalid input! Assuming 'no'.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid pizza choice!");
                    return;
                }
            }

            // Choose beverage
            Console.WriteLine("Please choose a beverage by entering its number:");
            int beverageChoice = Convert.ToInt32(Console.ReadLine());
            Beverage selectedBeverage = menu.GetBeverage(beverageChoice);
            if (selectedBeverage != null)
            {
                order.AddBeverage(selectedBeverage);
            }
            else
            {
                Console.WriteLine("Invalid beverage choice!");
                return;
            }

            orders.Add(order);
            int orderNumber = orders.Count; // Get order number
            Console.WriteLine($"Your order (Order Number: {orderNumber}) has been added!");
            order.PrintOrder(customer.Name);
        }



        static void FindOrders()
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("No orders found.");
                return;
            }

            Console.WriteLine("Enter the order number to view the details:");
            int orderNumber = Convert.ToInt32(Console.ReadLine());
            if (orderNumber <= 0 || orderNumber > orders.Count)
            {
                Console.WriteLine("Invalid order number!");
                return;
            }

            Order order = orders[orderNumber - 1];
            Console.WriteLine("");
            Console.WriteLine("Order Details: ");
            Console.WriteLine("Order Number: "+orderNumber);
            order.PrintOrder(customer.Name);
        }

        static Menu MakeMenu()
        {
            Menu menu = new Menu();

            // Adding pizza
            menu.AddPizza(new Pizza("1.Margherita", new List<string> { "Tomato sauce", "Mozzarella", "Basil" }, 55, 1));
            menu.AddPizza(new Pizza("2.Vesuvio", new List<string> { "Tomato sauce", "Chesse", "Ham" }, 65, 2));
            menu.AddPizza(new Pizza("3.Capricciosa", new List<string> { "Tomato sauce", "Mozzarella", "Ham", "Mushrooms" }, 75, 3));
            menu.AddPizza(new Pizza("4.Calzone", new List<string> { "Baked Pizza with Tomato sauce", "Chesse", "Ham", "Mushrooms" }, 75, 4));
            menu.AddPizza(new Pizza("5.Quattro Stagioni", new List<string> { "Tomato","Chesse","Ham","Mushrooms","Shrimp","Peppers" }, 80, 5));
            // Adding beverage
            menu.AddBeverage(new Beverage("1.Coke", 20, 1));
            menu.AddBeverage(new Beverage("2.Fanta", 20, 2));
            menu.AddBeverage(new Beverage("3.Water", 10, 3));
            menu.AddBeverage(new Beverage("4.Wine", 20, 4));

            // Adding extra topping
            menu.AddExtraTopping(new ExtraTopping("1.Extra Cheese", 20, 1));
            menu.AddExtraTopping(new ExtraTopping("2.Mushrooms", 15, 2));
            menu.AddExtraTopping(new ExtraTopping("3.Olives", 22, 3));


            return menu;
        }

        static Customer ChooseCustomer()
        {
        
            Console.WriteLine("Please choose your name, please:");
            string name = Console.ReadLine();
            return new Customer(name);
        }
    } 
}
