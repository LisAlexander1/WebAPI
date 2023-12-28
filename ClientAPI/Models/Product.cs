namespace ClientAPI.Models;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public double Price { get; set; }

    public override int GetHashCode() => Id.GetHashCode();

    public override bool Equals(object? obj)
    {
        if (obj is Product product) return Id == product.Id;
        return false;
    }
}