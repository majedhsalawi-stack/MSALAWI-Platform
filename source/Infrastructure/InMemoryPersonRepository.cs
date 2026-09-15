using System.Collections.Concurrent;
using MSALAWI.Application;
using MSALAWI.Domain.IdentityPerson;
using MSALAWI.Shared;

namespace MSALAWI.Infrastructure;

public sealed class InMemoryPersonRepository : IPersonRepository
{
    private readonly ConcurrentDictionary<Guid, Person> _people = new();

    public Task AddAsync(Person person, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _people[person.Id.Value] = person;
        return Task.CompletedTask;
    }

    public Task<Person?> GetAsync(EntityId id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        _people.TryGetValue(id.Value, out var person);
        return Task.FromResult(person);
    }
}
