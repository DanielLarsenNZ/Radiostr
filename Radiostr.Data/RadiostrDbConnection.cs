using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Radiostr.Data
{
    public class RadiostrDbConnection : IRadiostrDbConnection
    {
        private const string DbConnectionStringName = "Radiostr";

        private static string _connectionString;

        private string GetConnectionString()
        {
            if (!string.IsNullOrEmpty(_connectionString)) return _connectionString;

            const string message = "No connection string named \"{0}\" found in App.Config";

            if (ConfigurationManager.ConnectionStrings.Count == 0) throw new InvalidOperationException(string.Format(message, DbConnectionStringName));

            var connectionString = ConfigurationManager.ConnectionStrings[DbConnectionStringName];
            if (connectionString == null) throw new InvalidOperationException(string.Format(message, DbConnectionStringName));

            _connectionString = connectionString.ConnectionString;
            return _connectionString;
        }

        public IDbConnection GetDbConnection()
        {
            //TODO: Should this be static/cached?
            return new SqlConnection(GetConnectionString());
        }
    }
}