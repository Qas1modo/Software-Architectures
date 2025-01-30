namespace SharedKernel.Messages;

public record RoomOrderFulfilledMessage(Guid GlobalGuestId, Guid RoomOrderId, decimal TotalPrice);
