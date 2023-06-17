using JetSetGo.Domain.Users;

namespace JetSetGo.Domain.ApiKeys;

public class ApiKey
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid Token { get; set; }
    public string Name { get; set; } = null!;
    public DateTime? ExpirationDate { get; set; }
    public bool HasExpiration { get; set; }
}