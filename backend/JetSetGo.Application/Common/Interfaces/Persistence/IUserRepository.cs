using JetSetGo.Domain.Users;

namespace JetSetGo.Application.Common.Interfaces.Persistence;

public interface IUserRepository 
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByEmail(string email);
    Task<User?> GetById(Guid id);

}