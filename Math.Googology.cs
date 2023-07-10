using System.Numerics;
static partial class MathHigh
{
    public static partial class Googology
    {
        static LazyElement<BigInteger> GoogolValue;
        public static BigInteger Googol
        {
            get
            {
                if (!GoogolValue.HasValue)
                {
                    return Pow(10, 100);
                }
                else
                {
                    return GoogolValue.Value;
                }
            }
        }
    }
}