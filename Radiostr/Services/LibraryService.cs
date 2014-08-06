using System.Collections.Generic;
using System.Threading.Tasks;
using Radiostr.Data;
using Radiostr.Helpers;
using Radiostr.Model.Entities;
using Radiostr.Repositories;

namespace Radiostr.Services
{
    public class LibraryService : RadiostrService<Library>
    {
        internal LibraryService(ISecurityHelper securityHelper, IRepository<Library> repository) : base(securityHelper, repository)
        {
        }

        public async override Task<IEnumerable<Library>> GetList(dynamic param)
        {
            return await Repository.GetList("select * from Library where StationId = @stationId", param);
        }

        /// <summary>
        /// Public factory method, in lieu of IoC.
        /// </summary>
        public static LibraryService CreateLibraryService()
        {
            return new LibraryService(new MockSecurityHelper(), new RadiostrRepository<Library>(new RadiostrDbConnection()));
        }
    }
}
