namespace MSALAWI.Shared.Tenancy;

/// <summary>Stable identifier for an organization tenant. Never trust a raw client-supplied value for authorization.</summary>
public readonly record struct TenantId(Guid Value)
{
    public static TenantId New() => new(Guid.NewGuid());
    public static TenantId From(Guid value) => value == Guid.Empty
        ? throw new ArgumentException("Tenant ID cannot be empty.", nameof(value))
        : new TenantId(value);
    public override string ToString() => Value.ToString();
}
