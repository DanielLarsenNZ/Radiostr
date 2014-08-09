using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiostr.Model;
using Radiostr.Storage.Table;

namespace Radiostr.Storage.Tests.Table
{
    [TestClass]
    public class AzureTableStorageTests
    {
        //[TestMethod]
        public async Task BigInsertTest() 
        {
            // Arrange
            const string tableName = "testtrack";

            var track = new TrackModel("Protection", new ArtistModel {Name = "Massive Attack"}, 1000);

            var storage =
                new AzureTableStorage(new NameValueCollection(System.Configuration.ConfigurationManager.AppSettings));
            

            // Act
            await storage.CreateTables(new[] {tableName});
            await storage.Insert(tableName, track);
            var retrievedTrack = await storage.Retrieve<TrackModel>(tableName, track.PartitionKey, track.RowKey);

            // Assert
            Debug.WriteLine(retrievedTrack);
        }
    }
}
