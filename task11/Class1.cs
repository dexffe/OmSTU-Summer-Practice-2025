namespace task11;

using System;
using System.IO;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

public interface ICalculator
{
    int Add(int a, int b);
    int Minus(int a, int b);
    int Mul(int a, int b);
    int Div(int a, int b);
}

public class Calculator
{
    public static ICalculator Main()
    {
        string calculatorCode = @"public class Calculator : ICalculator
                                {
                                    public int Add(int a, int b) => a + b;
                                    public int Minus(int a, int b) => a - b;
                                    public int Mul(int a, int b) => a * b;
                                    public int Div(int a, int b) => a / b;
                                }";

        var syntaxTree = CSharpSyntaxTree.ParseText(calculatorCode);

        var refs = new[]
        {
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(ICalculator).Assembly.Location)
        };

        var compilation = CSharpCompilation.Create("CalculatorAssembly", new[] { syntaxTree }, refs,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        using var ms = new MemoryStream();
        var emitResult = compilation.Emit(ms);

        ms.Seek(0, SeekOrigin.Begin);

        var assembly = Assembly.Load(ms.ToArray());

        var calcType = assembly.GetType("Calculator");

        return (ICalculator)Activator.CreateInstance(calcType);
    }
}
