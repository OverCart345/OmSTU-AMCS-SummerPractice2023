namespace BDD.Tests;

public class UnitTest1
{
    [Fact]
    public void Solve_ReturnsTwoRoots()
    {
        double[] expected = new double[] { -3, 2 };
        double[] actual = UnitTest1.Solve(1, 1, -6);

        double precision = 0.001;
        Assert.Equal(expected.Length, actual.Length);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], actual[i], precision);
        }
    }

    [Fact]
    public void Solve_ReturnsOneRoots()
    {
        double[] expected = new double[] { 4 };
        double[] actual = UnitTest1.Solve(1, -8, 16);

        double precision = 0.001;
        Assert.Equal(expected.Length, actual.Length);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], actual[i], precision);
        }
    }

    [Fact]
    public void Solve_ReturnsEmpty()
    {
        double[] actual = UnitTest1.Solve(2, 1, 4);

        Assert.Empty(actual);
    }



    [Fact]
    public void Solve_ThrowsArgumentException()
    {
        Assert.Throws<System.ArgumentException>(() => UnitTest1.Solve(0, 2, 3));
    }

    [Theory]
    [InlineData(double.NaN, 2, 3)]
    [InlineData(1, double.PositiveInfinity, 3)]
    [InlineData(1, 2, double.NegativeInfinity)]
    public void Solve_InvalidCoefficients(double a, double b, double c)
    {
        Assert.Throws<System.ArgumentException>(() => UnitTest1.Solve(a, b, c));
    }
}