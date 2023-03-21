using JetSetGo.Application.Persistence;
using JetSetGo.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace JetSetGo.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    protected readonly JetSetGoContext DbContext;

    public UserRepository(JetSetGoContext dbContext)
    {
        this.DbContext = dbContext;
    }

    public async Task<User> CreateAsync(User user)
    {
        await DbContext.Users.AddAsync(user);
        await DbContext.SaveChangesAsync();

        return user;
    }

    public async Task<User?> GetByEmail(string email)
    {
        var user = await DbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
        return user;
    }
    
}