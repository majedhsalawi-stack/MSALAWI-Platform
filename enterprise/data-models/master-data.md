# Master & Reference Data Model

## Principle
Master/reference data is governed platform data, not a collection of magic strings. Ownership, localization, lifecycle and tenant scope must be explicit.

## Categories
### Platform reference data
Stable platform-wide classifications where a shared definition is appropriate: supported languages, generic lifecycle classifications and technical reference values.

### Jurisdiction/reference datasets
Regions, cities, nationalities and similar datasets whose authoritative source/version should be recorded when imported. These are not manually duplicated per tenant by default.

### Tenant-configurable reference data
Organization unit types, committee/body types, meeting types, document classifications, project/program classifications and other institution-specific controlled lists.

### Domain-owned reference data
Values whose meaning/invariants belong to a bounded context remain owned by that context rather than a universal lookup table.

## Localization
Static UI labels use application localization resources. Reference values requiring translated display names use localized value records keyed by language/culture. User-entered content is preserved as entered unless the domain explicitly supports translations.

## Common metadata
Stable identifier, code where required, status, effective period where relevant, sort/display metadata, tenant scope where relevant, provenance/source for imported authoritative data, and audit metadata.

## Rules
- Avoid a single universal Lookup table for unrelated concepts.
- Codes used in integration contracts are stable and not repurposed.
- Deactivation is preferred over destructive deletion when historical records reference a value.
- Domain enums are acceptable for truly closed technical/domain sets; configurable institutional classifications are data/configuration.
- Localization does not force Arabic/English columns onto every entity.
