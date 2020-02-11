namespace SULS.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProblemsController : Controller
    {
        public HttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse DoCreate()
        {
            return this.Redirect("/");
        }

        public HttpResponse Details()
        {
            return this.View();
        }
    }
}
