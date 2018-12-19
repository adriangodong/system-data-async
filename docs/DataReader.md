# DataReader Objects

## Type Hierarchy (all parent expanded for verbosity)

```
System.Data.Async.SqlClient.SqlDataReaderAsync

- System.Data.Async.SqlClient.ISqlDataReaderAsync

  - System.Data.Async.IDbDataReaderAsync

    - System.Data.Async.IDataReaderAsync

      - System.Data.IDataReader

        - System.Data.IDataRecord

        - System.IDisposable

      - System.Data.Async.IDataRecordAsync

        - System.Data.IDataRecord

    - System.Data.Async.IDataRecordAsync

      - System.Data.IDataRecord

    - System.CollectionsIEnumerable

    - System.IDisposable

  - System.IDisposable

- System.IDisposable

- (wraps) System.Data.SqlClient.SqlDataReader

  - System.Data.DbDataReader

    - System.Collections.IEnumerable

    - System.Data.IDataReader

        - System.Data.IDataRecord

        - System.IDisposable

    - System.Data.IDataRecord

    - System.IDisposable

  - System.IDisposable
```

## S.D.A.IDataRecordAsync

Adds `Task<bool> IsDBNullAsync()` overloads to `S.D.IDataRecord`.

## S.D.A.IDataReaderAsync

Adds `Task<bool> NextResultAsync()` and `Task<bool> ReadAsync()` overloads to `S.D.IDataReader`.

## S.D.A.IDbDataReaderAsync

Contains missing public interfaces from `S.D.Common.DbDataReader` not declared in `S.D.IDataReader`.

## S.D.A.SqlClient.ISqlDataReaderAsync

Contains missing public interfaces from `S.D.SqlClient.SqlDataReader` not declared in `S.D.IDataReader` or derived from `S.D.Common.DbDataReader`.

## S.D.A.SqlClient.SqlDataReaderAsync

Wraps `S.D.SqlClient.SqlDataReader` and expose `S.D.A.SqlClient.ISqlDataReaderAsync`.

The public interface should be identical with `S.D.SqlClient.SqlDataReader`.
