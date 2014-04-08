using System.Data;

namespace Radiostr.Data
{
    public interface IRadiostrDbConnection
    {
        IDbConnection GetDbConnection();
    }
}