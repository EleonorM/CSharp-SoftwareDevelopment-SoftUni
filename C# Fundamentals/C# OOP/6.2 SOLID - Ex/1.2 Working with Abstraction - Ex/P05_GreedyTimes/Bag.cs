namespace P05_GreedyTimes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Bag
    {
        public Bag()
        {
            Golds = new List<Gold>();
            Gems = new List<Gem>();
            Cash = new List<Cash>();
        }

        public List<Gold> Golds { get; set; }

        public List<Gem> Gems { get; set; }

        public List<Cash> Cash { get; set; }

        public long Capacity { get => Golds.Sum(x => x.Amount) + Gems.Sum(x => x.Amount) + Cash.Sum(x => x.Amount); }


        public override string ToString()
        {
            var sb = new StringBuilder();
            if (Golds.Count != 0)
            {
                sb.AppendLine($"<{nameof(Gold)}> ${Golds.Sum(x => x.Amount)}");
                Golds = Golds.OrderByDescending(x => x.Name).ThenBy(y => y.Amount).ToList();
                foreach (var gold in Golds)
                {
                    sb.AppendLine(gold.ToString());
                }
            }
            if (Gems.Count != 0)
            {
                sb.AppendLine($"<Gem> ${Gems.Sum(x => x.Amount)}");
                Gems = Gems.OrderByDescending(x => x.Name).ThenBy(y => y.Amount).ToList();
                foreach (var gem in Gems)
                {
                    sb.AppendLine(gem.ToString());
                }
            }
            if (Cash.Count != 0)
            {
                sb.AppendLine($"<{nameof(Cash)}> ${Cash.Sum(x => x.Amount)}");
                Cash = Cash.OrderByDescending(x => x.Name).ThenBy(y => y.Amount).ToList();
                foreach (var cash in Cash)
                {
                    sb.AppendLine(cash.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
