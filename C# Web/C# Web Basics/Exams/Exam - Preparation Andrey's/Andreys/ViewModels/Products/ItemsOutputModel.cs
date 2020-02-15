namespace Andreys.ViewModels.Products
{
    using System.Collections.Generic;

    public class ItemsOutputModel
    {
        public ICollection<ItemModel> Items { get; set; } = new HashSet<ItemModel>();
    }
}
