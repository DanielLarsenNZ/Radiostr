using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Radiostr.Web.Metrics
{
    /// <summary>
    /// A result that includes Metrics data.
    /// </summary>
    public class MetricsResult : IDisposable
    {
        private readonly MetricsRegistry _registry;
        private readonly Timer _timer;

        public MetricsResult(MetricsRegistry registry, string key)
        {
            _registry = registry;
            _timer = _registry.Timer(key);
        }

        [JsonProperty(PropertyName = "data")]
        public object Data { get; set; }

        [JsonProperty(PropertyName = "metrics")]
        public MetricsModel Metrics { get; set; }
        
        public void Dispose()
        {
            //TODO isDisposed
            _timer.Stop();
            Metrics = _registry.GetMetrics(_timer);
        }
    }
}