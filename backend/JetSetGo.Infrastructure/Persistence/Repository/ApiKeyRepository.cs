using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Domain.ApiKeys;
using Microsoft.EntityFrameworkCore;

namespace JetSetGo.Infrastructure.Persistence.Repository;

public class ApiKeyRepository : IApikeyRepository
{ 
    private readonly JetSetGoContext _context;

    public ApiKeyRepository(JetSetGoContext context)
    {
        _context = context;
    }

    public async Task<ApiKey?> CreateApiKey(ApiKey apiKey)
    {
        var newApiKey = await _context.ApiKeys.AddAsync(apiKey);
        await _context.SaveChangesAsync();
        return newApiKey.Entity;
    }

    public async Task<ApiKey?> GetByToken(Guid token)
    {
        var apiKey = await _context.ApiKeys
            .FirstOrDefaultAsync(x => x.Token==token);
        await _context.SaveChangesAsync();
        return apiKey;
    }
}