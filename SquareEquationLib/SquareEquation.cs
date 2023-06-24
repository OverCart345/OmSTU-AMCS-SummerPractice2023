namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        if (a == 0 || double.IsNaN(a) || double.IsNaN(b) || double.IsNaN(c) || double.IsInfinity(a) || double.IsInfinity(b) || double.IsInfinity(c)) 
        {
            throw new System.ArgumentException();
        }

        double eps = Math.Pow(10, -9);
        double d = b * b - 4 * c;
        double[] answer = new double[2];

        if (Math.Abs(d) < eps)
        {
            double x1 = -b / (2 * a);
            double x2 = x1;
            answer = new double[] { x1, x2 };
            
        }
        else if (d == 0) 
        {
            double x1 = -b / (2 * a);
            answer = new double[] { x1};
            
        }
        else if (d < 0)
        {

        }
        else
        {
            double x1 = (-b + Math.Sqrt(d)) / (2 * a);
            double x2 = (-b - Math.Sqrt(d)) / (2 * a);
            answer = new double[] { x1, x2 };
            
        }
        return answer;
    }
}
