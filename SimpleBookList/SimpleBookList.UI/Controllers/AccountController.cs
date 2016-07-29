namespace SimpleBookList.Controllers
{
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.Owin.Security;
    using Microsoft.AspNet.Identity.Owin;
    using System.Threading.Tasks;
    using System.Security.Claims;


    using BLL.Interfaces;
    using BLL.Infrastructure;
    using Models;
    using Models.IdentityModels;

    public class AccountController : Controller
    {
        private IUserService UserService
        {
            get
            {
                // Поскольку ранее мы зарегитрировали сервис пользователей через контекст OWIN, то теперь мы можем получить этот сервис с помощью метода
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                LoginViewModel user = new LoginViewModel { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await UserService.Authenticate(user);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                LoginViewModel user = new LoginViewModel
                {
                    Email = model.Email,
                    Password = model.Password,
                    Address = model.Address,
                    Name = model.Name,
                    Role = "user"
                };
                OperationDetails operationDetails = await UserService.Create(user);
                if (operationDetails.Succedeed)
                    return View("SuccessRegister");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }


        private async Task SetInitialDataAsync()
        {
            LoginViewModel newLogin = new LoginViewModel
            {
                Email = "somemail@mail.ru",
                UserName = "somemail@mail.ru",
                Password = "ad46D_ewr3",
                Name = "Семен Семенович Горбунков",
                Address = "ул. Спортивная, д.30, кв.75",
                Role = "admin",
            };

            List<string> newRoles = new List<string> { "user", "admin" };

            await UserService.SetInitialData(newLogin, newRoles);
        }
    }
}