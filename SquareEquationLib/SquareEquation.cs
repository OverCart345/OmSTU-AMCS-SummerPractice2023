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
        double[] answer = new double[2];

        if (d <= -eps)
        {
             return answer;
        }
        else if (-eps < d && d < eps) 
        {
            double x1 = -b / (2 * a);
            answer = new double[] { x1};
            return answer;
        }
        else
        {
            double x1 = (-b + Math.Sqrt(d)) / (2 * a);
            double x2 = (-b - Math.Sqrt(d)) / (2 * a);
            answer = new double[] { x1, x2 };
            return answer;
        }
        
    }
}
