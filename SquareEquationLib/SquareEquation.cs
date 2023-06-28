namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double eps = 1e-6;

        if ((a > -eps && a < eps) || double.IsNaN(a) || double.IsNaN(b) || double.IsNaN(c) || double.IsInfinity(a) || double.IsInfinity(b) || double.IsInfinity(c))
        {
            throw new System.ArgumentException("Invalid Values");
        }
        b = b / a;
        c = c / a;

        double d = b * b - 4 * c;
        double[] answerZero = new double[] { };
        double[] answerOne = new double[1];
        double[] answerTwo = new double[2];

        if (d <= -eps)
        {
            return answerZero;
        }
        else if (-eps < d & d < eps)
        {
            double x1 = -(b) / 2;
            answerOne[0] = x1;
            return answerOne;
        }
        else
        {
            double x1 = -(b + Math.Sign(b) * Math.Sqrt(d)) / 2;
            double x2 = c / x1;
            answerTwo[0] = x1;
            answerTwo[1] = x2;
            return answerTwo;
        }

    }
}
