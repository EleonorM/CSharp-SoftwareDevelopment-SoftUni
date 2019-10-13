using System;

namespace _07._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalMoney = 0.00;
            var input = Console.ReadLine();
            while (input != "Start")
            {
                double money = double.Parse(input);
                if (money != 2 ^ money != 1 ^ money != 0.5 ^ money != 0.2 ^ money != 0.1)
                {
                    Console.WriteLine($"Cannot accept {money}");
                }
                else
                {
                    totalMoney += money;
                }

                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "End")
            {
                if (input == "Nuts")
                {
                    if (totalMoney >= 2)
                    {
                        totalMoney -= 2;
                        Console.WriteLine("Purchased nuts");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                       
                    }
                }
                else if (input == "Soda")
                {
                    if (totalMoney >= 0.8)
                    {
                        totalMoney -= 0.8;
                        Console.WriteLine("Purchased soda");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                        
                    }
                }
                else if (input == "Water")
                {
                    if (totalMoney >= 0.7)
                    {
                        totalMoney -= 0.7;
                        Console.WriteLine("Purchased water");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                       
                    }
                }
                else if (input == "Coke")
                {
                    
                    if (totalMoney >= 1)
                    {
                        totalMoney -= 1;
                        Console.WriteLine("Purchased coke");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                        
                    }
                }
                else if (input == "Crisps")
                {
                    
                    if (totalMoney >= 1.5)
                    {
                        totalMoney -= 1.5;
                        Console.WriteLine("Purchased crisps");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                        
                    }
                }
                else
                {
                    Console.WriteLine("Invalid product");
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Change: {totalMoney:f2}");

        }
    }
}
