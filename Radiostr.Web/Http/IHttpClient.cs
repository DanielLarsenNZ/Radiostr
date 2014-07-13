using System.Threading.Tasks;

namespace Radiostr.Web.Http
{
    /// <summary>
    /// Defines an HTTP Client that is typically used to communicate with a Web API.
    /// </summary>
    /// <remarks><seealso cref="System.Net.Http.HttpClient"/></remarks>
    public interface IHttpClient
    {
        /// <summary>
        /// Makes an HTTP(S) GET request to <seealso cref="requestUrl"/> and returns the result as (awaitable Task of) <seealso cref="string"/>.
        /// </summary>
        /// <param name="requestUrl">The entire request URL.</param>
        /// <returns>An (awaitable Task of) <seealso cref="string"/> </returns>
        Task<string> GetAsync(string requestUrl);

        /// <summary>
        /// Makes an HTTP(S) POST request to <seealso cref="requestUrl"/> with <seealso cref="model"/> as the request body. Returns the result as (awaitable Task of) <seealso cref="string"/>.
        /// </summary>
        /// <param name="requestUrl">The entire request URL.</param>
        /// <param name="model">The model to serialise into the request body.</param>
        /// <returns>An (awaitable Task of) <seealso cref="string"/> </returns>
        Task<string> PostAsync(string requestUrl, object model);
    }
}
