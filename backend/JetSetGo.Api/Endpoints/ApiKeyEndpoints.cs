using backend.Dto.Requests.ApiKey;
using backend.Helpers;
using JetSetGo.Application.ApiKeys.Commands;
using JetSetGo.Application.ApiKeys.Queries;
using MediatR;

namespace backend.Endpoints;

public static class ApiKeyEndpoints
{
    public static void MapApiKeyEndpoints(this WebApplication application)
    {
        application.MapPost("api/api-keys", GenerateApiKey);
        application.MapGet("api/api-keys/{id:guid}", GetById);
    }

    private static async Task<IResult> GetById(ISender sender,Guid id)
    {
        var query = new GetByIdQuery(id);
        var result = await sender.Send(query);
        return Results.Ok(result);
    }

    private static async Task<IResult> GenerateApiKey(ISender sender,GenerateApiKeyRequest request)
    {
        var command = new GenerateApiKeyCommand(request.Id, request.Name,request.Expiration);
        var result = await sender.Send(command);
        return result.IsFailed ? Results.BadRequest(result.Errors.ToResponse())
            : Results.Created("/api/v1/api-keys/{id}", new { Id = result.Value.Id, Token = result.Value.Token});
    }
}