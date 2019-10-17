namespace _10._Crossroads
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var secondOfGreenLight = int.Parse(Console.ReadLine());
            var durationOfFreeWindow = int.Parse(Console.ReadLine());
            var cars = new Queue<string>();
            var carsPassed = 0;

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                else if (input == "green")
                {
                    string lastCar = string.Empty;
                    var secondsLeft = secondOfGreenLight;
                    if (cars.Count > 0)
                    {
                        var currentCar = cars.Peek();

                        while (true)
                        {
                            if (secondsLeft == 0)
                            {
                                break;
                            }

                            if (cars.Count > 0)
                            {
                                currentCar = cars.Peek();
                                if (currentCar.Length <= secondOfGreenLight)
                                {
                                    lastCar = cars.Dequeue();
                                    if (secondsLeft - currentCar.Length < 0)
                                    {
                                        currentCar = currentCar.Remove(0, secondsLeft);
                                        secondsLeft = 0;
                                    }
                                    else
                                    {
                                        secondsLeft -= currentCar.Length;
                                        currentCar = currentCar.Remove(0, currentCar.Length);
                                    }
                                    
                                    if (currentCar.Length == 0)
                                    {
                                        carsPassed++;
                                        
                                    }
                                }
                                else
                                {
                                    lastCar = cars.Dequeue();
                                    currentCar = currentCar.Remove(0, secondsLeft);
                                    secondsLeft -= currentCar.Length;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (currentCar.Length > 0)
                        {
                            if (currentCar.Length > durationOfFreeWindow)
                            {
                                currentCar = currentCar.Remove(0, durationOfFreeWindow);
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{lastCar} was hit at {currentCar[0]}.");
                                return;
                            }
                            else
                            {
                                carsPassed++;
                            }
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}
