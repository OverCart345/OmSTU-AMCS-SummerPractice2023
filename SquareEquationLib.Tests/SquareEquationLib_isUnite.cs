using Xunit;
using SquareEquationLib;

namespace SquareEquationLib.Tests;

public class SquareEquationLib_isUnite
{
    [Fact]
    public void Solve_ReturnsTwoRoots()
    {
        double[] expected = new double[] { -3, 2 };
        double[] actual = SquareEquation.Solve(1, 1, -6);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Solve_ReturnsOneRoots()
    {
        double[] expected = new double[] { 4 };
        double[] actual = SquareEquation.Solve(1, -8, 16);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Solve_ReturnsEmpty()
    {
        double[] expected = new double[] { };
        double[] actual = SquareEquation.Solve(2, 1, 4);

        Assert.Equal(expected, actual);
    }



    [Fact]
    public void Solve_ThrowsArgumentException()
    {
        Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(0, 2, 3));
    }

    [Theory]
    [InlineData(double.NaN, 2, 3)]
    [InlineData(1, double.PositiveInfinity, 3)]
    [InlineData(1, 2, double.NegativeInfinity)]
    public void Solve_InvalidCoefficients(double a, double b, double c)
    {
        Assert.Throws<System.ArgumentException>(() => SquareEquation.Solve(a, b, c));
    }
}