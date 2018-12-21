# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added

- Added new interfaces: `S.D.A.IDataRecordAsync` (extends `IDataRecord`), `S.D.A.IDbDataReaderAsync`, `S.D.A.SqlClient.ISqlConnectionAsync`, `S.D.A.SqlClient.ISqlCommandAsync`, `S.D.A.SqlClient.ISqlDataReaderAsync`. [#18](https://github.com/adriangodong/system-data-async/pull/18)
- Added new documentation on how the type hierarchy is written. [#18](https://github.com/adriangodong/system-data-async/pull/18)

### Changed

- `S.D.A.Common.DbConnectionAsync` no longer derived from `DbConnection`, forwards all public members to wrapped `DbConnection` instance instead. [#18](https://github.com/adriangodong/system-data-async/pull/18)
- `S.D.A.Common.DbCommandAsync` no longer derived from `DbCommand`, forwards all public members to wrapped `DbCommand` instance instead. [#18](https://github.com/adriangodong/system-data-async/pull/18)
- `S.D.A.SqlClient.SqlConnectionAsync` fully forwards all public members to wrapped `SqlConnection` instance. [#18](https://github.com/adriangodong/system-data-async/pull/18)
- `S.D.A.SqlClient.SqlCommandAsync` fully forwards all public members to wrapped `SqlCommand` instance. [#18](https://github.com/adriangodong/system-data-async/pull/18)
- `S.D.A.SqlClient.SqlDataReaderAsync` fully forwards all public members to wrapped `SqlDataReader` instance. [#18](https://github.com/adriangodong/system-data-async/pull/18)
- Multiple changes in type hierarchy, public member additions and removals. [#18](https://github.com/adriangodong/system-data-async/pull/18)

### Removed

- `S.D.A.Common.DbDataReaderAsync` has been removed. This has always been a simple intermediate class and no longer needed. [#18](https://github.com/adriangodong/system-data-async/pull/18)

## [1.0.7] - 2018-12-19

### Added

- Implemented override for `IDataReader.GetSchemaTable()`. [#14](https://github.com/adriangodong/system-data-async/pull/14)
- Implemented more overrides missing from `SqlDataReader`. [#16](https://github.com/adriangodong/system-data-async/pull/16)

### Changed

- Previously, we append prerelease segment to the closest release version when building prerelease commits. We now increment the closest release version patch segment before appending the prerelease segment. [#15](https://github.com/adriangodong/system-data-async/pull/15)
- Upgraded library target package to netstandard2.0, test platform to netcoreapp2.1, Moq to 4.10.0, MSTest dependencies to 15.9.0 and 1.4.0. [#14](https://github.com/adriangodong/system-data-async/pull/14)

## [1.0.6] - 2017-12-20

### Changed

- Upgraded System.Data.SqlClient to 4.4.2. [#13](https://github.com/adriangodong/system-data-async/pull/13)
