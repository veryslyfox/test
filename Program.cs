#pragma warning disable
global using System.Linq;
using static System.Console;
using static StrangeSymbolCollection;
delegate TResult FuncOut<TValue, TResult, TOut>(TValue value, out TOut result);
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
        try
        {
            
        }
        catch (Exception exception) { Console.Error.WriteLine(exception.GetExceptionValue()); }
        finally { Console.ReadKey(); }
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
        return exception.InnerException == null ? exception : exception.InnerException.GetExceptionValue();
    }
    public static Exception[] GetExceptionChain(this Exception exception)
    {
        var exceptions = new List<Exception>();
        var currentException = exception;
        if (currentException.InnerException != null)
        {
            currentException = currentException.InnerException;
            exceptions.Add(currentException);
        }
        return exceptions.ToArray();
    }
}