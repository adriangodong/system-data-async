# System.Data.Async

This library adds interfaces and adapters to allow working with async methods available in `System.Data` abstract classes but not interfaces.

**Latest Release**

[![Release](https://img.shields.io/nuget/v/MediumSdk.svg)](https://www.nuget.org/packages/MediumSdk/)

**Latest master Build**

[![Latest](https://ci.appveyor.com/api/projects/status/b5j0b5y7tm413mcw/branch/master?svg=true)](https://ci.appveyor.com/project/adriangodong/system-data-async/branch/master)


## Sample migration

```diff
-   // With System.Data.Common
+   // With System.Data.Async

    // Construct a new Connection object.
-   System.Data.Common.SqlClient.SqlConnection connection =
-       new System.Data.SqlClient.SqlConnection("connection string");
+   System.Data.Async.SqlClient.ISqlConnectionAsync connection =
+       new System.Data.Async.SqlClient.SqlConnectionAsync("connection string");

    // Construct a new Command object.
-   System.Data.Command.SqlClient.SqlCommand     command = connection.CreateCommand();
+   System.Data.Async.SqlClient.ISqlCommandAsync command = connection.CreateCommand();

    // Open Connection.
    await connection.OpenAsync();

    // Get DataReader object.
-   System.Data.SqlClient.SqlDataReader            reader = await command.ExecuteReaderAsync();
+   System.Data.Async.SqlClient.SqlDataReaderAsync reader = await command.ExecuteReaderAsync();
```


## Installation

* Get release packages from [NuGet](https://www.nuget.org/packages/System.Data.Async)
* Get pre-release packages from AppVeyor NuGet Feed
    * Feed URL: `https://ci.appveyor.com/nuget/system-data-async`


## Documentation

* [Changelog](CHANGELOG.md)
* [General Approach](docs/GeneralApproach.md)
    * [Connection Objects](docs/Connection.md)
    * [Command Objects](docs/Command.md)
    * [DataReader Objects](docs/DataReader.md)
