# Enterprise Domain Map

## Core platform bounded contexts

### Identity & Access
Authentication identities, credentials/external identities, sessions, roles, permissions, access policies and security context. A Person is not automatically a User.

### People
Institutional people records and person-level contact/identity attributes used by business domains. Business roles such as employee, volunteer, beneficiary, member or board member are modeled through their owning contexts/relationships rather than collapsing all concepts into Identity.

### Organization
Tenant organization, branches, organizational units, boards, committees, teams, positions, assignments and reporting relationships.

### Governance
Policies, procedures, regulations, institutional decisions, meetings, resolutions, delegations, approvals and governance records.

### Workflow
Reusable process definitions, instances, stages, tasks, transitions, assignments, approvals, escalation and lifecycle history.

### Compliance & Risk
Obligations, controls, evidence, assessments, findings, risks, treatments and compliance status.

### Documents & Records
Institutional documents, classifications, versions, references, retention metadata and links to governed business records.

### Notifications
Delivery intents, templates, channels and delivery status; business domains request notifications rather than implementing channels themselves.

### Reporting & Analytics
Read models, KPIs, dashboards and institutional reporting projections. It does not own transactional truth.

### Integration
External-system contracts, integration messages, adapters and synchronization boundaries.

## Functional/business contexts (incremental roadmap)
Membership, Volunteering, Beneficiaries, Programs, Projects, Finance, Human Resources, Assets, Inventory, Partnerships, Events, Training, CRM, Strategy, Performance, Quality, Contracts/Legal, Media, Awards, Research and Innovation.

These contexts are roadmap domains, not Sprint 1 implementation commitments.

## Context rules
- Every tenant-owned aggregate carries an explicit tenant boundary.
- Cross-context references use stable identifiers/contracts; contexts do not directly mutate another context's aggregate.
- Governance, workflow, audit and authorization are platform capabilities consumed consistently across business contexts.
- Domain events describe completed domain facts; integration events cross context/process boundaries when needed.
- Shared Kernel remains deliberately small and contains only stable primitives with broad semantic agreement.
