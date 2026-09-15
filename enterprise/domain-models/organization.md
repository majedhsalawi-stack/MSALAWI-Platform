# Organization Domain Model

## Purpose
Model an institution without hard-coding one organization chart. The context supports tenant organizations, branches, organizational units, governance bodies, positions and time-bound assignments.

## Aggregate roots
### Organization
Represents the tenant institution. Owns institutional identity and lifecycle, not authentication.

Key concepts: OrganizationId, legal/display name, organization type, status, locale/time-zone defaults and configuration references.

### OrganizationalUnit
Represents a structural unit such as department, administration, unit, branch or team. Units form a controlled hierarchy inside one Organization.

Invariants:
- A unit belongs to exactly one tenant organization.
- Parent and child must belong to the same organization.
- Cycles in the hierarchy are prohibited.
- Structural type is reference/configuration data, not a separate table per type.

### GovernanceBody
Represents a board, committee, general assembly or other formally constituted body. GovernanceBody is distinct from OrganizationalUnit because its authority, membership and decisions have governance semantics.

### Position
Represents an institutional position independent of the current person occupying it.

### Assignment
Time-bound relationship between a Person and a Position, OrganizationalUnit or GovernanceBody role. Historical assignments remain traceable.

## Supporting entities/value objects
OrganizationName, UnitName, PositionTitle, EffectivePeriod, AssignmentType, OrganizationStatus, UnitStatus.

## Domain events
OrganizationCreated, OrganizationalUnitCreated, OrganizationalUnitMoved, PositionCreated, PersonAssigned, AssignmentEnded, GovernanceBodyEstablished, GovernanceBodyDissolved.

## Integration boundaries
- People provides PersonId references.
- Identity & Access consumes assignments/roles only through explicit authorization projections/policies.
- Governance owns formal mandates, decisions and delegations.
- Workflow may route tasks using organization/position references.

## Multi-tenancy
Organization is the primary tenant boundary. No aggregate may be moved between tenants. Cross-tenant collaboration must use explicit integration/relationship models rather than shared ownership.
