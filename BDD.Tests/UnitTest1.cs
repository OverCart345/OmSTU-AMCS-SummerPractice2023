namespace BDD.Tests;
using SquareEquationLib;
using TechTalk.SpecFlow;
using System;

[Binding]
public class SolveStepDefinitions
{
    private double[] array = new double[3];
    private double[]? result;
    Exception exception = new();
    private double precision = 0.0001;

    [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
    public void GivenCofficients(string p0, string p1, string p2)
    {
        double _p0 = double.Parse(p0, System.Globalization.CultureInfo.InvariantCulture);
        double _p1 = double.Parse(p1, System.Globalization.CultureInfo.InvariantCulture);
        double _p2 = double.Parse(p2, System.Globalization.CultureInfo.InvariantCulture);

        array = new double[] { _p0, _p1, _p2 };
    }

    [When(@"вычисляются корни квадратного уравнения")]
    public void WhenSolvingTheRoots()
    {
        try
        {
            result = SquareEquation.Solve(array[0], array[1], array[2]);
        }
        catch (ArgumentException ex)
        {
            exception = ex;
        }
    }

    [Then(@"квадратное уравнение имеет два корня \((.*), (.*)\) кратности один")]
    public void ThenHave2Solutions(double p0, double p1)
    {
        if (p0 == result[0] && p1 == result[1])
        {
            Assert.Equal(p0, result[0], precision);
            Assert.Equal(p1, result[1], precision);
        }
        else
        {
            Assert.Equal(p0, result[1], precision);
            Assert.Equal(p1, result[0], precision);
        }
    }

    [Then(@"квадратное уравнение имеет один корень (.*) кратности два")]
    public void ThenHave1Solutions(double p0)
    {
        Assert.Equal(p0, result[0], precision);
    }

    [Then(@"множество корней квадратного уравнения пустое")]
    public void ThenHaveNoSolutions()
    {
        Assert.Empty(result);
    }

    [Then(@"выбрасывается исключение ArgumentException")]
    public void ThenThrowArgumentException()
    {
        Assert.Equal("Invalid Values", exception.Message);
    }
}


