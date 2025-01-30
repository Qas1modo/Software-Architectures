namespace SharedKernel.Messages;

public record RoleDeniedOnOrderMessage(Guid GlobalGuestId, Guid PremiumOrderId, string Reason);
