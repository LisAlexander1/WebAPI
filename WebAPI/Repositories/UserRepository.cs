using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Repositories;

public class UserRepository : EfCoreRepository<User, ProductsDbContext>
{
    public UserRepository(ProductsDbContext context) : base(context)
    {
        
    }

    public async Task<User?> GetByLogin(string login)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Login == login);
    }
}