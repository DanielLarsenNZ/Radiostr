using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Radiostr.Web.Cache;
using Scale.Logger;

namespace Radiostr.Web.Http
{
    /// <summary>
    /// An HTTP Client for communicating with the Spotify Web API.
    /// </summary>
    /// <remarks>See https://developer.spotify.com/web-api/ </remarks>
    public class SpotifyHttpClient : IHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly ICache _cache;
        private readonly ILogger _log;

        public SpotifyHttpClient(HttpClient httpClient, ICache cache, ILoggerRegistry loggerRegistry)
        {
            _httpClient = httpClient;
            _cache = cache;
            _log =
                loggerRegistry.Logger(
                    loggerRegistry.MakeKey(new object[]
                    {"Radiostr.Web.Http", "SpotifyHttpClient", GetHashCode()}));
        }

        /// <summary>
        /// Makes an HTTP(S) GET request to <seealso cref="requestUrl"/> and returns the result as (awaitable Task of) <seealso cref="string"/>.
        /// </summary>
        /// <param name="requestUrl">The entire request URL.</param>
        /// <returns>An (awaitable Task of) <seealso cref="string"/></returns>
        /// <remarks>Will Authorise using the values of the SpotifyApiClientId and SpotifyApiClientSecret appSettings. See 
        /// https://developer.spotify.com/web-api/authorization-guide/#client-credentials-flow </remarks>
        public async Task<string> GetAsync(string requestUrl)
        {
            await SetAuthorizationHeader();

            //TODO: Implement if-modified-since support, serving from cache if response = 304

            _log.Message("GET {0}", new object[] { requestUrl });
            var response = await _httpClient.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Makes an HTTP(S) POST request to <seealso cref="requestUrl"/> with <seealso cref="model"/> as the request body. Returns the result as (awaitable Task of) <seealso cref="string"/>.
        /// </summary>
        /// <param name="requestUrl">The entire request URL.</param>
        /// <param name="model">The model to serialise into the request body.</param>
        /// <returns>An (awaitable Task of) <seealso cref="string"/> </returns>
        /// <remarks>Will Authorise using the values of the SpotifyApiClientId and SpotifyApiClientSecret appSettings. See 
        /// https://developer.spotify.com/web-api/authorization-guide/#client-credentials-flow </remarks>
        public async Task<string> PostAsync(string requestUrl, object model)
        {
            throw new NotImplementedException();
        }

        private async Task SetAuthorizationHeader()
        {
            const string cacheKey = "Radiostr.Web.Http.SpotifyHttpClient.BearerToken";

            var token = (string) _cache.Get(cacheKey);

            if (token == null)
            {
                // post client ID and Secret to get bearer token
                string clientId = ConfigurationManager.AppSettings["SpotifyApiClientId"];
                string clientSecret = ConfigurationManager.AppSettings["SpotifyApiClientSecret"];

                if (string.IsNullOrEmpty(clientId)) throw new InvalidOperationException("AppSetting SpotifyApiClientId is not set.");
                if (string.IsNullOrEmpty(clientSecret)) throw new InvalidOperationException("AppSetting SpotifyApiClientSecret is not set.");

                // set Basic authentication header
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(
                        Encoding.ASCII.GetBytes(string.Format("{0}:{1}", clientId, clientSecret))));

                var now = DateTime.Now;
                const string url = "https://accounts.spotify.com/api/token";
                var json = await PostJsonAsync(url, "grant_type=client_credentials");

                // deserialise the token
                dynamic tokenData = JsonConvert.DeserializeObject(json);
                token = tokenData.access_token;

                // add to cache with an absolute expiry as indicated by Spotify
                _cache.Add(cacheKey, token, now.AddSeconds(Convert.ToInt32(tokenData.expires_in)));
            }

            // set Bearer Authorisation header
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        private async Task<string> PostJsonAsync(string requestUrl, string requestBody)
        {
            // post request
            _log.Message("POST {0}", new object[] {requestUrl});

            var response =
                await
                    _httpClient.PostAsync(requestUrl,
                        new StringContent(requestBody, Encoding.UTF8, "application/x-www-form-urlencoded"));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}