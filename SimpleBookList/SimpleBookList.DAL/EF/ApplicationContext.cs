namespace SimpleBookList.DAL.EF
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using IdEntities;


    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString) : base(conectionString) { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
