using Dapper;
using Radiostr.Data;

namespace Radiostr.Repositories
{
    internal class TrackAlbumRepository : ITrackAlbumRepository
    {
        private readonly IRadiostrDbConnection _db;

        internal TrackAlbumRepository(IRadiostrDbConnection db)
        {
            _db = db;
        }

        public void Create(int trackId, int albumId)
        {
            using (var conn = _db.GetDbConnection())
            {
                conn.Open();
                conn.Execute("insert into TrackAlbum (TrackId, AlbumId) values (@trackId, @albumId)",
                    new {trackId, albumId});
                conn.Close();
            }
        }

        public void Delete(int trackId, int albumId)
        {
            using (var conn = _db.GetDbConnection())
            {
                conn.Open();
                conn.Execute("delete from TrackAlbum where TrackId = @trackId and AlbumId = @albumId",
                    new { trackId, albumId });
                conn.Close();
            }            
        }
    }
}