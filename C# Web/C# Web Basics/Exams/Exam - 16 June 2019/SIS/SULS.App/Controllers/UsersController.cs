namespace SULS.App.Controllers
{
    using SIS.HTTP;
    using SIS.HTTP.Logging;
    using SIS.MvcFramework;
    using SULS.App.Services;
    using SULS.App.ViewModels.Users;

    public class UsersController : Controller
    {
        private IUsersService usersService;
        private ILogger logger;

        public UsersController(IUsersService usersService, ILogger logger)
        {
            this.usersService = usersService;
            this.logger = logger;
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            var userId = this.usersService.GetUserId(username, password);
            if (userId == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userId);
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

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel inputModel)
        {
            if (inputModel.Password != inputModel.ConfirmPassword)
            {
                return this.Error("Passwords should be the same!");
            }
            if (usersService.GetUser(inputModel.Username) != null)
            {
                return this.Error("User with this username already exist.");
            }
            if (usersService.IsEmailUsed(inputModel.Email))
            {
                return this.Error("User with this email already exist.");
            }
            if (inputModel.Username?.Length < 5 || inputModel.Username?.Length > 20)
            {
                return this.Error("Username should be between 5 and 20 characters .");
            }
            if (inputModel.Password?.Length < 6 || inputModel.Password?.Length > 20)
            {
                return this.Error("Password should be between 6 and 20 characters .");
            }

            usersService.CreateUser(inputModel.Username, inputModel.Email, inputModel.Password);

            return this.Redirect("/Users/Login");
        }
    }
}
