using MediatR;

namespace BillingSystem.BL.Commands.BillingItemCommands;

public record DeleteBillingItemCommand(int Id) : IRequest<bool>;
