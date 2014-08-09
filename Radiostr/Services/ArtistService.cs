using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radiostr.Data;
using Radiostr.Helpers;
using Radiostr.Model;
using Radiostr.Model.Entities;
using Radiostr.Repositories;

namespace Radiostr.Services
{
    public class ArtistService : RadiostrService<Artist>, IArtistService
    {
        internal ArtistService(ISecurityHelper securityHelper, IRepository<Artist> repository) : base(securityHelper, repository)
        {
        }

        public async Task<ArtistModel[]> GetList(int[] artistIds)
        {
            var artists = await Repository.Query<Artist>("select Name from Artist where id in (@artistIds)", artistIds);
            var uris =
                await
                    Repository.Query<ArtistUri>("select * from ArtistUrl where ArtistId in (@artistIds)",
                        new {artistIds});
            return
                artists.Select(
                    a =>
                        new ArtistModel
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Uri = uris.Where(u => u.ArtistId == a.Id).Select(u => u.Uri).ToArray()
                        }).ToArray();
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