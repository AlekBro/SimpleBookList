
namespace SimpleBookList.BLL.Services
{

    using SimpleBookList.BLL.Infrastructure;
    using SimpleBookList.DAL.IdEntities;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using System.Security.Claims;
    using SimpleBookList.BLL.Interfaces;
    using SimpleBookList.DAL.Interfaces;
    using System.Collections.Generic;
    using Models;
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> Create(LoginModel user)
        {
            ApplicationUser appUser = await Database.UserManager.FindByEmailAsync(user.Email);
            if (appUser == null)
            {
                appUser = new ApplicationUser { Email = user.Email, UserName = user.Email };
                await Database.UserManager.CreateAsync(appUser, user.Password);
                // добавляем роль
                await Database.UserManager.AddToRoleAsync(appUser.Id, user.Role);
                // создаем профиль клиента
                ClientProfile clientProfile = new ClientProfile { Id = appUser.Id, Address = user.Address, Name = user.Name };
                Database.ClientManager.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(LoginModel user)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            ApplicationUser appUser = await Database.UserManager.FindAsync(user.Email, user.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (appUser != null)
                claim = await Database.UserManager.CreateIdentityAsync(appUser,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        // начальная инициализация бд
        public async Task SetInitialData(LoginModel admin, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }
            await Create(admin);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
