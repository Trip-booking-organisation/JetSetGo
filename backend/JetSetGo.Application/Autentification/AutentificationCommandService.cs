using JetSetGo.Application.Persistence;
using JetSetGo.Domain.Users;

namespace JetSetGo.Application.Autentification;

public class AutentificationCommandService : IAutentificationCommandService
{
    private readonly IUserRepository _userRepository;

    public AutentificationCommandService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async  Task<AutentificationResult> Register(string firstName, string lastName, string email, string password)
    {
        // TODO Validate if user doesnt exist

        var user = new User
        {
            FirstName = firstName, 
            LastName = lastName, 
            Email = email, 
            Password = password
        };
        
        await _userRepository.CreateAsync(user);
        return new AutentificationResult(user.Id, user.FirstName, user.LastName, user.Email);
    }
}