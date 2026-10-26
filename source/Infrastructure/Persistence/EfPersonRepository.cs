using Microsoft.EntityFrameworkCore;
using MSALAWI.Application;
using MSALAWI.Domain.IdentityPerson;
using MSALAWI.Shared;

namespace MSALAWI.Infrastructure.Persistence;

public sealed class EfPersonRepository(MsalawiDbContext dbContext) : IPersonRepository
{
    public async Task AddAsync(Person person, CancellationToken cancellationToken)
    {
        await dbContext.People.AddAsync(person, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task<Person?> GetAsync(EntityId id, CancellationToken cancellationToken) =>
        dbContext.People.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
}
