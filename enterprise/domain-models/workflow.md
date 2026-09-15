# Workflow Domain Model

## Purpose
A generic configurable workflow engine coordinates institutional processes while each business context remains owner of its business state and invariants.

## Aggregate roots
### WorkflowDefinition
Versioned process definition containing stages, transitions, assignment rules, conditions, deadlines and completion/cancellation behavior. Published definitions are immutable; changes create a new version.

### WorkflowInstance
Execution of one published definition for a specific business subject/reference and tenant.

### WorkItem
Actionable task/approval assigned to a person, position, role, governance body or resolution rule.

## Core concepts
WorkflowDefinitionId, DefinitionVersion, Stage, Transition, TransitionCondition, AssignmentRule, WorkItemType, DuePolicy, EscalationPolicy, WorkflowSubject, WorkflowStatus.

## Lifecycle
Definition: Draft -> Published -> Retired.
Instance: Pending -> Active -> Completed / Cancelled / Failed.
Work item: Pending -> Assigned -> InProgress -> Completed / Rejected / Cancelled / Expired.

## Invariants
- An instance is pinned to one immutable published definition version.
- Workflow cannot directly bypass invariants of the owning business aggregate.
- Every transition records actor/system provenance, timestamp and reason/context.
- Assignment resolution is tenant-scoped and authorization-aware.
- Retrying automation must be idempotent where external effects are possible.
- Escalation does not silently change business authority.

## Domain events
WorkflowPublished, WorkflowStarted, StageEntered, WorkItemAssigned, WorkItemCompleted, TransitionTaken, WorkflowCompleted, WorkflowCancelled, WorkItemEscalated.

## Integration pattern
Business context requests workflow start with a stable subject reference. Workflow emits lifecycle events. Business application handlers validate and apply resulting business commands. This prevents Workflow from becoming a generic database-driven business-logic engine.
