using MSALAWI.Shared.Tenancy;

namespace MSALAWI.Shared.Auditing;

/// <summary>Append-only audit payload; persistence and trusted actor resolution are separate responsibilities.</summary>
public sealed record AuditEvent(
    Guid Id,
    TenantId TenantId,
    string Action,
    string ResourceType,
    string ResourceId,
    string ActorId,
    DateTimeOffset OccurredAtUtc,
    string? CorrelationId)
{
    public static AuditEvent Record(
        TenantId tenantId, string action, string resourceType, string resourceId,
        string actorId, string? correlationId = null)
    {
        if (tenantId.Value == Guid.Empty) throw new ArgumentException("Tenant is required.", nameof(tenantId));
        if (string.IsNullOrWhiteSpace(action)) throw new ArgumentException("Action is required.", nameof(action));
        if (string.IsNullOrWhiteSpace(resourceType)) throw new ArgumentException("Resource type is required.", nameof(resourceType));
        if (string.IsNullOrWhiteSpace(resourceId)) throw new ArgumentException("Resource ID is required.", nameof(resourceId));
        if (string.IsNullOrWhiteSpace(actorId)) throw new ArgumentException("Actor is required.", nameof(actorId));
        return new AuditEvent(Guid.NewGuid(), tenantId, action.Trim(), resourceType.Trim(),
            resourceId.Trim(), actorId.Trim(), DateTimeOffset.UtcNow, correlationId);
    }
}
