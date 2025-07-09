namespace task11tests;

using Xunit;
using task11;
using System;

public class TestCalculator
{
    [Fact]
    public void TestAdd()
    {
        var calculator = Calculator.Create();
        Assert.Equal(3, calculator.Add(1, 2));
    }

    [Fact]
    public void TestMinus()
    {
        var calculator = Calculator.Create();
        Assert.Equal(1, calculator.Minus(3, 2));
    }

    [Fact]
    public void TestMul()
    {
        var calculator = Calculator.Create();
        Assert.Equal(6, calculator.Mul(2, 3));
    }

    [Fact]
    public void TestDiv()
    {
        var calculator = Calculator.Create();
        Assert.Equal(2, calculator.Div(6, 3));
    }

    [Fact]
    public void TestDivByZero()
    {
        var calculator = Calculator.Create();
        Assert.Throws<DivideByZeroException>(() => calculator.Div(1, 0));
    }
}
