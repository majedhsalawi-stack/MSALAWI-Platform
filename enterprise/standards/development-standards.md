# MSALAWI Development Standards v1.0

## Architecture
- Respect bounded-context ownership and dependency direction.
- Domain projects contain domain concepts and invariants, not controllers or persistence implementations.
- Application layer coordinates use cases; presentation remains thin.
- Infrastructure implements external/persistence concerns behind explicit contracts.
- Shared Kernel stays minimal; avoid generic dumping grounds.
- Do not use a generic repository abstraction that erases aggregate semantics.

## Business implementation gate
Before coding a significant capability, document: purpose, actors, lifecycle, invariants/rules, authorization/tenant implications, audit requirements, records/evidence, failure cases and acceptance criteria.

## Naming
English code identifiers. Singular entity/class names. Commands express intent (`CreateOrganizationCommand`); queries express requested information; handlers are named for the request they handle. Avoid magic strings for governed concepts.

## API
API-first contracts, predictable errors, validation at boundaries, idempotency for retryable commands where necessary, tenant scope derived from trusted context, and no leakage of internal persistence models as public contracts.

## Persistence
PostgreSQL is the planned primary relational store. UUID-style stable IDs are preferred where appropriate. Audit fields and concurrency/versioning are applied based on domain need. Soft delete is not mandatory for every table; retention/deletion semantics are domain-specific.

## Security
Least privilege; policy/permission authorization; explicit tenant validation; secrets outside source control; no sensitive data in logs; privileged operations auditable; input validation and output encoding appropriate to boundary.

## Testing
Use domain unit tests for invariants, application/integration tests for behavior across infrastructure boundaries, and architecture tests for dependency rules. Coverage is risk-based: critical domain/security/tenant behavior requires strong tests; a raw percentage is not a substitute for meaningful assertions.

## Frontend
React + TypeScript. Business invariants do not live only in UI. Components follow the MSALAWI design system; Arabic/English and RTL/LTR are tested from the start. Accessibility is part of definition of done.

## Documentation
Every bounded context maintains purpose, ownership, key concepts, invariants, integrations and significant decisions. Documentation changes accompany architectural changes.

## Git/review
`main` is stable. Work occurs on scoped branches and enters main through reviewed pull requests. Commits are cohesive and descriptive. CI must be green before merge unless a documented exception is approved.
