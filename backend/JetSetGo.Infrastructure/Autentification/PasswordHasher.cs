﻿using System.Security.Authentication;
using System.Security.Cryptography;
using JetSetGo.Application.Common.Interfaces.Autentification;

namespace JetSetGo.Infrastructure.Autentification;

public class PasswordHasher : IPasswordHasher
{
    private const int SaltSize = 128 / 8;
    private const int KeySize = 256 / 8;
    private const int Iterations = 10000;
    private static readonly  HashAlgorithmName HashAlgorithmName = HashAlgorithmName.SHA256;
    private const char Delimiter = ';';
    
    public bool Verify(string passwordHash, string inputPassword)
    {
        var elements = passwordHash.Split(Delimiter);
        var salt = Convert.FromBase64String(elements[0]);
        var hash = Convert.FromBase64String(elements[1]);

        var inputHashed = Rfc2898DeriveBytes.Pbkdf2(inputPassword, salt, Iterations,
            HashAlgorithmName, KeySize);
        return CryptographicOperations.FixedTimeEquals(hash, inputHashed);

    }

    public string Hash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations,
            HashAlgorithmName, KeySize);
        return string.Join(Delimiter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
    }
}