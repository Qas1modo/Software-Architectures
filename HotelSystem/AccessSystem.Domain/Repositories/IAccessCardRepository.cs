using AccessSystem.Contracts.Models.AccessCard;
using AccessSystem.Domain.Entities;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Domain.Repositories;

public interface IAccessCardRepository
{
    Task<Maybe<AccessCardEntity>> GetByIdAsync(Guid id);

    Task<Maybe<AccessCardResponseModel>> GetByHolderId(Guid id);

    void Insert(AccessCardEntity accessCard);
    
    void Update(AccessCardEntity accessCard);
    Task Remove(AccessCardEntity accessCard);
}