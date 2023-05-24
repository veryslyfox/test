var network = NeuralNetwork.GetRandomNetwork(0, 0, "2, 1", 0.0001, 1);
double GetError(NeuralNetwork network)
{
    return Err(1, 1, 2) + Err(1, 2, 3) + Err(2, 1, 3) + Err(2, 2, 4);
}
double Err(double a, double b, double c)
{
    return Math.Abs(c - Use(a, b));
}
double Use(double a, double b)
{
    return network!.Propagate(Vector.Create(a, b)).Values[0];
}
for (int i = 0; i < 100000; i++)
{
    network.CorrectAll(GetError);
}
Console.WriteLine(Use(1, 1));
Console.ReadKey();
// Console.WriteLine(Right("2/234/56", "0123456", 5));
// Console.ReadKey();
// int[] ToFactorialSystem(long value)
// {
//     long factorial = 1;
//     var af = 1;
//     for (long i = 1, result = 1; result * (i + 1) < value; i++, result *= i, factorial = result, af++) ;
//     var resultArray = new int[af];
//     var count = 0;
//     while (value != 0)
//     {
//         if (factorial == 0)
//         {
//             break;
//         }
//         resultArray[count] = (int)(value / factorial);
//         value = value % factorial;
//         if (af - count == 0)
//         {
//             break;
//         }
//         factorial /= (af - count);
//         count++;
//     }
//     return resultArray;
// }
// long HashConverter(long value)
// {
//     BigInteger integer = new BigInteger();
//     foreach (var item in ToFactorialSystem(value))
//     {
//         integer = (integer << 2) ^ item;
//     }
//     return (long)(integer & long.MaxValue) ^ 4294967296;
// }
// double GetValue(string e)
// {
//     var bracket = false;
//     var insert = 0;
//     var inBracket = "";
//     foreach (var item in e)
//     {
//         if (item == '(')
//         {
//             bracket = true;
//             continue;
//         }
//         if (bracket)
//         {
//             if (item == ')')
//             {
//                 bracket = false;
//                 e = e.Replace(inBracket, GetValue(inBracket).ToString());
//                 continue;
//             }
//             inBracket += item;
//         }
//         else
//         {
//             insert++;
//         }
//     }
//     return GetValueBracketless(e);
// }
// double GetValueBracketless(string e)
// {
//     for (int i = 0; i < e.Length; i++)
//     {
//         if (e[i] == '*')
//         {
//             if (double.TryParse(Left(e, "0123456789.", i), out double left) && double.TryParse(Right(e, "0123456789.", i), out double right))
//             {
//                 e = e.Remove(i, )
//                 e = e.Insert(i, (left * right).ToString());
//             }
//             else
//             {
//                 Console.WriteLine("Error");
//             }
//         }
//         if (e[i] == '/')
//         {
//             if (double.TryParse(Left(e, "0123456789.", i), out double left) && double.TryParse(Right(e, "0123456789.", i), out double right))
//             {
//                 e = e.Insert(i, (left / right).ToString());
//             }
//             else
//             {
//                 Console.WriteLine("Error");
//             }
//         }
//     }
//     for (int i = 0; i < e.Length; i++)
//     {
//         if (e[i] == '+')
//         {
//             if (double.TryParse(Left(e, "0123456789.", i), out double left) && double.TryParse(Right(e, "0123456789.", i), out double right))
//             {
//                 e = e.Insert(i, (left + right).ToString());
//             }
//             else
//             {
//                 Console.WriteLine("Error");
//             }
//         }
//         if (e[i] == '/')
//         {
//             if (double.TryParse(Left(e, "0123456789.", i), out double left) && double.TryParse(Right(e, "0123456789.", i), out double right))
//             {
//                 e = e.Insert(i, (left - right).ToString());
//             }
//             else
//             {
//                 Console.WriteLine("Error");
//             }
//         }
//     }
// }
// string Left(string e, string values, int index) // Идти влево и читать e с index, пока символы входят в строку values
// {
//     var beginIndex = index;
//     var result = "";
//     index--;
//     while (index == -1 && values.Contains(e[index]))
//     {
//         result = e[index] + result;
//         index--;
//     }
//     return result;
// }
// string Right(string e, string values, int index) // Идти влево и читать e с index, пока символы входят в строку values
// {
//     var beginIndex = index;
//     var result = "";
//     index++;
//     while (index != e.Length && values.Contains(e[index]))
//     {
//         result = result + e[index];
//         index++;
//     }
//     return result;
// }