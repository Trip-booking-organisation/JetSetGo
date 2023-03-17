using JetSetGo.Domain.Users;

namespace JetSetGo.Application.Persistence;

public interface IUserRepository 
{
    public Task<User> CreateAsync(User user);
    public Task<User?> GetByEmail(string email);
}