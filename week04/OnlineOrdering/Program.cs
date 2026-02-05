using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("ONLINE ORDERING SYSTEM\n");

        // Create addresses
        Address address1 = new Address("123 Main St", "Los Angeles", "CA", "USA");
        Address address2 = new Address("456 Oak Ave", "Toronto", "Ontario", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Maria Garcia", address2);

        // Create products
        Product product1 = new Product("Laptop", "P001", 999.99, 1);
        Product product2 = new Product("Mouse", "P002", 29.99, 2);
        Product product3 = new Product("Keyboard", "P003", 79.99, 1);
        Product product4 = new Product("Monitor", "P004", 299.99, 1);
        Product product5 = new Product("USB Cable", "P005", 19.99, 3);

        // Create Order 1
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        // Create Order 2
        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // Display Order 1 details
        Console.WriteLine("ORDER 1 DETAILS");
        Console.WriteLine("================");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():0.00}\n");

        // Display Order 2 details
        Console.WriteLine("ORDER 2 DETAILS");
        Console.WriteLine("================");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():0.00}\n");

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}