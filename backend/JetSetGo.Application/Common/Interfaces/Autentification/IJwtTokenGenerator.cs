namespace JetSetGo.Application.Common.Interfaces.Autentification;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string firstName, string secondName,string email);

}