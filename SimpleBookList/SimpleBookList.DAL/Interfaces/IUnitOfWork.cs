// -----------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
namespace SimpleBookList.DAL.Interfaces
{
    using System;
    using System.Threading.Tasks;

    using Identity;

    /// <summary>
    /// Unit Of Work Pattern interface
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets Repository for working with Books
        /// </summary>
        IRepository<Book> BooksRepository { get; }

        /// <summary>
        /// Gets Repository for working with Authors
        /// </summary>
        IRepository<Author> AuthorsRepository { get; }

        /// <summary>
        /// Save all changes in Database
        /// </summary>
        void Save();


        // Объект UnitOfWork будет содержать ссылки на менеджеры пользователей и ролей, а также на репозиторий пользователей.
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();

    }
}
