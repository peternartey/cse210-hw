using System;

class Program
{
    static void Main(string[] args)
    {
        var address1 = new Address("123 leki", "Gwarinpa", "ABJ", "Nigeria", "12345");
        var customer1 = new Customer("Muna Uche", address1, "munauche@example.com", "555-1234");

        var address2 = new Address("1st Street", "Gwarinpa", "ABJ", "Nigeria", "67890");
        var customer2 = new Customer("Nmeso Fred", address2, "nmesofred@example.com", "555-5678");

        var product1 = new Product("Laptop", "ABC123", 10.99m, 2, "A small widget.");
        var product2 = new Product("Mouse", "DEF456", 5.99m, 3, "A handy gadget.");
        var product3 = new Product("Monitor", "GHI789", 7.99m, 1, "A mysterious thingamajig.");

        var order1 = new Order(customer1, 8.25m);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        var order2 = new Order(customer2, 8.25m);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine(order1.GetInvoice());

        Console.WriteLine("\nOrder 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine(order2.GetInvoice());
    }
}