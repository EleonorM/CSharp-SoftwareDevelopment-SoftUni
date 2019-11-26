namespace FacadeDemo
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var car = new CarBuilderFacade()
                .Info
                .WithType("Honda")
                .WithColor("Red")
                .WithNumberOfDoors(4)
                .AddressBulid
                .InCity("Sofia")
                .AtAddress("ul. 1va")
                .Build();
            Console.WriteLine(car);
        }
    }
}
