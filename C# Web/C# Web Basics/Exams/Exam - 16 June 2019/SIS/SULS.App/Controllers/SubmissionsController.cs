namespace SULS.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using SULS.App.ViewModels.Submissions;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SubmissionsController : Controller
    {
        public HttpResponse Create()
        {
            var viewData = new SubmissionsViewModel()
            {

            };
            return this.View(viewData);
        }

        [HttpPost]
        public HttpResponse Create(string code)
        {
            return this.Redirect("/");
        }
        
        public HttpResponse Delete()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse DoDelete()
        {
            return this.Redirect("/");
        }
    }
}
