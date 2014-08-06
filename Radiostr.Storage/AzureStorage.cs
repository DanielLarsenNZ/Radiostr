using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Radiostr.Storage.Queue;

namespace Radiostr.Storage
{
    public abstract class AzureStorage
    {
        protected readonly NameValueCollection Settings;
        protected readonly CloudStorageAccount StorageAccount;
        

        /// <summary>
        /// Instantiates a new <see cref="AzureQueueStorage"/> service.
        /// </summary>
        protected internal AzureStorage(NameValueCollection settings)
        {
            if (settings == null) throw new ArgumentNullException("settings");

            Settings = settings;

            string connectionString = Settings["StorageConnectionString"];
            if (string.IsNullOrEmpty(connectionString)) throw new InvalidOperationException("StorageConnectionString was not found in settings.");

            StorageAccount = CloudStorageAccount.Parse(connectionString);
        }
    }
}
