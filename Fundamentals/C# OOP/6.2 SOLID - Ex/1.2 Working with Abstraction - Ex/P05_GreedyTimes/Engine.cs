namespace P05_GreedyTimes
{
    using System;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
            long capacity = long.Parse(Console.ReadLine());
            string[] safe = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Bag();

            for (int i = 0; i < safe.Length; i += 2)
            {
                string name = safe[i];
                long count = long.Parse(safe[i + 1]);

                string bagItem = string.Empty;

                if (name.Length == 3)
                {
                    bagItem = "Cash";
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    bagItem = "Gems";
                }
                else if (name.ToLower() == "gold")
                {
                    bagItem = "Golds";
                }

                if (bagItem == string.Empty)
                {
                    continue;
                }
                else if (capacity < bag.Capacity + count)
                {
                    continue;
                }

                switch (bagItem)
                {
                    case "Gems":
                        if (bag.Gems.Count == 0)
                        {
                            if (bag.Golds.Count != 0)
                            {
                                if (count <= bag.Golds.Sum(x => x.Amount))
                                {
                                    if (bag.Gems.FirstOrDefault(x => x.Name == name) == null)
                                    {
                                        bag.Gems.Add(new Gem(name, count));
                                    }
                                    else
                                    {
                                        bag.Gems.FirstOrDefault(x => x.Name == name).IncreaseAmount(count);
                                    }

                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag.Gems.Sum(x => x.Amount) + count <= bag.Golds.Sum(x => x.Amount))
                        {
                            if (bag.Gems.FirstOrDefault(x => x.Name == name) == null)
                            {
                                bag.Gems.Add(new Gem(name, count));
                            }
                            else
                            {
                                bag.Gems.FirstOrDefault(x => x.Name == name).IncreaseAmount(count);
                            }

                            continue;
                        }

                        break;
                    case "Cash":
                        if (bag.Cash.Count == 0)
                        {
                            if (bag.Gems.Count != 0)
                            {
                                //count <=
                                if (count <= bag.Gems.Sum(x => x.Amount))
                                {
                                    if (bag.Cash.FirstOrDefault(x => x.Name == name) == null)
                                    {
                                        bag.Cash.Add(new Cash(name, count));
                                    }
                                    else
                                    {
                                        bag.Cash.FirstOrDefault(x => x.Name == name).IncreaseAmount(count);
                                    }

                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag.Cash.Sum(x => x.Amount) + count <= bag.Gems.Sum(x => x.Amount))
                        {
                            if (bag.Cash.FirstOrDefault(x => x.Name == name) == null)
                            {
                                bag.Cash.Add(new Cash(name, count));
                            }
                            else
                            {
                                bag.Cash.FirstOrDefault(x => x.Name == name).IncreaseAmount(count);
                            }

                            continue;
                        }

                        break;
                    case "Golds":
                        if (bag.Golds.FirstOrDefault(x => x.Name == name) != null)
                        {
                            bag.Golds.FirstOrDefault(x => x.Name == name).IncreaseAmount(count);
                        }
                        else
                        {
                            bag.Golds.Add(new Gold(name, count));
                        }

                        break;
                }
            }

            Console.WriteLine(bag);
        }
    }
}
