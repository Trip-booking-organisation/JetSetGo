using System.Text;
using FluentResults;
using JetSetGo.Application.Common.Errors;
using JetSetGo.Application.Common.Interfaces.Persistence;
using JetSetGo.Domain.ApiKeys;
using MediatR;

namespace JetSetGo.Application.ApiKeys.Commands;

public class GenerateApiKeyCommandHandler : IRequestHandler<GenerateApiKeyCommand,Result<GenerateApiKeyResponse>>
{
    private readonly IApikeyRepository _apikeyRepository;
    private readonly IUserRepository _userRepository;

    public GenerateApiKeyCommandHandler(IApikeyRepository apikeyRepository, IUserRepository userRepository)
    {
        _apikeyRepository = apikeyRepository;
        _userRepository = userRepository;
    }

    public async Task<Result<GenerateApiKeyResponse>> Handle(GenerateApiKeyCommand request, CancellationToken cancellationToken)
    {
        var user =await _userRepository.GetById(request.UserId);
        if(user is null)
            return Result.Fail<GenerateApiKeyResponse>(UserErrors.UserNotFound);
        var apiKey = new ApiKey
        {
            UserId = user.Id,
            Name = request.Name,
            Token = Guid.NewGuid(),
            HasExpiration = false
        };
        if (request.Expiration)
        {
            apiKey.HasExpiration = true;
            apiKey.ExpirationDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day + 1);
        }
        
        var result = await _apikeyRepository.CreateApiKey(apiKey);
        var builder = BuildApiKeyResponse(result);
        var response = new GenerateApiKeyResponse
        {
            Id = result!.Id,
            Token = builder
        };
        return Result.Ok(response);
    }

    private static string BuildApiKeyResponse(ApiKey? result)
    {
        var builder = new StringBuilder();
        builder.Append(result!.Token.ToString());
        builder.Append("==");
        builder.Append(result.UserId.ToString());
        return builder.ToString();
    }
}