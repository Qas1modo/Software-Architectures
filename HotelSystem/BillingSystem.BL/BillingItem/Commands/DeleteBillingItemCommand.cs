using MediatR;

namespace BillingSystem.Application.BillingItem.Commands;

public record DeleteBillingItemCommand(int Id) : IRequest<bool>;
