using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace Radiostr.Model
{
    [Obsolete]
    public abstract class RadiostrTableEntity : TableEntity
    {
        //private readonly Lazy<string> _version = new Lazy<string>(() => Assembly.GetEntryAssembly().GetName().Version.ToString()); 

        /// <summary>
        /// Initialises the infrastructure properties of a newly created entity.
        /// </summary>
        protected void Init()
        {
            if (!string.IsNullOrEmpty(RowKey) || !string.IsNullOrEmpty(PartitionKey) || !string.IsNullOrEmpty(Version))
            {
                throw new InvalidOperationException(
                    "Entity has already been initalised, or retrieved from storage. Init() should only be called when an entity is created.");
            }

            RowKey = Guid.NewGuid().ToString("N");
            PartitionKey = DerivePartitionKey();
            //Version = _version.Value;
            Version = "1.0.0";  //TODO: Not sure we even need this, and what version number it should be tied to.
        }

        /// <summary>
        /// Derives a Partition Key based on the properties of this entity.
        /// </summary>
        internal abstract string DerivePartitionKey();

        /// <summary>
        /// The app version at the time this entity was created.
        /// </summary>
        public string Version { get; set; }

        public override string ToString()
        {
            return string.Format("(RadiostrTableEntity RowKey = {0}, PartitionKey = {1}, Version = {2}, Timestamp = {3}, ETag = {4})",
                RowKey, PartitionKey, Version, Timestamp, ETag);
        }
    }
}
