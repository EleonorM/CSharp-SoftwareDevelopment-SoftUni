namespace CommandDemo
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var modifyPrice = new ModifyPrice();
            var product = new Product("Apple", 5);

            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 2));
            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 1));
            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Decrease, 3));

            Console.WriteLine(product);
        }

        private static void Execute(Product product, ModifyPrice modifyPrice, ICommand productCommand)
        {
            modifyPrice.SetCommand(productCommand);
            modifyPrice.Invoke();
        }
    }
}
