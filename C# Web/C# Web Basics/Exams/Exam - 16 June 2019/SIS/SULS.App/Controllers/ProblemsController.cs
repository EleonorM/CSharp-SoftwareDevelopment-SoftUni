namespace SULS.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using SULS.App.Services;
    using SULS.App.ViewModels.Problems;

    public class ProblemsController : Controller
    {
        private IProblemsService problemsService;

        public ProblemsController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(ProblemOutputModel outputModel)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (outputModel.Name.Length < 5 || outputModel.Name.Length > 20)
            {
                var error = new ErrorViewModel()
                {
                    Error = "Name should be between 5 and 20 characters.",
                };

                return this.View(error, "Error");
            }
            if (outputModel.Points < 50 || outputModel.Points > 300)
            {
                var error = new ErrorViewModel()
                {
                    Error = "Points should be between 50 and 300.",
                };

                return this.View(error, "Error");
            }

            this.problemsService.CreateProblem(outputModel.Name, outputModel.Points);
            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var model = this.problemsService.GetProblems(id);
            return this.View(model);
        }
    }
}
