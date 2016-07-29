using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBookList.BLL.Interfaces;
using SimpleBookList.DAL.Repositories;

namespace SimpleBookList.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new UnitOfWork(connection));
        }
    }
    // класс фабрики, которая будет создавать сервис абстрактной фабрики
}
