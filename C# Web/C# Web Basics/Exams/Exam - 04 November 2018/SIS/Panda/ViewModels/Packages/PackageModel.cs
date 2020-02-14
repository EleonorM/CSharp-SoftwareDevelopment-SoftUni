namespace Panda.ViewModels.Packages
{
    public class PackageModel
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public decimal Weight { get; set; }

        public string ShippingAddress { get; set; }

        public string RecipientName { get; set; }
    }
}
