class Functions
{
    BigInteger S(BigInteger a, BigInteger b, BigInteger c)
    {
        if (a == 0)
        {
            return S(b, c, c - 1);
        }
        if (b == 0)
        {
            return S(a, c, c - 1);
        }
        if (c == 0)
        {
            return a + b;
        }
        return S(S(a - 1, b, c), S(a, b - 1, c), c - 1);
    }
    BigInteger V(BigInteger a)
    {
        return S(a, a, a);
    }
    BigInteger W(BigInteger a, BigInteger range)
    {
        if (range == 0)
        {
            return V(a);
        }
        if (a == 0)
        {
            return W(a, range - 1);
        }
        return W(W(a - 1, range), range - 1);
    }
    BigInteger W(BigInteger a)
    {
        return W(a, a);
    }
    BigInteger Q(BigInteger a, BigInteger b, BigInteger c, BigInteger d)
    {
        return Q(a - 1, Q(a, b, c - 1, W(d)), W(c), Q(a, b - 1, c, d));
    }
    BigInteger Q(BigInteger a)
    {
        return Q(a, a, a, a);
    }
    public static BigInteger GetBigInteger()
    {
        Functions functions = new Functions();
        BigInteger Q(BigInteger q)
        {
            return functions.Q(q);
        }
        return functions.S(3, 3, 3);
    }
}