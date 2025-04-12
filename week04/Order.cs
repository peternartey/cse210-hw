using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;
    private const decimal UsaShippingCost = 5.00m;
    private const decimal InternationalShippingCost = 35.00m;
    private decimal _taxRate;

    public Order(Customer customer, decimal taxRate)
    {
        _customer = customer;
        _taxRate = taxRate;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetSubtotal()
    {
        decimal subtotal = 0;
        foreach (var product in _products)
        {
            subtotal += product.GetTotalCost();
        }
        return subtotal;
    }

    public decimal GetTax()
    {
        return GetSubtotal() * _taxRate / 100;
    }

    public decimal GetTotalCost()
    {
        decimal totalCost = GetSubtotal() + GetTax();
        if (_customer.IsUSACustomer())
        {
            totalCost += UsaShippingCost;
        }
        else
        {
            totalCost += InternationalShippingCost;
        }
        return totalCost;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";
        foreach (var product in _products)
        {
            packingLabel += $"Product: {product.GetName()} ({product.GetProductId()})\nDescription: {product.GetDescription()}\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"Customer: {_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}\nEmail: {_customer.GetEmail()}\nPhone: {_customer.GetPhoneNumber()}";
    }

    public string GetInvoice()
    {
        string invoice = $"Invoice for {_customer.GetName()}\n";
        invoice += $"Subtotal: {GetSubtotal():C}\n";
        invoice += $"Tax ({_taxRate}%): {GetTax():C}\n";
        invoice += $"Total: {GetTotalCost():C}\n";
        return invoice;
    }
}