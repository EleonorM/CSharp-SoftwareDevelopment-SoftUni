namespace SULS.App.Services
{
    using Microsoft.EntityFrameworkCore;
    using SULS.App.Models;
    using SULS.App.ViewModels.Problems;
    using System;
    using System.Linq;

    public class ProblemsService : IProblemsService
    {
        private SulsDbContext db;

        public ProblemsService(SulsDbContext db)
        {
            this.db = db;
        }

        public void CreateProblem(string name, int points)
        {
            var problem = new Problem()
            {
                Name = name,
                Points = points,

            };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }
        
        public ProblemsDetailsModel GetProblems(string id)
        {
            var model = this.db.Problems.Where(x => x.Id == id).Select(y => new ProblemsDetailsModel
            {
                Name = y.Name,
                Problems = y.Submissions.Select(s => new ProblemModel
                {
                    Username = s.User.Username,
                    CreatedOn = s.CreatedOn.ToShortDateString(),
                    AchievedResult = s.AchievedResult,
                    MaxPoints = y.Points,
                    SubmissionId = s.Id,
                })
            }).FirstOrDefault();

            return model;
        }
    }
}
