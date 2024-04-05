using PizzaDeliverySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaMenuOrderingSystem
{
    class OrderAdmin
    {
        public static void CreateOrder(List<Order> orders, Menu menu)
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
            Console.WriteLine($"The order (Order Number: {orderNumber}) has been created!");
            order.PrintOrder();
        }

        public static void DeleteOrder(List<Order> orders)
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("No orders found.");
                return;
            }

            Console.WriteLine("Enter the order number to delete:");
            int orderNumberToDelete = Convert.ToInt32(Console.ReadLine());
            if (orderNumberToDelete <= 0 || orderNumberToDelete > orders.Count)
            {
                Console.WriteLine("Invalid order number!");
                return;
            }

            orders.RemoveAt(orderNumberToDelete - 1);
            Console.WriteLine($"Order {orderNumberToDelete} has been deleted.");
        }

        public static void UpdateOrder(List<Order> orders, Menu menu)
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("No orders found.");
                return;
            }

            Console.WriteLine("Enter the order number to update:");
            int orderNumberToUpdate = Convert.ToInt32(Console.ReadLine());
            if (orderNumberToUpdate <= 0 || orderNumberToUpdate > orders.Count)
            {
                Console.WriteLine("Invalid order number!");
                return;
            }

            Order order = orders[orderNumberToUpdate - 1];
            Console.WriteLine("Update order:");
            order.PrintOrder();

            Console.WriteLine("Would you like to add extra items to the order? (yes/no)");
            string addExtraItemsInput = Console.ReadLine().ToLower();
            if (addExtraItemsInput == "yes")
            {
                
                while (true)
                {
                    Console.WriteLine("Here is our menu:");
                    menu.PrintMenu();
                    Console.WriteLine("Please choose a pizza, beverage, or extra topping by entering its number (or enter 0 to stop adding items):");
                    int itemChoice = Convert.ToInt32(Console.ReadLine());
                    if (itemChoice == 0)
                        break;
                    else if (itemChoice <= menu.Pizzas.Count)
                        order.AddPizza(menu.GetPizza(itemChoice));
                    else if (itemChoice <= menu.Pizzas.Count + menu.Beverages.Count)
                        order.AddBeverage(menu.GetBeverage(itemChoice - menu.Pizzas.Count));
                    else if (itemChoice <= menu.Pizzas.Count + menu.Beverages.Count + menu.ExtraToppings.Count)
                        order.AddExtraTopping(menu.GetExtraTopping(itemChoice - menu.Pizzas.Count - menu.Beverages.Count));
                    else
                        Console.WriteLine("Invalid choice!");
                }
            }

            Console.WriteLine("Order updated successfully.");
            order.PrintOrder();
        }
    }
}
