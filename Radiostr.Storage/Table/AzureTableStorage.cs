using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using Radiostr.Model;

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

        public async Task Insert(string tableName, RadiostrTableEntity entity)
        {
            var table = _tableClient.GetTableReference(tableName);
            var insertOperation = TableOperation.Insert(entity);
            var result = await table.ExecuteAsync(insertOperation);
            Trace.TraceInformation("Inserted entity {0}, result = {1}", entity, result);
            //TODO: Handle error here?
        }

        public async Task Insert(string tableName, RadiostrTableEntity[] entities)
        {
            var table = _tableClient.GetTableReference(tableName);
            var insertOperation = new TableBatchOperation();
            entities.ToList().ForEach(insertOperation.Insert);
            var results = await table.ExecuteBatchAsync(insertOperation);
            Trace.TraceInformation("Inserted entities {0}, results = {1}", string.Join(",", entities.ToString()),
                string.Join(",", results.ToString()));
            //TODO: Handle errors here?
            //TODO: Return (abstracted) results?
        }

        public async Task<T> Retrieve<T>(string tableName, string partitionKey, string rowKey) where T:RadiostrTableEntity
        {
            var table = _tableClient.GetTableReference(tableName);
            var operation = TableOperation.Retrieve<T>(partitionKey, rowKey);
            var result = await table.ExecuteAsync(operation);
            return result.Result as T;
        }
    }
}
