namespace JetSetGo.Application.Common.Interfaces.Autentification;

public interface IPasswordHasher
{
    bool Verify(string passwordHash, string inputPassword);

    string Hash(string password);
}