using Microsoft.EntityFrameworkCore;
using RandomDateLib;
using BCrypt.Net;

namespace WebAPI.Models;

public sealed class ProductsDbContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Sale> Sales { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    public ProductsDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        var admin = new User() { Id = Guid.NewGuid(), Login = "admin@example.com", Password = BCrypt.Net.BCrypt.HashPassword("admin")};
        modelBuilder.Entity<User>().HasIndex(u => u.Login).IsUnique();
        modelBuilder.Entity<User>().HasData(admin);


        var products = new List<Product>()
        {
            new() {Id = Guid.NewGuid(), Name = "Яблоко", Price = 10 },
            new() {Id = Guid.NewGuid(), Name = "Груша", Price = 5040 },
            new() {Id = Guid.NewGuid(), Name = "Пистолет", Price = 7214 },
            new() {Id = Guid.NewGuid(), Name = "Лопасть вертолета Apache", Price = 8431 },
            new() {Id = Guid.NewGuid(), Name = "Первая ступень ракетоносителя Союз-1Б", Price = 3397 },
            new() {Id = Guid.NewGuid(), Name = "Schützenpanzerwagen", Price = 7543 },
            new() {Id = Guid.NewGuid(), Name = "Транзистор", Price = 5899 },
        };
        
        var sales = new List<Sale>();
        var r = new Random();
        for (int i = 0; i < 15; i++)
        {
            sales.Add(new()
            {
                Id = Guid.NewGuid(),
                ProductId = products[r.Next(products.Count)].Id,
                SellDateTime = RandomDate.GetRandomDay(2000),
                SellsCount = r.Next(1,100)
            });
        }
        
        modelBuilder.Entity<Product>().HasData(products);
        
        modelBuilder.Entity<Sale>().HasData(sales);
    }
}