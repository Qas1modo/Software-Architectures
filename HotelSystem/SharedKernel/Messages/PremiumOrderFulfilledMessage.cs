namespace SharedKernel.Messages;

public record PremiumOrderFulfilledMessage(Guid GlobalGuestId, Guid PremiumOrderId, decimal Price);
