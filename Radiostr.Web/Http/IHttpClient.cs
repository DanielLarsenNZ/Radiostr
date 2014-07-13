using System.Threading.Tasks;

namespace Radiostr.Web.Http
{
    public interface IHttpClient
    {
        Task<string> GetAsync(string requestUrl);
        Task<string> PostAsync(string requestUrl, object model);
    }
}
