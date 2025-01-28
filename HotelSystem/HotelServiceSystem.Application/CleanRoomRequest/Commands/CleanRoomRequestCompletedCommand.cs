using HotelServiceSystem.Application.Core.Abstractions.Messaging;
using HotelServiceSystem.Domain.Core.Primitives.Result;

namespace HotelServiceSystem.Application.CleanRoomRequest.Commands;

public record CleanRoomRequestCompletedCommand(Guid RequestId) : ICommand<Result>;

