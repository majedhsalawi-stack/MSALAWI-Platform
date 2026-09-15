# Context Map

## Strategic relationships

- **Identity & Access -> all contexts:** supplies authenticated actor/security context and authorization decisions; it does not own institutional Person data.
- **People -> business contexts:** supplies stable person references and core person data through contracts.
- **Organization -> all tenant business contexts:** supplies tenant, organizational structure, position and assignment references.
- **Governance -> business contexts:** governs policies, decisions, delegations and formal approval requirements.
- **Workflow -> business contexts:** executes configurable lifecycles requested by owning domains; the business domain remains owner of business invariants.
- **Compliance & Risk -> business contexts:** evaluates obligations/controls and associates evidence/findings without taking ownership of source transactions.
- **Documents & Records -> all contexts:** manages document/record lifecycle and links artifacts to domain records.
- **Notifications <- all contexts:** consumes notification requests/events.
- **Reporting & Analytics <- all contexts:** consumes projections/events/read contracts for reporting; never becomes transactional source of truth.
- **Integration <-> external systems:** anti-corruption boundary isolates external models from internal domain models.

## Dependency direction
Business contexts may depend on stable platform contracts. Platform contexts must not depend on individual business modules. Cross-context database writes are prohibited; collaboration occurs through application contracts, stable IDs, events or explicitly designed read models.

## Multi-tenancy rule
Tenant context is established at the application boundary and propagated explicitly. Authorization and persistence must validate tenant scope; client-supplied tenant identifiers alone are never trusted as proof of access.
