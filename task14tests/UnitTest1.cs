namespace task14tests;

using task14;
using Xunit;


public class DefiniteIntegralTests
{
    [Fact]
    public void TestLinearFunction()
    {
        var X = (double x) => x;
        double result = DefiniteIntegral.Solve(-1, 1, X, 1e-4, 2);
        Assert.Equal(0, result, 1e-4);
    }

    [Fact]
    public void TestSinFunction()
    {
        var SIN = (double x) => Math.Sin(x);
        double result = DefiniteIntegral.Solve(-1, 1, SIN, 1e-5, 8);
        Assert.Equal(0, result, 1e-4);
    }

    [Fact]
    public void TestConstantFunction()
    {
        var CONST = (double x) => 5.0;
        double result = DefiniteIntegral.Solve(0, 2, CONST, 1e-4, 4);
        Assert.Equal(10, result, 1e-4);
    }

    [Fact]
    public void TestQuadraticFunction()
    {
        var X_SQUARED = (double x) => x * x;
        double result = DefiniteIntegral.Solve(0, 3, X_SQUARED, 1e-5, 6);
        Assert.Equal(9, result, 1e-3);
    }

    [Fact]
    public void TestExponentialFunction()
    {
        var EXP = (double x) => Math.Exp(x);
        double result = DefiniteIntegral.Solve(0, 1, EXP, 1e-5, 3);
        Assert.Equal(Math.E - 1, result, 1e-3);
    }
}
