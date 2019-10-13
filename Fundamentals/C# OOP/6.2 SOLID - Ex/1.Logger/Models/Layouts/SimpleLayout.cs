namespace _1.Logger.Models.Layouts
{
    using _1.Logger.Models.Contracts;

    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}