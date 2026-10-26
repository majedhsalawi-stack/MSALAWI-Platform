# Sprint 2 — Institutional Foundation: persistence verification gate

## Implemented on the sprint branch
- PostgreSQL EF Core provider and context.
- EF-backed person repository.
- API dependency injection for persistent repository.
- Connection string name aligned across API, appsettings and Compose.
- PostgreSQL readiness healthcheck before API startup.
- EF Core materialization constructor for Person.

## Outstanding before persistence is accepted
1. Add and validate the initial EF Core migration.
2. Run `dotnet restore`, `dotnet build`, and `dotnet test` with .NET 10.
3. Start PostgreSQL and API together; verify POST /api/people persists across API restart.
4. Implement tenant ownership and enforce isolation at repository and database access boundaries **before** exposing multi-organization APIs.
5. Introduce audit event provenance, then test creation and access controls.
6. Replace development-only credentials for non-local environments.
7. Confirm CI checks and review a pull request before merging into main.

## Security limitation
The current People endpoint has no authentication or tenant authorization and MUST NOT be exposed as a production multi-tenant endpoint. This document is an implementation checklist, not a production-readiness claim.
