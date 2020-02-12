namespace SULS.App.Services
{
using SULS.App.ViewModels.Submissions;

    public interface ISubmissionsService
    {
        void CreateSubmission(string code, string userId, string problemId);

        SubmissionsViewModel GetProblem(string id);

        void DeleteSubmission(string id);
    }
}
