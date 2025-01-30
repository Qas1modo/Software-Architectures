namespace SharedKernel.Messages;

public record PremiumOrderCreatedMessage(Guid GlobalGuestId, Guid PremiumOrderId, string RelevantRoleCodeName);
