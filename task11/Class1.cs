using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace task11
{
    public interface ICalculator
    {
        int Add(int a, int b);
        int Minus(int a, int b);
        int Mul(int a, int b);
        int Div(int a, int b);
    }

    public class Calculator
    {
        public static ICalculator? Main()
        {
            string strCode = @"
                    public class Calculator
                    {
                        public int Add(int a, int b) => a + b;
                        public int Minus(int a, int b) => a - b;
                        public int Mul(int a, int b) => a * b;
                        public int Div(int a, int b) => a / b;
                    }";

            var provider = new CSharpCodeProvider();

            var parameters = new CompilerParameters
            {
                GenerateInMemory = true,
                GenerateExecutable = false
            };

            parameters.ReferencedAssemblies.Add(typeof(ICalculator).Assembly.Location);

            var res = provider.CompileAssemblyFromSource(parameters, strCode);

            var calcType = res.CompiledAssembly.GetType("Calculator");
            if (calcType != null)
            {
                var calculator = (ICalculator?)Activator.CreateInstance(calcType);
                return calculator;
            }

            return null;
        }
    }
}
