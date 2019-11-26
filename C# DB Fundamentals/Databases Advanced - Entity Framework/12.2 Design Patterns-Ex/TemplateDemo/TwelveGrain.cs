namespace TemplateDemo
{
    using System;

    public class TwelveGrain : Bread
    {
        public override void MixIngradients()
        {
            Console.WriteLine("Gathering Ingredients for 12-Grain Bread.");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the 12-Grain Bread. (25 minutes)");
        }
    }
}
