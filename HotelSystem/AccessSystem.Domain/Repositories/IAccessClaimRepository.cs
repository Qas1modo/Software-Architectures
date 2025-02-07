using AccessSystem.Domain.Entities;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Domain.Repositories;

public interface IAccessClaimRepository
{
    Task<Maybe<List<AccessClaimEntity>>> GetAllAsync();
    Task<Maybe<AccessClaimEntity>> GetByIdAsync(Guid id);

    void Insert(AccessClaimEntity accessClaim);
    
    void Update(AccessClaimEntity accessClaim);
    Task Remove(AccessClaimEntity accessClaim);
}