using System;

public class Product
{
    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;
    private string _description;

    public Product(string name, string productId, decimal price, int quantity, string description)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
        _description = description;
    }

    public decimal GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productId;
    }

    public string GetDescription()
    {
        return _description;
    }
}