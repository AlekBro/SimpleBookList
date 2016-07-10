namespace SimpleBookList.BLL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using SimpleBookList.BLL.Infrastructure;
    using Models;
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(LoginModel user);
        Task<ClaimsIdentity> Authenticate(LoginModel user);
        Task SetInitialData(LoginModel admin, List<string> roles);
    }
}
