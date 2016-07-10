namespace SimpleBookList.DAL.Interfaces
{
    using SimpleBookList.DAL.IdEntities;
    using System;

    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}
