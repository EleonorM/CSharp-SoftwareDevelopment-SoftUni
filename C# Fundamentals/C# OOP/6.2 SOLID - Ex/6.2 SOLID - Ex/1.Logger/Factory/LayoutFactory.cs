namespace _1.Logger.Factory
{
    using _1.Logger.Models.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class LayoutFactory
    {
        public ILayout GetLayout(string type)
        {
            var typeToCreate = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(c => c.Name == type);
            if (typeToCreate == null)
            {
                throw new InvalidOperationException();
            }

            ILayout layout = (ILayout)Activator.CreateInstance(typeToCreate);
            return layout;
        }
    }
}
