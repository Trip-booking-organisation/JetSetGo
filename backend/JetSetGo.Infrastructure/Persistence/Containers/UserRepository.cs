using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace JetSetGo.Infrastructure.Persistence.Containers;

public class UserRepository : IUserRepository
{
    private readonly JetSetGoContext _dbContext;

    public UserRepository(JetSetGoContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> CreateAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User?> GetByEmail(string email)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
        return user;
    }

    public async Task<User?> GetById(Guid id)
    {
        var user =  await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        return user;
    }
}