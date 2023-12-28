namespace ClientAPI.Models;

public partial class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public double Price { get; set; }
}