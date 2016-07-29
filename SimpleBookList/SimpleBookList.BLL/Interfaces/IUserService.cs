namespace SimpleBookList.BLL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using SimpleBookList.BLL.Infrastructure;
    using Models;
    using Models.IdentityModels;

    /// <summary>
    /// 
    /// </summary>
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(LoginViewModel user);
        Task<ClaimsIdentity> Authenticate(LoginViewModel user);
        Task SetInitialData(LoginViewModel admin, List<string> roles);
    }
    // Через объекты данного интерфейса уровень представления будет взаимодействовать с уровнем доступа к данным. Здесь определены только три метода: Create (создание пользователей), Authenticate (аутентификация пользователей) и SetInitialData (установка начальных данных в БД - админа и списка ролей).
}
