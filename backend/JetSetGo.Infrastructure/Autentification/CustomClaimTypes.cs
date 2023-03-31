namespace JetSetGo.Infrastructure.Autentification;

public static  class CustomClaimTypes
{
    public const string Subject = "sub";
    public const string Issuer = "iss";
    public const string Audience = "aud";
    public const string Expiration = "exp";
    public const string NotBefore = "nbf";
    public const string IssuedAt = "iat";
    public const string JwtId = "jti";
    public const string GivenName = "given_name";
    public const string FamilyName = "family_name";
    public const string Email = "email";
    public const string Role = "role";
}