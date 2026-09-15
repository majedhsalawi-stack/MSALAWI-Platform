# Governance Domain Model

## Purpose
Provide reusable institutional governance capabilities without embedding governance rules independently in every business module.

## Aggregate roots
### GovernedInstrument
A controlled policy, procedure, regulation, guideline or charter with lifecycle, ownership, version, effective period and approval requirements.

Lifecycle baseline: Draft -> UnderReview -> Approved -> Effective -> Superseded/Retired. Tenant configuration may add controlled states through workflow while immutable published versions remain traceable.

### Meeting
Formal meeting of a GovernanceBody with agenda, attendance, quorum evidence, agenda items, minutes and resulting resolutions.

### Decision
A formally recorded institutional decision/resolution with issuing authority, effective date, scope, references and status.

### Delegation
Time-bound delegation of defined authority from an authorized source to a delegate. Delegation never grants more authority than the delegator is permitted to delegate.

### GovernanceRequirement
Defines a governance requirement or control that can be evaluated by policy/workflow/compliance services.

## Supporting concepts
InstrumentType, InstrumentVersion, ApprovalRequirement, AuthorityScope, DecisionStatus, MeetingStatus, QuorumRule, DelegationScope, EffectivePeriod, GovernanceReference.

## Domain events
InstrumentSubmittedForReview, InstrumentApproved, InstrumentPublished, InstrumentSuperseded, MeetingConvened, QuorumConfirmed, DecisionIssued, DecisionRevoked, DelegationGranted, DelegationExpired.

## Invariants
- Published governance records are versioned; historical approved content is not silently overwritten.
- Approval actor must satisfy authority/authorization rules at decision time.
- Delegation is explicit, scoped and time-bound.
- Meeting decisions retain provenance to meeting/body/authority when applicable.
- Audit history is append-oriented and separate from mutable presentation metadata.

## Policy as Code boundary
Executable rules may represent approval thresholds, authority checks, required evidence and lifecycle constraints. Human-readable policy remains the authoritative institutional artifact; executable rules must be versioned and linked to the governing source/version.
