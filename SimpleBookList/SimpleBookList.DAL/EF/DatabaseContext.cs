
namespace SimpleBookList.DAL.EF
{
    using System.Data.Entity;
    using Entities;

    /// <summary>
    /// Class for work with the database
    /// </summary>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Initializes static members of the <see cref="DatabaseContext" /> class.
        /// </summary>
        static DatabaseContext()
        {
            Database.SetInitializer<DatabaseContext>(new DatabaseInitializer());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseContext" /> class.
        /// </summary>
        /// <param name="connectingString">String with settings for connection to the Database</param>
        public DatabaseContext(string connectingString)
            : base(connectingString)
        {
        }

        /// <summary>
        /// Gets or sets collection of Book entities
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Gets or sets collection of Author entities
        /// </summary>
        public DbSet<Author> Authors { get; set; }
    }
}
