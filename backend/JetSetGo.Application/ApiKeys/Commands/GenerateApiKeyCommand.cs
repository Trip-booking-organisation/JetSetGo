using FluentResults;
using MediatR;

namespace JetSetGo.Application.ApiKeys.Commands;

public record GenerateApiKeyCommand(Guid UserId,
    string Name, bool Expiration) : IRequest<Result<GenerateApiKeyResponse>>;
