using MSALAWI.Domain.IdentityPerson;

namespace MSALAWI.Domain.Tests;

public sealed class PersonTests
{
    [Fact]
    public void Create_requires_a_full_name()
    {
        var result = Person.Create(" ", "person@example.org");
        Assert.False(result.IsSuccess);
        Assert.Equal("person.full_name_required", result.Error);
    }

    [Fact]
    public void Create_normalizes_input()
    {
        var result = Person.Create("  Majed Salawi  ", "  majed@example.org  ");
        Assert.True(result.IsSuccess);
        Assert.Equal("Majed Salawi", result.Value!.FullName);
        Assert.Equal("majed@example.org", result.Value.Email);
    }
}
