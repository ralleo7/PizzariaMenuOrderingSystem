using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzariaMenuOrderingSystem
{
    public class CustomerManager
    {
        private List<Customer> customers;

        public CustomerManager()
        {
            customers = new List<Customer>();
        }

        public void AddCustomer(int id, string name, string email, string address)
        {
            Customer newCustomer = new Customer(id, name, email, address);
            customers.Add(newCustomer);
            Console.WriteLine("Customer added successfully.");
        }

        public void DeleteCustomer(int id)
        {
            Customer customerToDelete = customers.FirstOrDefault((Customer c) => c.Id == id);
            if (customerToDelete != null)
            {
                customers.Remove(customerToDelete);
                Console.WriteLine("Customer deleted successfully.");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }

        public void UpdateCustomer(int id, string newName, string newEmail, string newAddress)
        {
            Customer customerToUpdate = customers.FirstOrDefault((Customer c) => c.Id == id);
            if (customerToUpdate != null)
            {
                customerToUpdate.Name = newName;
                customerToUpdate.Email = newEmail;
                customerToUpdate.Address = newAddress;
                Console.WriteLine("Customer updated successfully.");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }

        public void SearchCustomer(string name)
        {
            List<Customer> searchResults = customers.Where((Customer c) => c.Name.ToLower().Contains(name.ToLower())).ToList();
            if (searchResults.Any())
            {
                Console.WriteLine("Search Results:");
                foreach (Customer customer in searchResults)
                {
                    Console.WriteLine($"ID: {customer.Id}, Name: {customer.Name}, Email: {customer.Email}, Address: {customer.Address}");
                }
            }
            else
            {
                Console.WriteLine("No customers found matching the search criteria.");
            }
        }

        
        public Customer GetCustomer(int customerId)
        {
            return customers.FirstOrDefault(c => c.Id == customerId);
        }
    }
}
