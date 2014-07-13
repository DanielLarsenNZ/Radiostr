using Newtonsoft.Json;

namespace Radiostr.Web.Metrics
{
    public class MetricsModel
    {
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "instanceId")]
        public int InstanceId { get; set; }

        [JsonProperty(PropertyName = "time")]
        public long Time { get; set; }

        [JsonProperty(PropertyName = "count")]
        public long Count { get; set; }

        [JsonProperty(PropertyName = "average")]
        public double Average { get; set; }

        [JsonProperty(PropertyName = "max")]
        public long Max { get; set; }

        [JsonProperty(PropertyName = "min")]
        public long Min { get; set; }

        public override string ToString()
        {
            return string.Format("Key = {0}, InstanceId = {1}, Time = {2}, Count = {3}, Average = {4}, Max = {5}, Min = {6}",
                Key, InstanceId, Time, Count, Average, Max, Min);
        }
    }
}