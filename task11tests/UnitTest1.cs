namespace task11tests;

using Xunit;
using task11;
using System;
using System.Collections.Generic;

public class TestCalculator
{

    [Fact]
    public void AddTest()
    {
        var calculator = Calculator.Main();

        var result = calculator?.Add(5, 35);
        Assert.Equal(40, result);
    }

    [Fact]
    public void MinusTest()
    {
        var calculator = Calculator.Main();

        var result = calculator?.Minus(4, 4);
        Assert.Equal(0, result);
    }

    [Fact]
    public void MulTest()
    {
        var calculator = Calculator.Main();

        var result = calculator?.Mul(3, 4);
        Assert.Equal(12, result);
    }

    [Fact]
    public void DivTest()
    {
        var calculator = Calculator.Main();

        var result = calculator?.Div(30, 3);
        Assert.Equal(10, result);
    }
}
