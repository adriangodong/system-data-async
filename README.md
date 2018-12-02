This library adds interfaces and adapters to allow working with async methods available in System.Data abstract classes but not interfaces.

## Sample migration

```diff
- // With System.Data.Common
+ // With System.Data.Async

- public Task<System.Data.Common.DbCommand> CreateCommand(System.Data.Common.DbConnection connection)
+ public Task<System.Data.Async.IDbCommandAsync> CreateCommand(System.Data.Async.IDbConnectionAsync connection)
{
-    System.Data.Common.DbCommand command = connection.CreateCommand();
+    System.Data.Async.IDbCommandAsync command = connection.CreateCommand();
    await connection.OpenAsync();
    return command;
}

public void GetCommand()
{
-    var connection = new System.Data.SqlClient.SqlConnection("connection string");
+    var connection = new System.Data.Async.SqlClient.SqlConnectionAsync("connection string");
    CreateCommand(connection);
}
```

## [Changelog](CHANGELOG.md)
