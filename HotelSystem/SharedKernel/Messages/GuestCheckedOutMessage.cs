namespace SharedKernel.Messages
{
    public record GuestCheckedOutMessage(Guid GlobalGuestId, int GuestRoomNumber,
        string GuestFirstName, string GuestLastName, string GuestEmail);
}
