# Command Objects

## Type Hierarchy (all parent expanded for verbosity)

```
System.Data.Async.SqlClient.SqlCommandAsync

- System.Data.Async.Common.DbCommandAsync

  - System.Data.Async.IDbCommandAsync
  
    - System.Data.IDbCommand
  
      - System.IDisposable

  - System.IDisposable

- System.Data.Async.SqlClient.ISqlCommandAsync

  - System.Data.Async.IDbCommandAsync

    - System.Data.IDbCommand

      - System.IDisposable

    - System.IDisposable

  - ICloneable

- IDisposable

- ICloneable

- (wraps) System.Data.SqlClient.SqlCommand

  - System.Data.Common.DbCommand

    - System.Data.IDbCommand

      - System.IDisposable

    - System.IDisposable

  - System.ICloneable
```

## S.D.A.IDbCommandAsync

Contains missing public interfaces from `S.D.Common.DbCommand` not declared in `S.D.IDbCommand`.

## S.D.A.Common.DbCommandAsync

Wraps `S.D.Common.DbCommand` and expose `S.D.A.IDbCommandAsync`.

The public interface should be identical with `S.D.Common.DbCommand` except `Task<IDbDataReaderAsync> ExecuteReaderAsync()` overloads.

## S.D.A.SqlClient.ISqlCommandAsync

Contains missing public interfaces from `S.D.SqlClient.SqlCommand` not declared in `S.D.IDbCommand` or derived from `S.D.Common.DbCommand`.

## S.D.A.SqlClient.SqlCommandAsync

Wraps `S.D.SqlClient.SqlCommand` and expose `S.D.A.SqlClient.ISqlConnectionAsync`.

The public interface should be identical with `S.D.SqlClient.SqlCommand` except `Task<SqlDataReaderAsync> ExecuteReaderAsync()`.
