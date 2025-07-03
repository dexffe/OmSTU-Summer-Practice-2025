namespace task07;

using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Method)]
public sealed class DisplayNameAttribute : Attribute
{
    public string DisplayName { get; set; }
    public DisplayNameAttribute(string displayName) => DisplayName = displayName;
}


[AttributeUsage(AttributeTargets.Class)]
public sealed class VersionAttribute : Attribute
{
    public int Major { get; set; }
    public int Minor { get; set; }

    public VersionAttribute(int major, int minor) => (Major, Minor) = (major, minor);
}

[DisplayName("Пример класса")] [Version(1, 0)]
public class SampleClass
{
    [DisplayName("Числовое свойство")]
    public int Number { get; set; }

    [DisplayName("Тестовый метод")]
    public void TestMethod() { }
}


public static class ReflectionHelper
{
    public static void PrintTypeInfo(Type type)
    {
        if (type == null)
        {
            Console.WriteLine("Тип не указан.");
            return;
        }

        var nameAttribute = type.GetCustomAttribute<DisplayNameAttribute>();
        if (nameAttribute != null)
        {
            Console.WriteLine($"DisplayName: {nameAttribute.DisplayName}");
        }

        var versionAttribute = type.GetCustomAttribute<VersionAttribute>();
        if (versionAttribute != null)
        {
            Console.WriteLine($"Version: {versionAttribute.Major}.{versionAttribute.Minor}");
        }

        Console.Write("Methods:  ");
        foreach (var method in type.GetMethods())
        {
            if (method != null)
            {
                var methodDN = method.GetCustomAttribute<DisplayNameAttribute>();
                var DNforMethod = methodDN?.DisplayName;
                if (DNforMethod == null)
                {
                    DNforMethod = "no DN";
                }
                Console.Write($"{method.Name}  ");
            }
        }

        Console.WriteLine();

        Console.Write("Properties:  ");
        foreach (var property in type.GetProperties())
        {
            if (property != null)
            {
                var propertyDN = property.GetCustomAttribute<DisplayNameAttribute>();
                var DNforProperty = propertyDN?.DisplayName;
                if (DNforProperty == null)
                {
                    DNforProperty = "no DN";
                }
                Console.Write($"{property.Name}  ");
            }
        }

        Console.WriteLine();

        Console.Write("Constructors:  ");
        foreach (var constructor in type.GetConstructors())
        {
            if (constructor != null)
            {
                Console.Write($"{constructor.Name}  ");
            }
        }
    }
}
