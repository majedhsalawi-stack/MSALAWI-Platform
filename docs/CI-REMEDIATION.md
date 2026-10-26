# CI remediation — Sprint 2

## CI failure review
Initial PR checks failed on NuGet security audit and missing npm lockfile. The next run, commit 82acbbd, progressed through package restore and frontend installation, but failed on:
- Backend: missing Xunit namespace import for Fact and Assert in PersonTests.cs.
- Frontend: TS2882, missing Vite client declarations for CSS side-effect imports.

## Changes
- Removed EF Core Design reference from runtime project; package vulnerability auditing remains enabled.
- Disabled npm caching pending a committed lockfile, and temporarily use npm install.
- Added explicit Xunit import and Vite client type reference.
- Disabled unauthenticated POST /api/people (503) pending tenant isolation and authentication.

## Remaining gates
- Confirm new CI results before accepting the build.
- Generate and validate PostgreSQL EF migrations.
- Add a committed frontend lockfile and switch to reproducible npm ci.
- Implement authenticated organization tenancy, tenant-scoped repositories and durable audit persistence.
- Test against PostgreSQL and complete security review before merge.
