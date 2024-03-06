using PizzariaMenuOrderingSystem;

class Order
{
    private List<Pizza> pizzas;
    private List<ExtraTopping> extraToppings;
    private List<Beverage> beverages;

    public Order()
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

    public double CalculateTotalPrice()
    {
        double totalPrice = 0;

        foreach (Pizza pizza in pizzas)
        {
            totalPrice += pizza.Price;
        }
        foreach (ExtraTopping topping in extraToppings)
        {
            totalPrice += topping.Price;
        }
        foreach (Beverage beverage in beverages)
        {
            totalPrice += beverage.Price;
        }

        totalPrice += 40; 
        totalPrice *= 1.08; 

        return totalPrice;
    }

    public void PrintOrder(string customerName)
    {
        Console.WriteLine($"Customer Name: {customerName}");
        Console.WriteLine("Items:");
        foreach (Pizza pizza in pizzas)
        {
            Console.WriteLine($"Pizza: {pizza.Name}, Price: ${pizza.Price:F2}");
        }
        foreach (ExtraTopping topping in extraToppings)
        {
            Console.WriteLine($"- Extra Topping: {topping.Name}, Price: ${topping.Price:F2}");
        }
        foreach (Beverage beverage in beverages)
        {
            Console.WriteLine($"Beverage: {beverage.Name}, Price: ${beverage.Price:F2}");
        }
        Console.WriteLine("Delivery fee: $40");
        Console.WriteLine("Tax fee: 8%");
        Console.WriteLine($"Total Price: ${CalculateTotalPrice():F2}");
        Console.WriteLine("");
    }

}
