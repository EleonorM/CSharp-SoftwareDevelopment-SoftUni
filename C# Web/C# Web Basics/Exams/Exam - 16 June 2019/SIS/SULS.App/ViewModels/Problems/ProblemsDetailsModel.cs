namespace SULS.App.ViewModels.Problems
{
    using System.Collections.Generic;

    public class ProblemsDetailsModel
    {
        public string Name { get; set; }

        public IEnumerable<ProblemModel> Problems { get; set; }
    }
}
