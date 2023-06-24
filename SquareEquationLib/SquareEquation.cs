namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double eps = 1e-9;

        if ((a > -eps && a < eps) || double.IsNaN(a) || double.IsNaN(b) || double.IsNaN(c) || double.IsInfinity(a) || double.IsInfinity(b) || double.IsInfinity(c))
        {
            throw new System.ArgumentException();
        }


        double d = b * b - 4 * c;
        double[] answer_zero = new double[2];
        double[] answer_one = new double[1];
        double[] answer_two = new double[2];

        if (d <= -eps)
        {
            return answer_zero;
        }
        else if (-eps < d && d < eps)
        {
            double x1 = -b / (2 * a);
            answer_one[0] = x1;
            return answer_one;
        }
        else
        {
            double x1 = (-b + Math.Sqrt(d)) / (2 * a);
            double x2 = (-b - Math.Sqrt(d)) / (2 * a);
            answer_two[0] = x1;
            answer_two[1] = x2;
            return answer_two;
        }
        
    }
}
