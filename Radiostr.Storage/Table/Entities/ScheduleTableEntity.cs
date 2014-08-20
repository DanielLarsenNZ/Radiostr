using System.ComponentModel.DataAnnotations;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using Radiostr.Model;
using Radiostr.Model.Extensions;

namespace Radiostr.Storage.Table.Entities
{
    public class ScheduleTableEntity : TableEntity
    {
        public ScheduleTableEntity()
        {
        }

        public ScheduleTableEntity(Schedule schedule)
        {
            schedule.Validate();
            PartitionKey = schedule.StationId;
            RowKey = schedule.Id.ToString("N");
            ScheduleJson = JsonConvert.SerializeObject(schedule);
        }

        [Required]
        public string ScheduleJson { get; set; }
    }
}
