using System.Collections;

namespace System.Numerics.Equations;
class Matrix
{
    public Matrix(int[,] values)
    {
        Values = values;
    }

    public int[,] Values { get; }
    public int Width;
    public int Height;
    /*
    public Vector this[int index, SliceType type]
    {
        get
        {
            
            if (type == SliceType.Column)
            {
                for (int row = 0; row < Values.GetLength(0); row++)
                {
                                        
                }
            }
        }   
    }
    */
}
enum SliceType
{
    Column,
    Row   
}
class Vector : IEnumerable<int>
{
    public Vector(int[] array)
    {
        Array = array;
    }
    public static Vector operator +(Vector left, Vector right)
    {
        return (Vector)left.Zip(right, (int a, int b) => a + b);
    }
    public static Vector operator /(Vector left, int right)
    {
        return (Vector)left.Select((int a) => a / right);
    }
    public int[] Array { get; }

    public IEnumerator<int> GetEnumerator()
    {
        return (IEnumerator<int>)((IEnumerable<int>)Array);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Array.GetEnumerator();
    }
}