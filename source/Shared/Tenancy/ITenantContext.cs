namespace MSALAWI.Shared.Tenancy;

/// <summary>Tenant resolved by trusted authentication and authorization infrastructure.</summary>
public interface ITenantContext
{
    TenantId RequireTenant();
}

/// <summary>Fail-closed placeholder: no tenant-bound operation is authorized until authentication is wired.</summary>
public sealed class UnresolvedTenantContext : ITenantContext
{
    public TenantId RequireTenant() => throw new UnauthorizedAccessException(
        "Tenant context has not been established from a trusted identity.");
}
