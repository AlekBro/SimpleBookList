
namespace SimpleBookList.DAL.IdEntities
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    /// <summary>
    /// класс пользователя
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }



        // ----------------------------------------------------------------------------

        // http://metanit.com/sharp/mvc5/12.1.php

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        // Класс ApplicationUser наследует от IdentityUser все свойства. И кроме того добавляет метод GenerateUserIdentityAsync(), в котором с помощью вызова UserManager.CreateIdentityAsync создается объект ClaimsIdentity. Данный объект содержит информацию о данном пользователе.

        // Подобная архитектура позволяет взять уже готовый функционал и при необходимости добавить новый, например, добавить для пользователя новое свойство или добавить новую таблицу в бд.

        // http://metanit.com/sharp/mvc5/12.14.php

        // ----------------------------------------------------------------------------



    }

    // Класс IdentityUser является реализацией интерфейса IUser.

}
