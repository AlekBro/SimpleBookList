namespace SimpleBookList.DAL.Interfaces
{
    using SimpleBookList.DAL.IdEntities;
    using System;

    /// <summary>
    /// интерфейс управления профилями пользователей
    /// </summary>
    public interface IClientManager : IDisposable
    {
        /// <summary>
        /// метод для создания нового профиля пользователя.
        /// </summary>
        /// <param name="item"></param>
        void Create(ClientProfile item);
    }
}
