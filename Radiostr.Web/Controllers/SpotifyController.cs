using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Radiostr.Web.Cache;
using Radiostr.Web.Http;
using Radiostr.Web.Models;
using Radiostr.Web.Services;
using Scale.Logger;

namespace Radiostr.Web.Controllers
{
    public class SpotifyController : ApiController
    {
        //[OutputCache(VaryByParam = "*", Duration = 60, Location = OutputCacheLocation.Any)] // TODO: OutputCache in Api Controller?
        public async Task<IEnumerable<SpotifyPlaylist>> GetPlaylists(string spotifyUsername)
        {
            var service =
                new SpotifyService(new SpotifyHttpClient(new HttpClient(),
                    new HttpContextCache(new HttpContextWrapper(HttpContext.Current)),
                    new LoggerRegistry()));
            
            return await service.GetPlaylists(spotifyUsername);
        }
    }
}
