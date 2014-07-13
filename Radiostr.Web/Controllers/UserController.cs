using Radiostr.Entities;
using Radiostr.Services;

namespace Radiostr.Web.Controllers
{
    public class UserController : RadiostrController<User>
    {
        // GET: User
        public UserController() : base(RadiostrService<User>.CreateService())
        {
        }
    }
}