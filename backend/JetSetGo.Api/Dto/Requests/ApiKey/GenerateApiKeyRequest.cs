namespace backend.Dto.Requests.ApiKey;

public class GenerateApiKeyRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public bool Expiration { get; set; }
}