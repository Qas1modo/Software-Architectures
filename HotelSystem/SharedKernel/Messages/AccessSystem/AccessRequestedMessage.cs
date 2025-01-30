namespace SharedKernel.Messages.AccessSystem;

public record AccessRequestedMessage(Guid AccessCardId, Guid ClaimId);