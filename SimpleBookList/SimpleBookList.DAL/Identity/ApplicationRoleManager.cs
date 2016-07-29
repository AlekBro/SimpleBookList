namespace SimpleBookList.DAL.Identity
{
    using SimpleBookList.DAL.IdEntities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;


    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(RoleStore<ApplicationRole> store)
                    : base(store)
        { }
    }
    // Это стандартный для ASP.NET Identity класс по управлению ролями.

    // Для работы с ролями и их управлением в AspNet Identity определен класс RoleManager. Классы UserManager и RoleManager находятся в библиотеке Microsoft.AspNet.Identity.Core.

    // Каждая роль представляет реализацию интерфейса IRole, а управление ролями классом RoleManager происходит через хранилище IRoleStore.


    // http://metanit.com/sharp/mvc5/12.14.php
    // Для управления ролями в ASP.NET Identity имеется класс RoleManager<T>, где T представляет реализацию интерфейса IRole.
}
