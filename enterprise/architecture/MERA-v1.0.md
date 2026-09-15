# MSALAWI Enterprise Reference Architecture (MERA) v1.0

## Purpose
MERA defines the durable enterprise architecture for MSALAWI as an institutional operating platform for nonprofit organizations.

## 1. Business Architecture
Defines organization types, governance bodies, departments, committees, boards, capabilities, operating processes, decision lifecycles, stakeholders, risks, KPIs, and required records.

Primary outputs: Business Capability Map, Operating Model, Business Process Map.

## 2. Information Architecture
Defines shared institutional concepts and authoritative information boundaries. Core concepts include Organization, Branch, Person, User, Membership, Volunteer, Beneficiary, Committee, Board, Project, Program, Policy, Procedure, Decision, Meeting, Document, Risk and KPI.

Primary outputs: Conceptual Data Model and Data Dictionary.

## 3. Application Architecture
Core engines are reusable platform capabilities rather than duplicated module logic:
- Identity & Access
- Organization
- Governance
- Workflow
- Compliance
- Notification
- Documents
- Reporting & Analytics
- Integration

Functional domains consume these engines through explicit contracts.

## 4. Technology Architecture
Baseline: ASP.NET Core/.NET 10, React + TypeScript + Vite, PostgreSQL, Docker and GitHub Actions. Architectural approach: Clean Architecture, Domain-Driven Design, vertical slices where appropriate, explicit application commands/queries, and domain/integration events where they create real decoupling value.

## 5. Security & Governance Architecture
Tenant isolation, least privilege, permission/policy-based authorization, auditability, approvals, delegation, secure configuration, data protection and traceable institutional decisions are cross-cutting requirements.

## Bilingual Architecture
Arabic and English are first-class interface languages with RTL/LTR support. Static UI text uses localization resources. Translatable reference/master data uses an explicit localization model when required. User-entered personal data is preserved as entered rather than automatically translated. Code identifiers remain English.

## Engineering gates
1. Business framework before implementation.
2. Domain model before persistence design.
3. Core platform capability before duplicated module capability.
4. Security, tenant isolation and audit implications reviewed for every slice.
5. Tests and documentation evolve with implementation.
