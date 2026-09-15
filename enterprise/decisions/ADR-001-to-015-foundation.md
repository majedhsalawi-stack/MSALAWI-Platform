# Foundation Architecture Decisions

Status: Accepted for Sprint 1 foundation.

## ADR-001 — Governance by Design
Governance is a cross-cutting platform concern designed into lifecycle, approvals, authority, records and auditability rather than added after modules are built.

## ADR-002 — Business Before Technology
For a capability, define institutional purpose, actors, lifecycle, rules, risks, records and measures before selecting implementation details.

## ADR-003 — Multi-Tenant by Design
MSALAWI is designed to serve multiple institutions. Tenant isolation is explicit in application, authorization and persistence boundaries; tenant IDs supplied by clients are not trusted as access proof.

## ADR-004 — Native Bilingual Architecture
Arabic and English are first-class product languages with RTL/LTR. UI resources, reference-data translations and user-entered content use different localization strategies appropriate to their semantics.

## ADR-005 — Domain Before Database
Model aggregates, invariants, value objects, events and context boundaries before deriving persistence schema. Database convenience must not define the domain model.

## ADR-006 — Platform Before Modules
Reusable institutional engines—identity/access, organization, governance, workflow, documents, notifications, compliance, reporting and integration—are built as platform capabilities rather than duplicated by modules.

## ADR-007 — Policy-Driven Governance / Policy as Code
Where institutional rules can be executed, rules are versioned and linked to their human-readable governing source. Executable rules never silently replace the approved institutional artifact.

## ADR-008 — Audit by Default
Security-sensitive and institutionally significant actions produce attributable, timestamped audit evidence. Audit history is append-oriented and protected from ordinary business mutation.

## ADR-009 — Security by Design
Least privilege, tenant isolation, secure configuration, protected secrets, secure transport, auditable privileged access and threat-aware engineering are baseline requirements.

## ADR-010 — Configuration Before Customization
Tenant differences are handled through governed configuration and extension points before tenant-specific code forks are considered.

## ADR-011 — Human-Centered Governance
Controls should reduce institutional risk while minimizing unnecessary friction. Approval and evidence requirements must be proportionate and understandable.

## ADR-012 — Product Before Project
MSALAWI is a long-lived product with roadmap, release discipline, supportability, quality, security and evolution—not a one-off delivery.

## ADR-013 — Enterprise Knowledge Preservation
Architecture, terminology, decisions, standards and operating knowledge live in version-controlled repository documentation rather than only in chats or individual memory.

## ADR-014 — Event-Driven Integration Where Valuable
Domain/integration events are used when they improve decoupling, auditability or asynchronous workflows. Event-driven architecture is not imposed on simple synchronous operations without value.

## ADR-015 — Person and Digital Identity Are Separate Concepts
People owns Person. Identity & Access owns UserAccount/authentication. A Person can exist without an account and account linkage is explicit, preventing authentication concerns from contaminating institutional people models.

## Consequence
Future implementation changes that contradict an accepted ADR require an explicit superseding ADR rather than an undocumented architectural drift.
