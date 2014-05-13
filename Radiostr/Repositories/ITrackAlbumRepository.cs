namespace Radiostr.Repositories
{
    internal interface ITrackAlbumRepository
    {
        void Create(int trackId, int albumId);
        void Delete(int trackId, int albumId);
    }
}