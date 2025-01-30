using AccessSystem.Contracts.Models.AccessRequest;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.AccessRequest.Commands;

public record AccessRequestCommand(RequestAccessModel RequestAccessModel) : ICommand<Result>;