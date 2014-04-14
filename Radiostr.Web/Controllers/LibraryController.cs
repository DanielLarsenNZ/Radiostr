using System.Collections.Generic;
using Radiostr.Model;
using Radiostr.Services;

namespace Radiostr.Web.Controllers
{
    public class LibraryController : RadiostrController<Library>
    {
        public LibraryController() : base(LibraryService.CreateLibraryService()) //TODO: No longer testable. IoC please.
        {
        }
    }
}
