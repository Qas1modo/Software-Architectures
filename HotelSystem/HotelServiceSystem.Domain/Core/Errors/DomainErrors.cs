using HotelServiceSystem.Contracts.Enumerations;
using HotelServiceSystem.Domain.Core.Primitives;
using HotelServiceSystem.Domain.ValueObjects;

namespace HotelServiceSystem.Domain.Core.Errors
{
    /// <summary>
    /// Contains the domain errors.
    /// </summary>
    public static class DomainErrors
    {
        public static class CleanRoomRequestErrors
        {
            public static Error DeadlineRequired => new("CleanRoomRequestErrors.Deadline", "Deadline is required when creating a CleanRoomRequest.");
            public static Error RoomNumberRequired => new("CleanRoomRequestErrors.RoomNumber", "Room number is required when creating a CleanRoomRequest.");
            public static Error EmployeeRequired => new("CleanRoomRequestErrors.Employee", "An employee is required when creating a CleanRoomRequest.");
            public static Error InvalidEmployeeId => new("CleanRoomRequestErrors.InvalidEmployeeId", "Employee ID cannot be empty.");
            public static Error AlreadyProcessed => new("CleanRoomRequestErrors.AlreadyProcessed", "Clean Room Request is already processed.");
        }

        public static class EmployeeErrors
        {
            public static Error FirstNameRequired => new("EmployeeErrors.FirstName", "First name is required for an employee.");
            public static Error LastNameRequired => new("EmployeeErrors.LastName", "Last name is required for an employee.");
        }

        public static class GuestErrors
        {
            public static Error NotFound => new("GuestErrors.Guest", "Guest not found !");
            public static Error InvalidGlobalGuestId => new("GuestErrors.InvalidGlobalGuestId", "Global Guest ID cannot be empty.");
            public static Error FirstNameRequired => new("GuestErrors.FirstNameRequired", "First name is required for a guest.");
            public static Error LastNameRequired => new("GuestErrors.LastNameRequired", "Last name is required for a guest.");
            public static Error EmailRequired => new("GuestErrors.EmailRequired", "Email is required for a guest.");
            public static Error GuestRoomRequired => new("GuestErrors.GuestRoomRequired", "Guest room number is required for a guest.");
            public static Error AlreadyInactive => new("GuestErrors.AlreadyInactive", "Guest is already inactive.");
        }

        public static class PremiumServiceErrors
        {
            public static Error NotFound => new("PremiumServiceErrors.PremiumService", "Premium service not found !");
            public static Error NameRequired => new("PremiumServiceErrors.Name", "Name is required for a Premium Service.");
            public static Error DescriptionRequired => new("PremiumServiceErrors.Description", "Description is required for a Premium Service.");
            public static Error ImageRequired => new("PremiumServiceErrors.Image", "Image is required for a Premium Service.");
            public static Error InvalidPrice => new("PremiumServiceErrors.InvalidPrice", "Price is invalid for a Premium Service.");
            public static Error RelevantRoleCodeNameRequired => new("PremiumServiceErrors.RelevantRoleCodeName", "Relevant Role Code Name is required for a Premium Service.");
        }

        public static class PremiumServiceOrderErrors
        {
            public static Error PremiumServiceRequired => new("PremiumServiceOrderErrors.PremiumServiceRequired", "Premium service is required for an order.");
            public static Error InvalidOrderedPremiumServiceId => new("PremiumServiceOrderErrors.InvalidOrderedPremiumServiceId", "Premium service ID cannot be empty.");
            public static Error GuestRequired => new("PremiumServiceOrderErrors.GuestRequired", "Guest is required for an order.");
            public static Error InvalidGuestId => new("PremiumServiceOrderErrors.InvalidGuestId", "Guest ID cannot be empty.");
            public static Error InvalidStatusChange(OrderStatusEnum currentStatus, OrderStatusEnum targetStatus) =>
                new($"PremiumServiceOrderErrors.InvalidStatusChange({currentStatus})", $"Cannot change order status from {currentStatus} to {targetStatus}.");
        }

        public static class RoomServiceErrors
        {
            public static Error NotFound => new("RoomServiceErrors.RoomService", "Room service not found !");
            public static Error NameRequired => new("RoomServiceErrors.Name", "Name is required for a Room Service.");
            public static Error DescriptionRequired => new("RoomServiceErrors.Description", "Description is required for a Room Service.");
            public static Error ImageRequired => new("RoomServiceErrors.Image", "Image is required for a Room Service.");
            public static Error InvalidPrice => new("RoomServiceErrors.InvalidPrice", "Price is invalid for a Room Service.");
        }

        public static class RoomServiceOrderErrors
        {
            public static Error GuestRequired => new("RoomServiceOrderErrors.GuestRequired", "Guest is required for a Room Service Order.");
            public static Error InvalidGuestId => new("RoomServiceOrderErrors.InvalidGuestId", "Guest ID cannot be empty.");
            public static Error InvalidStatusChange(OrderStatusEnum currentStatus, OrderStatusEnum targetStatus) =>
                new($"RoomServiceOrderErrors.InvalidStatusChange({currentStatus})", $"Cannot change order status from {currentStatus} to {targetStatus}.");
        }

        public static class RoomServiceOrderItemErrors
        {
            public static Error InvalidUnitPrice => new("RoomServiceOrderItemErrors.InvalidUnitPrice", "Unit price cannot be empty for a Room Service Order Item.");
            public static Error InvalidAmount => new("RoomServiceOrderItemErrors.InvalidAmount", "Amount cannot be empty for a Room Service Order Item.");
            public static Error RoomServiceRequired => new("RoomServiceOrderItemErrors.RoomServiceRequired", "Room Service is required for a Room Service Order Item.");
            public static Error InvalidRoomServiceId => new("RoomServiceOrderItemErrors.InvalidRoomServiceId", "Room Service ID cannot be empty.");
            public static Error RoomServiceOrderRequired => new("RoomServiceOrderItemErrors.RoomServiceOrderRequired", "Room Service Order is required for a Room Service Order Item.");
            public static Error InvalidRoomServiceOrderId => new("RoomServiceOrderItemErrors.InvalidRoomServiceOrderId", "Room Service Order ID cannot be empty.");
        }

        public static class EmailErrors
        {
            public static Error NullOrEmpty => new("EmailErrors.NullOrEmpty", "Email cannot be null or empty.");
            public static Error LongerThanAllowed => new("EmailErrors.LongerThanAllowed", $"Email cannot exceed {Email.MaxLength} characters.");
            public static Error InvalidFormat => new("EmailErrors.InvalidFormat", "Email has an invalid format.");
        }

        public static class FirstNameErrors
        {
            public static Error NullOrEmpty => new("FirstNameErrors.NullOrEmpty", "First name cannot be null or empty.");
            public static Error LongerThanAllowed => new("FirstNameErrors.LongerThanAllowed", $"First name cannot exceed {FirstName.MaxLength} characters.");
        }

        public static class LastNameErrors
        {
            public static Error NullOrEmpty => new("LastNameErrors.NullOrEmpty", "Last name cannot be null or empty.");
            public static Error LongerThanAllowed => new("LastNameErrors.LongerThanAllowed", $"Last name cannot exceed {LastName.MaxLength} characters.");
        }

        public static class OrderItemAmountErrors
        {
            public static Error NullOrEmpty => new("OrderItemAmountErrors.NullOrEmpty", "Order Item Amount cannot be null or empty.");
            public static Error CannotBeNegative => new("OrderItemAmountErrors.CannotBeNegative", "Order Item Amount cannot be negative.");
            public static Error LargerThanAllowed => new("OrderItemAmountErrors.LargerThanAllowed", $"Order Item Amount cannot exceed {OrderItemAmount.MaxOrderItemCount}.");
        }

        public static class PriceErrors
        {
            public static Error NullOrEmpty => new("PriceErrors.NullOrEmpty", "Price cannot be null or empty.");
            public static Error CannotBeNegative => new("PriceErrors.CannotBeNegative", "Price cannot be negative.");
            public static Error LargerThanAllowed => new("PriceErrors.LargerThanAllowed", $"Price cannot exceed {Price.MaxPrice}.");
        }

        public static class ServiceNameErrors
        {
            public static Error NullOrEmpty => new("ServiceNameErrors.NullOrEmpty", "Service name cannot be null or empty.");
            public static Error LongerThanAllowed => new("ServiceNameErrors.LongerThanAllowed", $"Service name cannot exceed {ServiceName.MaxLength} characters.");
        }

        public static class ServiceDescriptionErrors
        {
            public static Error NullOrEmpty => new("ServiceDescriptionErrors.NullOrEmpty", "Service description cannot be null or empty.");
            public static Error LongerThanAllowed => new("ServiceDescriptionErrors.LongerThanAllowed", $"Service description cannot exceed {ServiceDescription.MaxLength} characters.");
        }

        public static class ServiceImageErrors
        {
            public static Error NullOrEmpty => new("ServiceImageErrors.NullOrEmpty", "Service image URL cannot be null or empty.");
            public static Error LongerThanAllowed => new("ServiceImageErrors.LongerThanAllowed", $"Service image URL cannot exceed {ServiceImage.MaxLength} characters.");
        }

        public static class General
        {
            public static Error ServerError => new("General.ServerError", "An unexpected server error occurred.");
            public static Error UnProcessableRequest => new("General.UnProcessableRequest", "The server could not process the request.");
        }
    }
}
