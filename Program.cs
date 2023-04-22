using static System.Math;
static partial class Program
{
    static Random _rng = new Random();
    static void Main()
    {
        try
        {
            var p = 0.0;
            var q = 0.0;
            var pBest = 0.0;
            var qBest = 0.0;
            var err = 0.0;
            var err1 = 0.0;
            var err2 = 0.0;
            var err3 = 0.0;
            var err4 = 0.0;
            var d = 0.01;
            double F(double p, double q)
            {
                return Abs(3 - p - 2 * q) + Abs(5 - 2 * p - 3 * q) + Abs(6 - 3 * p - 3 * q) + Abs(1 - p) + Abs(1 - q);
            }
            for (int c = 0; c < 10; c++)
            {
                p = _rng.Next(101) / 100;
                q = _rng.Next(101) / 100;
                for (int i = 0; i < 10000; i++)
                {
                    err = F(p, q);
                    err1 = F(p + d, q);
                    err2 = F(p, q + d);
                    err3 = F(p - d, q);
                    err4 = F(p, q - d);
                    if (err > Max(err1, Max(err2, Max(err3, err4))))
                    {
                        pBest = Max(p, pBest);
                        qBest = Max(q, qBest);
                        break;
                    }

                    var values = new double[] { err1, err2, err3, err4 };
                    switch (Array.IndexOf(values, values.Min()))
                    {
                        case 0:
                            p += d;
                            break;
                        case 1:
                            q += d;
                            break;
                        case 2:
                            p -= d;
                            break;
                        case 3:
                            q -= d;
                            break;
                    }
                }
            }
            var error = 0.0;
            for (int i = 0; i < 50; i++)
            {
                var a = _rng.Next(10);
                var b = _rng.Next(10);
                Console.WriteLine($"{a} + {b} = {(a * p + b * q)}");
                error += (a * p + b * q) - Floor(a * p + b * q);
            }
            Console.WriteLine(Log10(error / 50));
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine(exception);
        }
        finally
        {
            Console.ReadKey();
        }
    }
}
