namespace JetSetGo.Application.Common.Interfaces.Autentification;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userID, string firstName, string secondName);

}