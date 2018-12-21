# Connect Objects

## Type Hierarchy (all parent expanded for verbosity)

```
System.Data.Async.SqlClient.SqlConnectionAsync

- System.Data.Async.Common.DbConnectionAsync

  - System.Data.Async.IDbConnectionAsync
  
    - System.Data.IDbConnection
  
      - System.IDisposable

  - System.IDisposable

- System.Data.Async.SqlClient.ISqlConnectionAsync

  - System.Data.Async.IDbConnectionAsync

    - System.Data.IDbConnection

      - System.IDisposable

    - System.IDisposable

  - ICloneable

- IDisposable

- ICloneable

- (wraps) System.Data.SqlClient.SqlConnection

  - System.Data.Common.DbConnection

    - System.Data.IDbConnection

      - System.IDisposable

    - System.IDisposable

  - System.ICloneable
```

## S.D.A.IDbConnectionAsync

Contains missing public interfaces from `S.D.Common.DbConnection` not declared in `S.D.IDbConnection`.

## S.D.A.Common.DbConnectionAsync

Wraps `S.D.Common.DbConnection` and expose `S.D.A.IDbConnectionAsync`.

The public interface should be identical with `S.D.Common.DbConnection` except `IDbCommandAsync CreateCommand()`.

## S.D.A.SqlClient.ISqlConnectionAsync

Contains missing public interfaces from `S.D.SqlClient.SqlConnection` not declared in `S.D.IDbConnection` or derived from `S.D.Common.DbConnection`.

## S.D.A.SqlClient.SqlConnectionAsync

Wraps `S.D.SqlClient.SqlConnection` and expose `S.D.A.SqlClient.ISqlConnectionAsync`.

The public interface should be identical with `S.D.SqlClient.SqlConnection` except `ISqlCommandAsync CreateCommand()`.
