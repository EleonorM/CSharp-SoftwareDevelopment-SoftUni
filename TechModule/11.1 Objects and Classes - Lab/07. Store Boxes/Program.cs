namespace _07.Store_Boxes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private class Item
        {
            public string Name { get; set; }

            public double Price { get; set; }
        }

        private class Box
        {
            public Box()
            {
                Item = new Item();
            }
            public string SerialNumber { get; set; }
            public Item Item { get; set; }
            public string ItemQuality { get; set; }
            public double PriceForABox { get; set; }
        }

        public static void Main()
        {
            List<Box> box = new List<Box>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                var item = input.Split().ToList();
                var serialNumber = item[0];
                var itemName = item[1];
                var itemQantity = item[2];
                string itemPrice = item[3];

                Box currentBox = new Box();
                Item currentItem = new Item();
                currentItem.Name = itemName;
                currentItem.Price = double.Parse(itemPrice);
                currentBox.Item = currentItem;
                currentBox.SerialNumber = serialNumber;
                currentBox.ItemQuality = itemQantity;
                var pricePerBox = double.Parse(itemQantity) * double.Parse(itemPrice);
                currentBox.PriceForABox = pricePerBox;
                box.Add(currentBox);
            }
            var newList = box.OrderBy(x => x.PriceForABox).ToList();
            box.OrderBy(x => x.PriceForABox);
            newList.Reverse();
            PrintBox(newList);
        }

        private static void PrintBox(List<Box> box)
        {
            for (int i = 0; i < box.Count; i++)
            {
                Box currentBox = new Box();
                Console.WriteLine(box[i].SerialNumber);
                Console.WriteLine($"-- {box[i].Item.Name} - ${box[i].Item.Price:f2}: {box[i].ItemQuality}");
                Console.WriteLine($"-- ${box[i].PriceForABox:f2}");
            }
        }
    }
}
