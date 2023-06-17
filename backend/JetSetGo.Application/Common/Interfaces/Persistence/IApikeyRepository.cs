using JetSetGo.Domain.ApiKeys;

namespace JetSetGo.Application.Common.Interfaces.Persistence;

public interface IApikeyRepository
{
    Task<ApiKey?> CreateApiKey(ApiKey apiKey);
    Task<ApiKey?> GetByToken(Guid token);
}