using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Radiostr.Web.Cache;
using Radiostr.Web.Http;
using Radiostr.Web.Metrics;
using Radiostr.Web.Models;
using Radiostr.Web.Services;
using Scale.Logger;

namespace Radiostr.Web.Controllers
{
    public class SpotifyController : RadiostrController
    {
        //[OutputCache(VaryByParam = "*", Duration = 60, Location = OutputCacheLocation.Any)] // TODO: OutputCache in Api Controller?

        /// <summary>
        /// Gets a list of all public Playlists subscribed to by a Spotify user for a given <see cref="spotifyUserId"/>.
        /// </summary>
        /// <param name="spotifyUserId">Spotify User Id. See https://developer.spotify.com/web-api/user-guide/#spotify-uris-and-ids. </param>
        /// <returns>A <see cref="MetricsResult"/> with a list of <see cref="SpotifyPlaylist"/> as data.</returns>
        public async Task<MetricsResult> GetPlaylists(string spotifyUserId)
        {
            MetricsResult result;

            using (result = new MetricsResult(Metrics, "Radiostr.Web.Controllers.SpotifyController.GetPlaylists"))
            {
                if (string.IsNullOrEmpty(spotifyUserId)) throw new ArgumentNullException("spotifyUserId");
                spotifyUserId = spotifyUserId.ToLower();

                var service =
                    new SpotifyService(new SpotifyHttpClient(new HttpClient(),
                        new HttpContextCache(new HttpContextWrapper(HttpContext.Current)),
                        new LoggerRegistry()));

                result.Data = await service.GetPlaylists(spotifyUserId);
            }

            return result;
        }
    }
}
