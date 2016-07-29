using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBookList.BLL.Interfaces
{
    public interface IServiceCreator
    {
        IUserService CreateUserService(string connection);
    }
    // воспользуюсь абстрактной фабрикой, которую будет представлять интерфейс IServiceCreator.
}
