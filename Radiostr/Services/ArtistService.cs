using System.Collections.Generic;
using System.Threading.Tasks;
using Radiostr.Data;
using Radiostr.Entities;
using Radiostr.Helpers;
using Radiostr.Repositories;

namespace Radiostr.Services
{
    public class ArtistService : RadiostrService<Artist>
    {
        internal ArtistService(ISecurityHelper securityHelper, IRepository<Artist> repository) : base(securityHelper, repository)
        {
        }

        public async override Task<IEnumerable<Artist>> GetList(dynamic param)
        {
            return await Repository.GetList("select * from Artist where Name = @artist", param);
        }

        public static ArtistService CreateArtistService()
        {
            return new ArtistService(new MockSecurityHelper(), new RadiostrRepository<Artist>(new RadiostrDbConnection()));
        }
    }
}