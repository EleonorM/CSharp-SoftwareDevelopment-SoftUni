namespace TemplateDemo
{
    using System;

    public class Sourdough : Bread
    {
        public override void MixIngradients()
        {
            Console.WriteLine("Gathering Ingredients for Sourdough Bread.");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the Sourdough Bread. (20 minutes)");
        }
    }
}
