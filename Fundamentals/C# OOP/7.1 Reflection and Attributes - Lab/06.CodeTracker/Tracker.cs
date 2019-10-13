using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public  void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);
        var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
        foreach (var method in methods)
        {
            if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
            {
                var attriutes = method.GetCustomAttributes(false);
                foreach (AuthorAttribute atrr in attriutes)
                {
                   Console.WriteLine($"{method.Name} is written by {atrr.Name}");
                }

            }
        }
    }
}
