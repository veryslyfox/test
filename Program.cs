#pragma warning disable
global using System.Linq;
global using System.Diagnostics;
using static System.Console;
using static StrangeSymbolCollection;
using static FactorialOperations;
using System.Numerics;
/*323170060713110073007148766886699519604441026697
1548403213034542752465513886789089319720141152291346368871796092
189801949411955915049092109508815238644828312063
0877367300996091750197750389652106796057638384067568276792218642619
75616183809433847617047058164585203630504288757589154106580860755239912393
03855219143333896683424206849747865645694948561760353263220580778056593
310261927084603141502585928641771167259436037184618573575
98351152301645904403697613233287231227125684710820209
7251571017269313234696785425806566979350459972683529986382
15525166389437335543602135433229604645318478604952148193555853611059596230656*/
static partial class Program
{
    static void Main()
    {
        
    }

    private static void Factorization(int arg)
    {
        
        Console.Write(arg.ToString() + " = ");
        var d = 2;
        A:;
            if (arg == 1)
            {
                goto B;
            }
            if (arg % d == 0)
            {
                arg = arg / d;
                Console.Write(d);
                if (arg != 1)
                {
                    Console.Write(" * ");
                }
            }
            else
            {
                d++;
            }
            goto A;
        B:;
    }

    private static void BigNumbersPrint(int a, int b)
    {
        BigInteger p = a;
        BigInteger q = p;
        BigInteger r = q;
        BigInteger t = r;
        BigInteger n = t;
        BigInteger k = n;
        BigInteger c = k;
        BigInteger m = c;
        BigInteger l = m;
        BigInteger j = l;
        BigInteger s = j;
        for (int i = 0; i < b; i++)
        {
            (p, q, r, t, n, k, c, m, j, s)
             = (p * j / 2 + q + r * l * 3 + t * n + k * k * c + m * q * l, p * j * s * 3 + q
            / 2 + r + t + n * p * m + k * c * 3 + l * p * s,
             p * j + q * r + t * 2 + n / 2 + k * s, p + q * s + r * s * s + t * n * c * 4 + k,
              n * q * m * 2 + p * r + t * k * c,
             p + q * q + r * r * r * c + t * t + n * m + l * l / 2 + k * k *
             k / 3, c * c * m, p * q * r + t * c * n + k * k * m + l * q * j + s * p * q,
              j * j + p * c, s * s + q + r + p * j * c + t * t * q);
            Console.WriteLine(p);
        }
    }
    static void Test(out TimeSpan span)
    {
        var counter = 0;
        var stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < 1000; i++)
        {
            counter++;
            WriteLine(counter);
            SetCursorPosition(0, 0);
        }
        span = stopwatch.Elapsed;
    }
    static BigInteger CollatzConvert(BigInteger integer)
    {
        var a = integer % 2 == 0;
        if (a)
        {
            return integer / 2;
        }
        else
        {
            return 3 * integer + 1;
        }
    }
    static BigInteger GetBig(int n)
    {
        if (n == 0)
        {
            return 7;
        }
        return (GetBig(n - 1) << 17) + MathHigh.Pow(GetBig(n - 1), 17);
    }
    static void MathFocus3()
    {
        Console.WriteLine("я угадаю ваш день рождения");
        Console.WriteLine("умножьте на 12 дату, и прибавьте умноженный на 31 месяц, и введите результат");
        var key = Console.ReadLine();
        if (short.TryParse(key, out var parse) && parse <= 744)
        {
            int month;
            var nr = (7 * (parse % 12)) % 12;
            if (nr != 0)
            {
                month = nr;
            }
            else
            {
                month = 12;
            }
        }
    }
    public static Exception GetExceptionValue(this Exception exception)
    {
        return exception.InnerException?.GetExceptionValue() ?? exception;
    }
    public static IReadOnlyList<Exception> GetExceptionChain(this Exception exception)
    {
        var exceptions = new List<Exception>();
        var currentException = exception;
        if (currentException.InnerException != null)
        {
            currentException = currentException.InnerException;
            exceptions.Add(currentException);
        }
        return exceptions;
    }
}
/*(3) nose = 3 head = 3 (2)
(2, 2) nose = 2 head = 2, 2
(2, 1)
(2, 1, 2, 1, 2, 1) nose = 1 head = 1
(0)
*4(2, 1, 2, 1, 2, 0, 0, 0, 0)
*5(2, 1, 2, 1, 2, 0, 0, 0)           
*6(2, 1, 2, 1, 2, 0, 0)
*7(2, 1, 2, 1, 2, 0)
*8(2, 1, 2, 1, 2) nose = 2 head = 2
*9(2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1) nose = 1 head = 1, 1, 1, 1, 1, 1, 1, 1
(2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0)
*11
(2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1)
*12
(2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0)
*13
(2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1)
*14
(2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 1, 0, 2, 1, 2, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0)
^*/