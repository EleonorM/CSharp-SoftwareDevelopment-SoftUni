namespace Panda
{
    using Microsoft.EntityFrameworkCore;
    using Panda.Services;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System.Collections.Generic;

    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            var db = new PandaDbContext();
            db.Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IHomeService, HomeService>();
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IReceiptsService, ReceiptsService>();
            serviceCollection.Add<IPackagesService, PackagesService>();
        }
    }
}
