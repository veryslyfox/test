global using BigInteger = System.Numerics.BigInteger;
static class FactorialOperations
{
    static public BigInteger Factorial(BigInteger n)
    {
        BigInteger accumulator = 1;
        for (BigInteger i = 1; i <= n; i++)
        {
            accumulator *= i;
        }
        return accumulator;
    }
}