namespace Radiostr.Helpers
{
    /// <summary>
    /// Defines a general purpose cross-cutting helper for authentication, authorisation and more.
    /// </summary>
    public interface ISecurityHelper
    {
        void Authenticate();
        void Authenticate(int stationId);
        void Authenticate(int stationId, int libraryId);
        void Authorise(string role);
    }
}