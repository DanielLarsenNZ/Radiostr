using System;
using System.Threading.Tasks;
using System.Web.Http;
using Radiostr.Model;
using Radiostr.Storage.Queue;
using Radiostr.Web.Metrics;
using Radiostr.Services;

namespace Radiostr.Web.Controllers
{
    public class PlaylistController : RadiostrController
    {
        //[OutputCache(VaryByParam = "*", Duration = 60, Location = OutputCacheLocation.Any)] // TODO: OutputCache in Api Controller?

        /// <summary>
        /// Gets a list of all public Playlists subscribed to by a Spotify user for a given <see cref="userId"/>.
        /// </summary>
        /// <param name="service">The name of the playlist service. Only "spotify" is currently supported.</param>
        /// <param name="userId">Spotify User Id. See https://developer.spotify.com/web-api/user-guide/#spotify-uris-and-ids. </param>
        /// <returns>A <see cref="MetricsResult"/> with a list of <see cref="PlaylistModel"/> as data.</returns>
        public async Task<MetricsResult> Get(string service, string userId)
        {
            MetricsResult result;

            using (result = new MetricsResult(Metrics, "Radiostr.Web.Controllers.PlaylistController.GetPlaylists"))
            {
                if (string.IsNullOrEmpty(service)) throw new ArgumentNullException("service");
                if (service != "spotify") throw new NotSupportedException(service + " service is not currently supported.");
                if (string.IsNullOrEmpty(userId)) throw new ArgumentNullException("userId");
                
                userId = userId.ToLower();

                // TODO: Dependency Resolver
                var spotifyService = SpotifyService.GetService();
                result.Data = await spotifyService.GetPlaylists(userId);
            }

            return result;
        }

        /// <summary>
        /// Adds the Tracks from a Playlist to a user's library.
        /// </summary>
        public async Task<IHttpActionResult> Post(PlaylistImportModel model)
        {
            if (model.ServiceName != "spotify") throw new NotSupportedException(model.ServiceName + " service is not currently supported.");

            var queue = new AzureQueueStorage();    //TODO: IoC
            await queue.AddMessage(new QueueMessage(PlaylistImportModel.QueueName, model));

            return Ok();
        }
    }
}
