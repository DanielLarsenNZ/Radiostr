using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;


namespace Radiostr.Storage.Table
{
    public class AzureTableStorage : AzureStorage
    {
        private readonly CloudTableClient _tableClient; 

        public AzureTableStorage(NameValueCollection settings) : base(settings)
        {
            _tableClient = StorageAccount.CreateCloudTableClient();
        }

        public async Task CreateTables(string[] tableNames)
        {
            if (tableNames == null || tableNames.Length == 0) throw new ArgumentNullException("tableNames");
            foreach (string tableName in tableNames.AsParallel())   //REVIEW
            {
                var table = _tableClient.GetTableReference(tableName);
                await table.CreateIfNotExistsAsync();
                Trace.TraceInformation("Created table " + tableName);
            }
        }
    }
}
