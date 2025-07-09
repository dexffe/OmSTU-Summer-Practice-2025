namespace task11tests;

using Xunit;
using task11;
using System;
using System.Collections.Generic;

public class TestCalculator
{
    [Fact]
    public void TestAdd()
    {
        var calculator = Calculator.Main();
        Assert.Equal(3, calculator.Add(1, 2));
    }
}
