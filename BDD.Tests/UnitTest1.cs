namespace BDD.Tests;
using SquareEquationLib;
using TechTalk.SpecFlow;
using System;

[Binding]
public class UnitTest1
{
    [Binding]
    public class SquareEquationSteps
    {
        private double[] coefficients = new double[3];
        private double[]? roots;
        private Exception exception = new();
        private double precision = 0.001;


       

        [Given(@" вадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
        public void GivenCofficients(string p0, string p1, string p2)
        {
            double _p0 = double.Parse(p0, System.Globalization.CultureInfo.InvariantCulture);
            double _p1 = double.Parse(p1, System.Globalization.CultureInfo.InvariantCulture);
            double _p2 = double.Parse(p2, System.Globalization.CultureInfo.InvariantCulture);

            coefficients = new double[] { _p0, _p1, _p2 };
        }

        [When(@"вычисл€ютс€ корни квадратного уравнени€")]
        public void WhenSolveRoots()
        {
            try
            {
                roots = new double[3];
                roots = SquareEquation.Solve(coefficients[0], coefficients[1], coefficients[2]);
            }
            catch (ArgumentException ex)
            {
                exception = ex;
            }
        }

        [Then(@"квадратное уравнение имеет два корн€ \((.*), (.*)\) кратности один")]
        public void ThenTwoRoots(double root1, double root2)
        {
            Assert.Equal(root1, roots[0], precision);
            Assert.Equal(root2, roots[1], precision);
        }

        [Then(@"квадратное уравнение имеет один корень (.*) кратности два")]
        public void ThenOneRoots(double root)
        {
            Assert.Equal(root, roots[0], precision);
        }

        [Then(@"множество корней квадратного уравнени€ пустое")]
        public void ThenZeroRoots()
        {
            Assert.Empty(roots);
        }

        [Then(@"выбрасываетс€ исключение ArgumentException")]
        public void Then¬ыбрасываетс€»сключениеArgumentException()
        {
            Assert.Equal("Invalid Values", exception.Message);
        }

        
    }
}
