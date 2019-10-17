namespace P05_GreedyTimes
{
    public class BagItem
    {
        public BagItem(string name, long amount)
        {
            Name = name;
            Amount = amount;
        }

        public string Name { get; set; }

        public long Amount { get; set; }

        public void IncreaseAmount(long number)
        {
            this.Amount += number;
        }

        public override string ToString()
        {
            return $"##{this.Name} - {this.Amount}".ToString();
        }
    }
}
