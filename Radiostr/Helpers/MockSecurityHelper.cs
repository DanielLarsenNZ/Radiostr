namespace Radiostr.Helpers
{
    public class MockSecurityHelper : ISecurityHelper
    {
        public void Authenticate()
        {
        }

        public void Authorise(int stationId)
        {
        }

        public void Authorise(int stationId, int libraryId)
        {
        }

        public void Authorise(string role)
        {
        }
    }
}