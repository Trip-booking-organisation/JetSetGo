using FluentResults;
using MediatR;

namespace JetSetGo.Application.ApiKeys.Queries;

public record GetByIdQuery(Guid Id) : IRequest<Result<GetByIdResponse>>;
