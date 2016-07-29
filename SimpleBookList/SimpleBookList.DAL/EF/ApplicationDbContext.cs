namespace SimpleBookList.DAL.EF
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using IdEntities;

    // Данный класс наследуется от класса IdentityDbContext и поэтому уже имеет свойства Users и Roles, позволяющие взаимодействовать с таблицами пользователей и ролей.
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(string conectionString) : base(conectionString)
        {
            Database.SetInitializer<ApplicationDbContext>(new AppDbInitializer());

            //Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());

        }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
