# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added

- Implemented override for `IDataReader.GetSchemaTable()`. [#14](https://github.com/adriangodong/system-data-async/pull/14)
- Implemented more overrides missing from `SqlDataReader`. [#16](https://github.com/adriangodong/system-data-async/pull/16)

### Changed

- Previously, we append prerelease segment to the closest release version when building prerelease commits. We now increment the closest release version patch segment before appending the prerelease segment. [#15](https://github.com/adriangodong/system-data-async/pull/15)
- Upgraded library target package to netstandard2.0, test platform to netcoreapp2.1, Moq to 4.10.0, MSTest dependencies to 15.9.0 and 1.4.0. [#14](https://github.com/adriangodong/system-data-async/pull/14)

## [1.0.6] - 2017-12-20

### Changed

- Upgraded System.Data.SqlClient to 4.4.2. [#13](https://github.com/adriangodong/system-data-async/pull/13)
