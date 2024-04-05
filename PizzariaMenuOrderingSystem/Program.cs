using PizzariaMenuOrderingSystem;
using System;
using System.Collections.Generic;

namespace PizzaDeliverySystem
{

    class Program
    {
        static List<Order> orders = new List<Order>();
        static Menu menu = MakeMenu();
        static CustomerManager customerManager = new CustomerManager();

        static void Main(string[] args)
        {
            customerManager.AddCustomer(1, "John Doe", "john@example.com", "123 Main St");
            customerManager.AddCustomer(2, "Alice Smith", "alice@example.com", "456 Elm St");
            customerManager.AddCustomer(3, "Bob Johnson", "bob@example.com", "789 Oak St");

            Customer customer = ChooseCustomer();

            Console.WriteLine($"Welcome, {customer.Name}, to Big Mama pizzeria");

            while (true)
            {
                Console.WriteLine("Would you like to place an order, find existing orders, search for a customer, update a customer, delete a customer, or exit? (order/find/findcustomer/update/delete/exit)");
                string input = Console.ReadLine().ToLower();

                if (input == "exit")
                {
                    Console.WriteLine("Thank you for visiting! Have a great day!");
                    break;
                }
                else if (input == "order")
                {
                    PlaceOrder(customer);
                }
                else if (input == "find")
                {
                    FindOrders(customer);
                }
                else if (input == "findcustomer")
                {
                    Console.WriteLine("Enter the name of the customer you're looking for:");
                    string searchName = Console.ReadLine();
                    customerManager.SearchCustomer(searchName);
                }
                else if (input == "update")
                {
                    UpdateCustomer();
                }
                else if (input == "delete")
                {
                    DeleteCustomer();
                }
                else if (input == "orderadmin")
                {
                    OrderAdminO();
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }


        static void OrderAdminO()
        {
            while (true)
            {
                Console.WriteLine("Welcome, Order Admin!");
                Console.WriteLine("What would you like to do? (create/delete/update/exit)");
                string adminInput = Console.ReadLine().ToLower();
                switch (adminInput)
                {
                    case "create":
                        OrderAdmin.CreateOrder(orders, menu);
                        break;
                    case "delete":
                        OrderAdmin.DeleteOrder(orders);
                        break;
                    case "update":
                        OrderAdmin.UpdateOrder(orders, menu);
                        break;
                    case "exit":
                        Console.WriteLine("Exiting Order Admin mode.");
                        return;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            }
        }
        static void UpdateCustomer()
        {
            Console.WriteLine("Enter the ID of the customer to update:");
            int customerIdToUpdate = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the new name for the customer:");
            string newName = Console.ReadLine();
            Console.WriteLine("Enter the new email for the customer:");
            string newEmail = Console.ReadLine();
            Console.WriteLine("Enter the new address for the customer:");
            string newAddress = Console.ReadLine();
            customerManager.UpdateCustomer(customerIdToUpdate, newName, newEmail, newAddress);
        }

        static void DeleteCustomer()
        {
            Console.WriteLine("Enter the ID of the customer to delete:");
            int customerIdToDelete = int.Parse(Console.ReadLine());
            customerManager.DeleteCustomer(customerIdToDelete);
        }

        static Customer ChooseCustomer()  

        {
            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter your id");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter your email:");
            string email = Console.ReadLine();
            Console.WriteLine("Please enter your address:");
            string address = Console.ReadLine();
            return new Customer(id, name, email, address);
        }

        static void PlaceOrder(Customer customer)
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



        static void FindOrders(Customer customer)
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
            order.PrintOrder($"{customer.Name}, {customer.Id} ,{customer.Email} , {customer.Address}");
        }

        static Menu MakeMenu()
        {
            Menu menu = new Menu();

            // Adding pizza
            menu.AddPizza(new Pizza("1.Margherita", new List<string> { "Tomato sauce", "Mozzarella", "Basil" }, 55, 1));
            menu.AddPizza(new Pizza("2.Vesuvio", new List<string> { "Tomato sauce", "Chesse", "Ham" }, 65, 2));
            menu.AddPizza(new Pizza("3.Capricciosa", new List<string> { "Tomato sauce", "Mozzarella", "Ham", "Mushrooms" }, 75, 3));
            menu.AddPizza(new Pizza("4.Calzone", new List<string> { "Baked Pizza with Tomato sauce", "Chesse", "Ham", "Mushrooms" }, 75, 4));
            menu.AddPizza(new Pizza("5.Quattro Stagioni", new List<string> { "Tomato", "Chesse", "Ham", "Mushrooms", "Shrimp", "Peppers" }, 80, 5));
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


            // static Customer ChooseCustomer()
            //  {
            //
            //  Console.WriteLine("Please choose your name, please:");
            // string name = Console.ReadLine();
            // return new Customer();
            // }
        }
    } 
}
