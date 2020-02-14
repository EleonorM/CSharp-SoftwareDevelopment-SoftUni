namespace Panda.ViewModels.Packages
{
    using System.Collections.Generic;

    public class PackagesPendingInputModel
    {
        public ICollection<PackageModel> Packages { get; set; } = new HashSet<PackageModel>();
    }
}
