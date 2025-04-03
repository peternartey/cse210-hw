using System;
using System.Collections.Generic;  // Add this to use List<T>

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double totalCost = 0;

        foreach (Product product in _products)
        {
            totalCost += product.GetTotalCost();
        }

        totalCost += GetShippingCost();

        return totalCost;
    }

    private double GetShippingCost()
    {
        return _customer.IsInUSA() ? 5 : 35;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "PACKING LABEL:\n";

        foreach (Product product in _products)
        {
            packingLabel += $"Product: {product.GetName()}, ID: {product.GetProductId()}\n";
        }

        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"SHIPPING LABEL:\nCustomer: {_customer.GetName()}\nAddress:\n{_customer.GetAddress().GetFullAddress()}";
    }
}

public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productId;
    }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }
}

public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName()
    {
        return _name;
    }

    public Address GetAddress()
    {
        return _address;
    }

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }
}

public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddress()
    {
        return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
        Console.WriteLine("Online Ordering System\n");

        Address usaAddress = new Address("123 Main St", "Seattle", "WA", "USA");
        Address internationalAddress = new Address("456 Maple Ave", "Toronto", "Ontario", "Canada");

        Customer usaCustomer = new Customer("John Smith", usaAddress);
        Customer internationalCustomer = new Customer("Jane Doe", internationalAddress);

        Product laptop = new Product("Laptop", "TECH001", 899.99, 1);
        Product headphones = new Product("Headphones", "TECH002", 59.99, 2);
        Product mouse = new Product("Wireless Mouse", "TECH003", 29.99, 1);
        Product keyboard = new Product("Mechanical Keyboard", "TECH004", 129.99, 1);
        Product monitor = new Product("Monitor", "TECH005", 249.99, 2);

        Order order1 = new Order(usaCustomer);
        order1.AddProduct(laptop);
        order1.AddProduct(headphones);
        order1.AddProduct(mouse);

        Order order2 = new Order(internationalCustomer);
        order2.AddProduct(monitor);
        order2.AddProduct(keyboard);

        Console.WriteLine("ORDER 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():F2}\n");

        Console.WriteLine("ORDER 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():F2}");
    }
}