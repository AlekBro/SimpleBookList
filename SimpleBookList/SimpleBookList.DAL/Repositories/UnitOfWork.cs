// -----------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.DAL.Repositories
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity.EntityFramework;

    using DAL;
    using Interfaces;
    using EF;
    using Identity;
    using IdEntities;
    /// <summary>
    /// implementation of Unit Of Work Pattern interface 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// keeps Context for interacting with Database
        /// </summary>
        private Entities context;

        /// <summary>
        /// keeps Repository with Books
        /// </summary>
        private IRepository<Book> bookRepository;

        /// <summary>
        /// keeps Repository with Authors
        /// </summary>
        private IRepository<Author> authorRepository;

        /// <summary>
        /// Flag: Has Dispose already been called?
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        /// <param name="connectionString">String with settings for connection to the Database</param>
        public UnitOfWork(string connectionString)
        {
            this.context = new Entities(connectionString);

            db = new ApplicationContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            clientManager = new ClientManager(db);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        ~UnitOfWork()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Gets Books Repository property - return Repository
        /// </summary>
        public IRepository<Book> BooksRepository
        {
            get
            {
                if (this.bookRepository == null)
                {
                    this.bookRepository = new BookRepository(this.context);
                }

                return this.bookRepository;
            }
        }

        /// <summary>
        /// Gets Authors Repository property - return Repository
        /// </summary>
        public IRepository<Author> AuthorsRepository
        {
            get
            {
                if (this.authorRepository == null)
                {
                    this.authorRepository = new AuthorRepository(this.context);
                }

                return this.authorRepository;
            }
        }

        /// <summary>
        /// Save all changes in Database
        /// </summary>
        public void Save()
        {
            this.context.SaveChanges();
            this.db.SaveChanges();
        }

        /// https://msdn.microsoft.com/en-us/library/fs2xkftw%28v=vs.110%29.aspx
        /// <summary>
        /// Public implementation of Dispose pattern callable by consumers
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Protected implementation of Dispose pattern.
        /// </summary>
        /// <param name="disposing">Indicates whether the method call comes from a Dispose method</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                // Free any other managed objects here.
                this.context.Dispose();

                this.db.Dispose(); // ??????
                this.userManager.Dispose();
                this.roleManager.Dispose();
                this.clientManager.Dispose();
            }

            // Free any unmanaged objects here.
            this.disposed = true;
        }




        private ApplicationContext db;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IClientManager clientManager;


        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public IClientManager ClientManager
        {
            get { return clientManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public async Task SaveAsync()
        {
            await this.db.SaveChangesAsync();
            await this.context.SaveChangesAsync(); //
        }


    }
}
