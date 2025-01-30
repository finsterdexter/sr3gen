using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3Generator.Database.Connection
{
    internal class DbConnectionFactory
    {
        private readonly DatabaseOptions _options;

        internal DbConnectionFactory(IOptions<DatabaseOptions> options)
        {
            _options = options.Value;
        }

        public IDbConnection CreateConnection()
        {
            var connection = new SqliteConnection($"Data Source={_options.DatabasePath}");
            connection.Open();
            return connection;
        }
    }
}
