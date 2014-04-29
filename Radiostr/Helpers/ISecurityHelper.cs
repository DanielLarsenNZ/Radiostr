namespace Radiostr.Helpers
{
    /// <summary>
    /// Defines a general purpose cross-cutting helper for authentication, authorisation and more.
    /// </summary>
    public interface ISecurityHelper
    {
        void Authenticate();
        void Authorise(string role);
        void Authorise(int stationId);
        void Authorise(int stationId, int libraryId);
    }
}