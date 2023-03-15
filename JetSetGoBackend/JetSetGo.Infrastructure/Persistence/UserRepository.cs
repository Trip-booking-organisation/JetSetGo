using JetSetGo.Application.Persistence;
using JetSetGo.Domain.User;

namespace JetSetGo.Infrastructure.Persistence;

public class UserRepository : GenericRepository<User>,IUserRepository
{
    public UserRepository(JetSetGoContext dbContext) : base(dbContext)
    {
    }
    
}