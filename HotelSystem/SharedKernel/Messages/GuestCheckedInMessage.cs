namespace SharedKernel.Messages
{
    public record GuestCheckedInMessage(Guid GlobalGuestId, int GuestRoomNumber,
        string GuestFirstName, string GuestLastName, string GuestEmail);
}
