# CI remediation — Sprint 2

The PR #2 CI run failed on 2026-10-26.

## Root causes found in job logs
- Backend restore: NU1902/NU1903 vulnerabilities in transitive cryptography packages; the EF Core Design tooling reference was a likely source. Removed the design package reference from the runtime infrastructure project pending a safer migration-tool strategy. **Must confirm with the next restore output.**
- Frontend setup-node: configured npm caching against a missing package-lock.json. Disabled caching and used npm install temporarily. **Must commit a verified lockfile and return to npm ci before production.**

## Safety
- The unauthenticated, unscoped POST /api/people route is now disabled with HTTP 503.
- Do not bypass NuGet vulnerability warnings.
- Do not merge until CI passes and migration, tenant isolation and audit persistence gates are satisfied.
