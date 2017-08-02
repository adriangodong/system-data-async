﻿using System.Data.Common;

namespace System.Data.Async.Common
{
    public abstract class DbConnectionAsync : DbConnection, IDbConnectionAsync
    {
        public new IDbCommandAsync CreateCommand() => CreateDbCommandAsync();
        protected override DbCommand CreateDbCommand() => CreateDbCommandAsync();
        protected abstract DbCommandAsync CreateDbCommandAsync();
    }
}