namespace SULS.App.Services
{
    using SULS.App.ViewModels.Problems;

    public interface IProblemsService
    {
        void CreateProblem(string name, int points);

        ProblemsDetailsModel GetProblems(string id);

    }
}
