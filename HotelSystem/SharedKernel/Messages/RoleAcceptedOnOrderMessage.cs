namespace SharedKernel.Messages;

public record RoleAcceptedOnOrderMessage(Guid GlobalGuestId, Guid PremiumOrderId);
