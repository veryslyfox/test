#pragma warning disable
using System.Numerics;
delegate double Parse(string value);
class NumericsStringProvider : IStringProvider<Quaternion>, IStringProvider<Complex>
, IStringProvider<int, string>
{
    public string ToString(Quaternion value)
    {
        return $"{value.X} + {value.Y}i + {value.Z}j + {value.W}k";
    }

    public string ToString(Complex value)
    {
        return $"{value.Real} + {value.Imaginary}i";
    }

    public string ToString(int value, string format)
    {
        var result = "";
        var pointer = 0;
        var parse = 0;
        while (true)
        {
            if (48 <= format[pointer] && format[pointer] <= 57)
            {
                parse *= 10;
                parse += format[pointer] - 48;
                pointer++;
            }
            else
            {
                format.TakeLast(format.Length - pointer);   
            }
        }
        return result;
    }
}