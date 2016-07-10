
namespace SimpleBookList.DAL.Identity
{
    using SimpleBookList.DAL.IdEntities;
    using Microsoft.AspNet.Identity;

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {
        }
    }
}
