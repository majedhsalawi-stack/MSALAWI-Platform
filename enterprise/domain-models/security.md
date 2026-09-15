# Identity, Authorization & Security Domain Model

## Separation of concerns
**Person != User.** People owns institutional person records. Identity & Access owns digital identities and authentication/access concerns. A person may exist without a user account; a user identity may be linked to a person through an explicit relationship.

## Aggregate roots
### UserAccount
Digital account lifecycle and security state. Does not duplicate the full Person profile.

### Role
Tenant-scoped or platform-scoped named collection of permissions where roles are useful operational abstractions.

### AccessPolicy
Policy-based authorization rule evaluated against actor, tenant, resource, action, assignments, delegations and contextual conditions.

### DelegatedAccess
Security projection of an approved Governance delegation where appropriate. Governance remains authoritative source of delegation semantics.

## Core concepts
UserId, PersonId reference, TenantId, RoleId, Permission, ResourceScope, AccessDecision, AuthenticationMethod, AccountStatus, SessionId, SecurityStamp.

## Authorization model
RBAC is supported for operational simplicity, but authorization is not role-only. Final access decisions can combine permissions, resource scope, tenant boundary, organization assignment, governance delegation and contextual policy.

## Tenant isolation rules
- Tenant context is derived from trusted authenticated/session/application context, not accepted solely from client payload.
- Every tenant-owned resource access validates tenant scope.
- Platform administration is explicitly modeled and audited; it is not an implicit bypass.
- Cross-tenant access requires a deliberate platform capability and policy.

## Security requirements
Least privilege, secure secret handling, protected credentials/tokens, session revocation, rate limiting at relevant boundaries, security headers, encryption in transit, appropriate encryption/data protection at rest, auditable privileged actions, and OWASP-aligned engineering reviews.

## Domain/security events
UserProvisioned, UserLinkedToPerson, AccountSuspended, RoleAssigned, RoleRevoked, AccessPolicyChanged, SessionRevoked, PrivilegedAccessUsed.

## Authentication technology
The domain does not lock the product to a specific identity provider or token mechanism. ASP.NET Core Identity, OIDC/OAuth providers and token/session implementation are infrastructure decisions selected against product/security requirements.
