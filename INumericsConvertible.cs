namespace System.Numerics;
interface INumericsConvertible
{
    public BigInteger ToBigInteger();
    public Complex ToComplex();
    public Quaternion ToQuartenion();
    public Plane ToPlane();
}