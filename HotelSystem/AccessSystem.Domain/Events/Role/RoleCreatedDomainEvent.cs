using AccessSystem.Domain.Entities;
using SharedKernel.Domain.Core.Events;

namespace AccessSystem.Domain.Events.Role;

public record RoleCreatedDomainEvent(RoleEntity RoleEntity) : IDomainEvent;