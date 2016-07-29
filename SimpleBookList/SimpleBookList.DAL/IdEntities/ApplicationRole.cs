namespace SimpleBookList.DAL.IdEntities
{
    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    /// класс роли
    /// </summary>
    public class ApplicationRole : IdentityRole
    {
    }

    // http://metanit.com/sharp/mvc5/12.14.php
    // Каждая роль в ASP.NET Identity представляет объект интерфейса IRole. В Entity Framework имеется встроенная реализация данного интерфейса в виде класса IdentityRole.
}
