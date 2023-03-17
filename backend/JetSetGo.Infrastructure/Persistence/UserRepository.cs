using JetSetGo.Application.Persistence;
using JetSetGo.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace JetSetGo.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    protected readonly JetSetGoContext dbContext;

    public UserRepository(JetSetGoContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<User> CreateAsync(User user)
    {
        await dbContext.Users.AddAsync(user);
        return user;
    }

    public async Task<User?> GetByEmail(string email)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
        return user;
    }
    
}