namespace Radiostr.Web.Metrics
{
    /// <summary>
    /// A registry for Metrics objects.
    /// </summary>
    public interface IMetricsRegistry
    {
        Timer Timer(string key);
        MetricsModel GetMetrics(Timer timer);
    }
}