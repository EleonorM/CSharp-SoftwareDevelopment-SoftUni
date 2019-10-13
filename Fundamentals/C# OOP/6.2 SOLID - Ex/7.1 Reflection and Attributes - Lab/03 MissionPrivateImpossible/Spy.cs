using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldsNames)
    {
        Type type = Type.GetType($"{className}");
        var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        var sb = new StringBuilder();
        var classInstance = Activator.CreateInstance(type, new object[] { });

        sb.AppendLine($"Class under investigation: {className}");

        foreach (FieldInfo field in fields.Where(f => fieldsNames.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().TrimEnd();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        var sb = new StringBuilder();
        Type type = Type.GetType($"{className}");
        var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        var classPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        var classNonPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (var field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var info in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{info.Name} have to be public!");
        }

        foreach (var info in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{info.Name} have to be private!");
        }


        return sb.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {
        var sb = new StringBuilder();
        Type type = Type.GetType(className);
        var classNonPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {type.BaseType.Name}");
        foreach (var info in classNonPublicMethods)
        {
            sb.AppendLine(info.Name);
        }

        return sb.ToString().TrimEnd();
    }
}
