namespace SULS.App.Services
{
    using SULS.App.ViewModels.Home;
    using System.Linq;

    public class HomeService : IHomeService
    {
        private SulsDbContext db;

        public HomeService(SulsDbContext db)
        {
            this.db = db;
        }

        public ProblemsDetailsModel GetProblem()
        {
            var model = new ProblemsDetailsModel
            {
                Problems = this.db.Problems.Select(x => new ProblemModel
                {
                    Id = x.Id,
                    Count = x.Submissions.Count(),
                    Name = x.Name,
                }).ToList(),
            };

            return model;
        }
    }
}
