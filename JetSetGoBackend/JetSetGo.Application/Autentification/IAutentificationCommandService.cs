namespace JetSetGo.Application.Autentification;

public interface IAutentificationCommandService
{
    Task<AutentificationResult> Register(string firstName, string LastName, string Email, string password);
}