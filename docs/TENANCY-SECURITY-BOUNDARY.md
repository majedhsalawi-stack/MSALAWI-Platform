# Tenant security boundary — implementation contract

The organization is the tenant boundary. Tenant identity MUST come from verified authentication plus authorized organization membership. Never derive authorization from a client-provided header, query parameter or body field alone.

## Fail-closed baseline
- `ITenantContext.RequireTenant()` throws unless a trusted implementation resolves the tenant.
- `TenantId` is a strongly typed value; it is **not** itself authorization.
- Audit events include tenant, actor, resource, action, UTC timestamp and optional correlation identifier.
- Audit event creation is not yet durable persistence and is **not** evidence of an operational audit trail.

## Acceptance gates
1. Implement authenticated tenant resolution and membership authorization.
2. Add tenant ownership to persisted business aggregates and migrations.
3. Enforce tenant-scoped reads/writes and test cross-tenant denial.
4. Persist append-only audit records atomically with business changes where appropriate.
5. Audit privileged operations, tenant switches, failed authorization and policy changes.
6. Add integration tests against real PostgreSQL; verify tamper resistance, tenant isolation and migration upgrades.

**Security warning:** Existing `POST /api/people` is not authenticated or tenant-scoped. Do not deploy it to a public production environment.
