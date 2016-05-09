namespace SimpleBookList.DAL.Interfaces
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Repository Pattern interface
    /// </summary>
    /// <typeparam name="T">Repository Item (class)</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get All items from Database
        /// </summary>
        /// <returns>Collection of Items</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get one item by his Id in Database
        /// </summary>
        /// <param name="itemId">Item id</param>
        /// <returns>Found Item</returns>
        T Get(int itemId);

        /// <summary>
        /// Find items in database
        /// </summary>
        /// <param name="predicate">Predicate for searching</param>
        /// <returns>Collection of found items</returns>
        IEnumerable<T> Find(Func<T, bool> predicate);

        /// <summary>
        /// Create new Item in Database
        /// </summary>
        /// <param name="item">new Item</param>
        /// <returns>new item</returns>
        T Create(T item);

        /// <summary>
        /// Update Item in database
        /// </summary>
        /// <param name="item">Item for update</param>
        void Update(T item);

        /// <summary>
        /// Delete Item from Database
        /// </summary>
        /// <param name="item">Item for delete</param>
        void Delete(T item);
    }
}
