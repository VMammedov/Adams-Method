using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adams
{
    class Program
    {
        double F(double x, double y)
        {
            return y - x * x + 1.0;
        }

        void rungekutta(double x, double x0, double h, ref double[] Y)
        {
            for (int i = 1; i <= 4; i++)
            {
                double K1 = h * F(x, Y[i - 1]);
                double K2 = h * F(x + h / 2.0, Y[i - 1] + K1 / 2.0);
                double K3 = h * F(x + h / 2.0, Y[i - 1] + K2 / 2.0);
                double K4 = h * F(x + h, Y[i - 1] + K3);

                Y[i] = Y[i - 1] + 1 / 6.0 * (K1 + 2.0 * K2 + 2.0 * K3 + K4);
                x = x0 + i * h;
                Console.WriteLine("{0} noqtesinde Y{1} : {2}", x, i, Y[i]);
            }
        }
        void adams(int n, double x, double x0, double y0, ref double[] Y, double h)
        {
            for (int i = 4; i <= n; i++)
            {
                double K = 55.0 * F(x, Y[i - 1]) - 59.0 * F(x - h, Y[i - 2]) + 37.0 * F(x - 2.0 * h, Y[i - 3]) - 9.0 * F(x - 3.0 * h, Y[i - 4]);
                Y[i] = Y[i - 1] + h / 24.0 * K;

                x = x0 + i * h;
                Console.WriteLine("{0} noqtesinde Y{1} : {2}", x, i, Y[i]);
            }

        }
        static void Main(string[] args)
        {
            Console.Write("x0 : ");
            double x0 = double.Parse(Console.ReadLine());
            Console.Write("y0 : ");
            double y0 = double.Parse(Console.ReadLine());
            double x = x0;
            Console.Write("n : ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("h : ");
            double h = double.Parse(Console.ReadLine());
            double[] Y = new double[20];
            Console.Write("Y[0] : ");
            Y[0] = double.Parse(Console.ReadLine());
            Program a = new Program();
            a.rungekutta(x, x0, h, ref Y);
            a.adams(n, x, x0, y0, ref Y, h);
            Console.ReadKey();
        }
    }
}
