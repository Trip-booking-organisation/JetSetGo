﻿namespace JetSetGo.Infrastructure.Autentification;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";
    public string Secret { get; init; } = null!;
    public string Issuer { get; init; }= null!;
    public string Audience { get; init; }= null!;
    public int ExpirationMinutes { get; init; }
}