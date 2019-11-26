namespace CommandDemo
{
    public class ProductCommand : ICommand
    {
        private readonly Product product;
        private readonly PriceAction priceAction;
        private readonly int amount;

        public ProductCommand(Product product, PriceAction priceAction, int amount)
        {
            this.product = product;
            this.priceAction = priceAction;
            this.amount = amount;
        }

        public void ExecuteAction()
        {
            if (this.priceAction == PriceAction.Increase)
            {
                product.IncreasePrice(amount);
            }
            else if (this.priceAction == PriceAction.Decrease)
            {
                product.DecreasePrice(amount);
            }
        }
    }
}
