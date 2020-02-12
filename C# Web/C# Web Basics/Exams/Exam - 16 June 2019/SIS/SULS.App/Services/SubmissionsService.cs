using SULS.App.Models;
using SULS.App.ViewModels.Submissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SULS.App.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private Random random;
        private SulsDbContext db;

        public SubmissionsService(SulsDbContext db, Random random)
        {
            this.random = random;
            this.db = db;
        }

        public void CreateSubmission(string code, string userId, string problemId)
        {
            var problem = this.db.Problems.Find(problemId);
            var submission = new Submission()
            {
                Code = code,
                CreatedOn = DateTime.UtcNow,
                AchievedResult = random.Next(0, problem.Points + 1),
                ProblemId = problemId,
                UserId = userId,
            };
            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }
        public void DeleteSubmission(string id)
        {
            var submission = this.db.Submissions.Find(id);
            this.db.Submissions.Remove(submission);
            db.SaveChanges();
        }

        public SubmissionsViewModel GetProblem(string id)
        {
            return this.db.Problems.Where(x => x.Id == id).Select(x => new SubmissionsViewModel()
            {
                Name = x.Name,
                ProblemId = x.Id,
            }).FirstOrDefault();

        }
    }
}
