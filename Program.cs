#pragma warning disable
global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Reflection;
using System.Security.Cryptography;
using System.Diagnostics;
using Animals;
using System.Dynamic;
using Graphic;
using System.Threading;
using System.Text;
using System.Net.Sockets;
using System.Collections.Generic;
using MyMath;
using System.Security.Cryptography.X509Certificates;
using System.Linq.Expressions;
using System.Globalization;
using System.Runtime.Serialization;
using System.Desecurity;
using System.Buffers.Binary;
using System.Xml;
using System.Runtime.CompilerServices;
using System.Collections;

delegate TResult FuncOut<TValue, TResult, TOut>(TValue value, out TOut result);
class OrderedEnumerable : IOrderedEnumerable<int>
{
    public IOrderedEnumerable<int> CreateOrderedEnumerable<TKey>(Func<int, TKey> keySelector, IComparer<TKey>? comparer, bool descending)
    {
        return this;
    }

    public IEnumerator<int> GetEnumerator()
    {
        yield break;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
static partial class Program
{
    static void Main()
    {
        try
        {
            CipherStream stream = new CipherStream();
            stream.Hammation(23, 0);
            var bigInteger = MathHigh.Pow(long.MaxValue, long.MaxValue);
            Console.WriteLine(bigInteger);
            var values = new byte[] { };
            var array = new[] { 7, 11, 3993, 413, 3, 1, 6, 99, 233, 74 };
            var max = array[0];
            var comparisons = 0;
            var secondMax = max;
            for (var i = 1; i < array.Length; ++i)
            {
                var v = array[i];
                ++comparisons;
                if (max < v)
                {
                    secondMax = max;
                    max = v;
                }
                else
                {
                    ++comparisons;
                    if (secondMax < v)
                    {
                        secondMax = v;
                    }
                }
            }
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
class Abc
{
    public static bool op_Equality(Abc abc1, Abc abc2)
    {
        return true;
    }
}