using HotelServiceSystem.Contracts.Enumerations;
using HotelServiceSystem.Domain.Core.Abstractions;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives;
using HotelServiceSystem.Domain.Core.Utility;
using HotelServiceSystem.Domain.ValueObjects;

namespace HotelServiceSystem.Domain.Entities
{
    public sealed class Employee : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
    {
        public Employee(FirstName employeeFirstName, LastName employeeLastName, EmployeeTypeEnum employeeType) : base(Guid.NewGuid())
        {
            Ensure.NotEmpty(employeeFirstName, DomainErrors.EmployeeErrors.FirstNameRequired, nameof(employeeFirstName));
            Ensure.NotEmpty(employeeLastName, DomainErrors.EmployeeErrors.LastNameRequired, nameof(employeeLastName));
            EmployeeFirstName = employeeFirstName;
            EmployeeLastName = employeeLastName;
            EmployeeType = employeeType;
        }

        private Employee() { } // Required by EF Core

        public FirstName EmployeeFirstName { get; private set; } = null!;
        public LastName EmployeeLastName { get; private set; } = null!;
        public EmployeeTypeEnum EmployeeType { get; private set; }

        // Mandatory fields

        public DateTime CreatedOnUtc { get; }
        public DateTime? ModifiedOnUtc { get; }
        public DateTime? DeletedOnUtc { get; }
        public bool Deleted { get; }
    }
}
