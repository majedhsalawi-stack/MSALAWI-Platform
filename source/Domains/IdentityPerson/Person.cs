using MSALAWI.Shared;

namespace MSALAWI.Domain.IdentityPerson;

public sealed class Person
{
    private Person(EntityId id, string fullName, string? email)
    {
        Id = id;
        FullName = fullName;
        Email = email;
    }

    public EntityId Id { get; }
    public string FullName { get; private set; }
    public string? Email { get; private set; }

    public static Result<Person> Create(string fullName, string? email)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            return Result<Person>.Failure("person.full_name_required");
        }

        return Result<Person>.Success(new Person(EntityId.New(), fullName.Trim(), string.IsNullOrWhiteSpace(email) ? null : email.Trim()));
    }
}
