namespace SimpleBookList.DAL.Repositories
{
    using EF;
    using IdEntities;
    using Interfaces;

    /// <summary>
    /// Класс управления профилями
    /// </summary>
    public class ClientManager : IClientManager
    {
        public ApplicationDbContext Database { get; set; }
        public ClientManager(ApplicationDbContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
