namespace SULS.App
{
    using Microsoft.EntityFrameworkCore;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using SULS.App.Services;
    using System.Collections.Generic;

    public class Startup : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IHomeService, HomeService>();
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProblemsService, ProblemsService>();
            serviceCollection.Add<ISubmissionsService, SubmissionsService>();
        }

        public void Configure(IList<Route> routeTable)
        {
            var db = new SulsDbContext();
            db.Database.Migrate();
        }
    }
}
