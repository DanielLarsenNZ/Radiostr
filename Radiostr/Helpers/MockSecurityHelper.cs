namespace Radiostr.Helpers
{
    public class MockSecurityHelper : ISecurityHelper
    {
        public void Authenticate()
        {
        }

        public void Authenticate(int stationId)
        {
        }

        public void Authenticate(int stationId, int libraryId)
        {
        }

        public void Authorise(string role)
        {
        }
    }
}