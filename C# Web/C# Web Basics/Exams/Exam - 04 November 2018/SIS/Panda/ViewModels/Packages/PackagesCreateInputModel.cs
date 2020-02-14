namespace Panda.ViewModels.Packages
{
    public class PackagesCreateInputModel
    {
        public string Description { get; set; }

        public decimal Weight { get; set; }

        public string ShippingAddress { get; set; }

        public string RecipientName { get; set; }
    }
}
