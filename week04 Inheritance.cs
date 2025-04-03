public class Product
{
    private string _name;
    private double _price;

    public Product(string name, double price)
    {
        _name = name;
        _price = price;
    }

    public double GetTotalCost()
    {
        return _price; // Base method that child classes can override or extend.
    }
}

public class Electronics : Product
{
    private int _warrantyPeriod;

    public Electronics(string name, double price, int warrantyPeriod) : base(name, price)
    {
        _warrantyPeriod = warrantyPeriod;
    }

    public override double GetTotalCost()
    {
        // Adding extra cost for warranty
        return base.GetTotalCost() + 50;
    }
}