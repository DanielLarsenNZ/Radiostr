using System.Linq;
using System.Threading.Tasks;
using Radiostr.Storage.Queue;
using Radiostr.Storage.Queue.Models;

namespace Radiostr.Services
{
    public class TransmitterService
    {
        private readonly IQueueStorage _queue;
        private readonly ILibraryService _libraryService;

        internal TransmitterService(IQueueStorage queueStorage, ILibraryService libraryService)
        {
            _queue = queueStorage;
            _libraryService = libraryService;
        }

        public async Task Start(string stationId)
        {
            // get libraries for the station
            var libraries = await _libraryService.GetList(new {stationId});

            // Select a schedule
            var model = new SelectScheduleModel
            {
                StationId = stationId,
                LibraryIds = libraries.Select(l => l.Id).ToArray(),
                TrackCount = 20,
                UserId = "1" //TODO
            };

            await _queue.AddMessage(new QueueMessage(QueueNames.SelectSchedule, model));
        }

        public static TransmitterService GetService()
        {
            return new TransmitterService(AzureQueueStorage.GetStorage(), LibraryService.CreateLibraryService());
        }
    }
}
