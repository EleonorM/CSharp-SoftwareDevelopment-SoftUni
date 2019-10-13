namespace _03.WildFarm
{
    using System;
    using System.Collections.Generic;

    public class startUp
    {
        public static void Main()
        {
            var animals = new List<Animal>();
            while (true)
            {
                var inputAnimal = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (inputAnimal[0] == "End")
                {
                    break;
                }

                Animal animal;

                animal = CreateAnimal(inputAnimal);
                Console.WriteLine(animal.ProduceASound());
                animals.Add(animal);

                var inputFood = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var foodType = inputFood[0];
                var foodQuantity = int.Parse(inputFood[1]);
                if (animal is Hen)
                {
                    animal.EatFood(foodQuantity);
                }
                else if (animal is Mouse && (foodType == "Vegetable" || foodType == "Fruit"))
                {
                    animal.EatFood(foodQuantity);
                }
                else if (animal is Cat && (foodType == "Vegetable" || foodType == "Meat"))
                {
                    animal.EatFood(foodQuantity);
                }
                else if ((animal is Dog || animal is Tiger || animal is Owl) && foodType == "Meat")
                {
                    animal.EatFood(foodQuantity);
                }
                else
                {
                    Console.WriteLine($"{animal.GetType().Name} does not eat {foodType}!");
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        private static Animal CreateAnimal(string[] inputAnimal)
        {
            var typeAnimal = inputAnimal[0];
            var nameAnimal = inputAnimal[1];
            var weightAnimal = double.Parse(inputAnimal[2]);
            string livingRegion;
            double wingSize;
            string breed;
            Animal animal;
            switch (typeAnimal)
            {
                case "Mouse":
                    livingRegion = inputAnimal[3];
                    animal = new Mouse(nameAnimal, weightAnimal, livingRegion);
                    break;
                case "Dog":
                    livingRegion = inputAnimal[3];
                    animal = new Dog(nameAnimal, weightAnimal, livingRegion);
                    break;
                case "Cat":
                    livingRegion = inputAnimal[3];
                    breed = inputAnimal[4];
                    animal = new Cat(nameAnimal, weightAnimal, livingRegion, breed);
                    break;
                case "Tiger":
                    livingRegion = inputAnimal[3];
                    breed = inputAnimal[4];
                    animal = new Tiger(nameAnimal, weightAnimal, livingRegion, breed);
                    break;
                case "Owl":
                    wingSize = double.Parse(inputAnimal[3]);
                    animal = new Owl(nameAnimal, weightAnimal, wingSize);
                    break;
                case "Hen":
                    wingSize = double.Parse(inputAnimal[3]);
                    animal = new Hen(nameAnimal, weightAnimal, wingSize);
                    break;
                default:
                    throw new InvalidOperationException("There is no animal of that type!");
            }

            return animal;
        }
    }
}
