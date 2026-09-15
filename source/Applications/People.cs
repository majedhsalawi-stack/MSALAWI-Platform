using MSALAWI.Domain.IdentityPerson;
using MSALAWI.Shared;

namespace MSALAWI.Application;

public sealed record CreatePersonCommand(string FullName, string? Email);
public sealed record PersonDto(Guid Id, string FullName, string? Email);

public interface IPersonRepository
{
    Task AddAsync(Person person, CancellationToken cancellationToken);
    Task<Person?> GetAsync(EntityId id, CancellationToken cancellationToken);
}

public sealed class CreatePersonHandler(IPersonRepository repository)
{
    public async Task<Result<PersonDto>> HandleAsync(CreatePersonCommand command, CancellationToken cancellationToken)
    {
        var result = Person.Create(command.FullName, command.Email);
        if (!result.IsSuccess)
        {
            return Result<PersonDto>.Failure(result.Error!);
        }

        var person = result.Value!;
        await repository.AddAsync(person, cancellationToken);
        return Result<PersonDto>.Success(new PersonDto(person.Id.Value, person.FullName, person.Email));
    }
}
