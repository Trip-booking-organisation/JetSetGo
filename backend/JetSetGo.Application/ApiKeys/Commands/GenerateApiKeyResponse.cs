namespace JetSetGo.Application.ApiKeys.Commands;

public class GenerateApiKeyResponse
{
    public Guid Id { get; set; }
    public string Token { get; set; } = null!;
}