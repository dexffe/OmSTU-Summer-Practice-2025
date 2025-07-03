namespace MetadataReader;
using System;
using System.Reflection;
using task07;

public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Path to assembly is not specified.");
            return;
        } 
        Console.WriteLine($"Assembly: {args[0]}");
        Assembly assembly = Assembly.LoadFile(args[0]);

        foreach (Type type in assembly.GetTypes())
        {
            string className = type.Name;
            Console.WriteLine($"\nClass: {className}");

            ReflectionHelper.PrintTypeInfo(type);
            
            Console.WriteLine();
        }
    }
}
