namespace Radiostr.Web.Metrics
{
    public class MetricsModel
    {
        public string Key { get; set; }
        public int InstanceId { get; set; }
        public long Time { get; set; }
        public long Count { get; set; }
        public double Average { get; set; }
        public long Max { get; set; }
        public long Min { get; set; }

        public override string ToString()
        {
            return string.Format("Key = {0}, InstanceId = {1}, Time = {2}, Count = {3}, Average = {4}, Max = {5}, Min = {6}",
                Key, InstanceId, Time, Count, Average, Max, Min);
        }
    }
}