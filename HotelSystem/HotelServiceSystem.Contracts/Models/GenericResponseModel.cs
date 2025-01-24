namespace HotelServiceSystem.Contracts.Models;

public class GenericResponseModel
{
    public string Message { get; set; } = null!;

    public bool Success { get; set; }
}
