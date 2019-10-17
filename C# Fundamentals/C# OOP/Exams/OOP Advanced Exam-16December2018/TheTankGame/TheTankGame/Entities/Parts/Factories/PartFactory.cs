using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TheTankGame.Entities.Parts.Contracts;
using TheTankGame.Entities.Parts.Factories.Contracts;

namespace TheTankGame.Entities.Parts.Factories
{
    public class PartFactory : IPartFactory
    {
        public IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter)
        {

            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(c => c.Name.StartsWith(partType));

            var part = (IPart)Activator.CreateInstance(type, model, weight, price, additionalParameter);

            //switch (partType)
            //{
            //    case "Arsenal":
            //        part = new ArsenalPart(model, weight, price, additionalParameter);
            //        break;
            //    case "Shell":
            //        part = new ShellPart(model, weight, price, additionalParameter);
            //        break;
            //    case "Endurance":
            //        part = new EndurancePart(model, weight, price, additionalParameter);
            //        break;
            //}

            return part;
        }
    }
}
