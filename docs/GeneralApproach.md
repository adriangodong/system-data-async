# General Approach

The basic requirement of this library is to provide an interface containing asynchronous methods that was left out of the
original release of System.Data. The primary driver is to provide mocking point for unit testing.

## Object Groups

There are three object groups that this library extends.

1. [Connection](Connection.md). Connection objects are the entry points to the System.Data namespace. The input parameter is as simple as a connection string and optionally `SqlCredential` instance for `SqlClient`.

2. [Command](Command.md). Command objects are created from connection objects. The input parameter is the query and the connection object.

3. [DataReader](DataReader.md). DataReader objects are used to read the output data of the command object.

## Extension Mechanism

`SqlClient` objects are `sealed`. That means we cannot extend it. This library wraps the `SqlClient` objects in another object that contains the extension. This is an example of [Adapter pattern](https://en.wikipedia.org/wiki/Adapter_pattern).

The wrapper classes are located under `System.Data.Async.SqlClient`. `SqlConnectionAsync` wraps `SqlConnection`, `SqlCommandAsync` for `SqlCommand`, and finally `SqlDataReaderAsync` for `SqlDataReader`. In version 2.x, we moved from deriving the wrappers from abstract `DbConnection`, `DbCommand`, and `DbDataReader` to a simpler, shallower class hierarchy.

Guidelines:

* Wrapper constructor takes the same parameters as the wrapped class.
* If `System.Data` class implementation is concrete, perform a simple call to the wrapped instance.
* If `System.Data` class implementation returns `SqlCommand` or `SqlDataReader` in an async setting, create and return a new `SqlCommandAsync` or `SqlDataReaderAsync` wrapping the base output.
