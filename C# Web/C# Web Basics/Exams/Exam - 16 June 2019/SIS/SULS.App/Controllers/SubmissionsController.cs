namespace SULS.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using SULS.App.Services;
    using SULS.App.ViewModels.Submissions;

    public class SubmissionsController : Controller
    {
        private ISubmissionsService service;

        public SubmissionsController(ISubmissionsService service)
        {
            this.service = service;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var viewData = this.service.GetProblem(id);
            return this.View(viewData);
        }

        [HttpPost]
        public HttpResponse Create(SubmissionCreateModel model)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }
            if (model.Code.Length < 30 || model.Code.Length > 800)
            {
                return this.Error("Code should be between 30 and 800 characters.");
            }
            this.service.CreateSubmission(model.Code, this.User, model.ProblemId);
            return this.Redirect("/");
        }

        public HttpResponse Delete(string id)
        {

            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            this.service.DeleteSubmission(id);
            return this.Redirect("/");
        }

        [HttpPost]
        public HttpResponse DoDelete()
        {

            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.Redirect("/");
        }
    }
}
