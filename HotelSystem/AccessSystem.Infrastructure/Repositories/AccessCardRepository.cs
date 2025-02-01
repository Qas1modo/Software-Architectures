using AccessSystem.Contracts.Models.AccessCard;
using AccessSystem.Domain.Entities;
using AccessSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Domain.Core.Primitives.Maybe;
using SharedKernel.Infrastructure.Repositories;

namespace AccessSystem.Infrastructure.Repositories;

public class AccessCardRepository(IDbContext dbContext)
    : GenericRepository<AccessCardEntity>(dbContext), IAccessCardRepository
{
    public new async Task<Maybe<AccessCardEntity>> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            return Maybe<AccessCardEntity>.None;
        }
        var query = DbContext.Set<AccessCardEntity>()
            .Include(card => card.Roles)
            .AsQueryable();

        var result = await query.FirstOrDefaultAsync(card => card.Id == id);
        
        if (result is null)
        {
            return Maybe<AccessCardEntity>.None;
        }

        return Maybe<AccessCardEntity>.From(result);
    }

    public async Task<Maybe<AccessCardResponseModel>> GetByHolderId(Guid id)
    {
        var query = DbContext.Set<AccessCardEntity>()
            .Include(card => card.Roles)
            .AsQueryable();

        var result = await query.FirstOrDefaultAsync(card => card.HolderId == id);

        if (result is null)
        {
            return Maybe<AccessCardResponseModel>.None;
        }

        return new AccessCardResponseModel
        {
            Id = result.Id,
            HolderId = result.HolderId,
            RoleNames = result.Roles.Select(role => role.RoleCodeName).ToList(),
        };
    }
    
    public new async Task Remove(AccessCardEntity entity)
    {
        var accessCardRoles = DbContext.Set<AccessCardRole>().AsQueryable();
        
        var cardRoles = await accessCardRoles.Where(accessCardRole => accessCardRole.AccessCardId == entity.Id).ToListAsync();
        DbContext.Set<AccessCardRole>().RemoveRange(cardRoles);
        
        DbContext.Set<AccessCardEntity>().Remove(entity);
    }
}