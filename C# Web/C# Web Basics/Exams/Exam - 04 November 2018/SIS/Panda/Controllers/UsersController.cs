namespace Panda.Controllers
{
    using Panda.Services;
    using Panda.ViewModels.Users;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            var user = this.usersService.GetUser(username, password);
            if (user == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(user.Id);
            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UsersRegisterInputModel input)
        {
            var user = this.usersService.GetUser(input.Username, input.Password);
            if (input.Username.Length < 5 || input.Username.Length > 20)
            {
                return this.Redirect("/Users/Register");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            if (input.Email.Length < 5 || input.Email.Length > 20)
            {
                return this.Redirect("/Users/Register");
            }

            if (user != null)
            {
                return this.Redirect("/Users/Register");
            }

            this.usersService.Create(input.Username, input.Email, input.Password);
            return this.Redirect("/");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}
