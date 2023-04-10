using System.Collections;
using Animals;

public class Matrix
{
    public Matrix(Vector[] vectors)
    {
        Vectors = vectors;
        X = vectors[0].Values.Length;
        Y = vectors.Length;
    }
    public static Matrix Create(params Vector[] vectors)
    {
        return new(vectors);
    }
    public static Vector operator *(Vector vector, Matrix matrix)
    {
        return new(matrix.Vectors.Select(v => v * vector).ToArray());
    }
    public static Matrix operator +(Matrix a, Matrix b)
    {
        return new(a.Vectors.Zip(b.Vectors, (p, q) => p + q).ToArray());
    }
    public static Matrix operator *(Matrix a, double b)
    {
        return new(a.Vectors.Select(k => k * b).ToArray());
    }
    public static Matrix operator -(Matrix value)
    {
        return new(value.Vectors.Select(z => -z).ToArray());
    }
    public Vector[] Vectors { get; }
    public void Write()
    {
        foreach (var item in Vectors)
        {
            item.Write();
        }
    }
    public static Matrix Generate(int x, int y, double d = 0)
    {
        var array = new double[x];
        Array.Fill(array, d);
        var vector = new Vector(array);
        var vectors = new Vector[y];
        for (int i = 0; i < y; i++)
        {
            array = array.ToArray();
            vector = new(array);
            vectors[i] = vector;
        }
        return new(vectors);
    }
    public static Random Random = new Random();
    public static Matrix GenerateBin(int x, int y)
    {
        var matrix = Generate(x, y, 0);
        for (int row = 0; row < y; row++)
        {
            for (int column = 0; column < x; column++)
            {
                matrix[column, row] = Random.Next(2);
            }
        }
        return matrix;
    }
    public double this[int x, int y]
    {
        get => Vectors[y].Values[x];
        set => Vectors[y].Values[x] = value;
    }
    public static Matrix Dot(int x, int y)
    {
        var result = Generate(x, y);
        result[Random.Next(x), Random.Next(y)] = 1;
        return result;
    }
    public int X { get; }
    public int Y { get; }
}
public class Vector
{
    public Vector(double[] values)
    {
        Values = values;
    }
    public static Vector Create(params double[] values)
    {
        return new(values);
    }
    public double[] Values { get; }
    public static double operator *(Vector a, Vector b)
    {
        return a.Values.Zip(b.Values, (p, q) => p * q).Sum();
    }
    public static Vector operator +(Vector a, Vector b)
    {
        return new(a.Values.Zip(b.Values, (p, q) => p + q).ToArray());
    }
    public static Vector operator *(Vector a, double b)
    {
        return new(a.Values.Select(k => k * b).ToArray());
    }
    public static Vector operator -(Vector value)
    {
        return new(value.Values.Select(z => -z).ToArray());
    }
    public void Write()
    {
        foreach (var item in Values)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
    public Vector Relu()
    {
        return new(Values.Select(x => x < 0 ? 0 : x).ToArray());
    }
}
public class NeuralNetwork
{
    public NeuralNetwork(Matrix[] matrices, double delta = 0.01)
    {
        Random random = new Random();
        Matrices = matrices;
        Delta = delta;
        DMatrix = matrices[matrices.Length - 1];
    }

    public Matrix[] Matrices { get; }
    public double Delta { get; }
    public Matrix DMatrix { get; set; }
    public int Y { get; private set; }
    public int X { get; private set; }
    public bool LowerDot { get; private set; }

    public Vector Propagation(Vector data)
    {
        Vector result = data;
        foreach (var item in Matrices)
        {
            data = (data * item).Relu();
        }
        return data;
    }
   
    
    public static NeuralNetwork Random(int min, int max, string arch)
    {

    }
}

public class NeuralNetworkPair
{
    public NeuralNetworkPair()
    {

    }
}

public interface IResultMetrics<T>
{
    double Error(T data);
}
public class Metrics : IResultMetrics<Vector>
{
    public Metrics(Vector vector)
    {
        Vector = vector;
    }

    public Vector Vector { get; }

    public double Error(Vector vector)
    {
        return ((Vector + vector * -1) * (Vector + vector * -1));
    }
}
public class Evolution
{
    static Random Random { get; } = new Random();
    public static Matrix GetRandomMatrix(int x, int y, double min, double max)
    {
        var matrix = Matrix.Generate(x, y);
        for (int row = 0; row < y; row++)
        {
            for (int column = 0; column < x; column++)
            {
                matrix[column, row] = Random.NextDouble() * (max - min) + min;
            }
        }
        return matrix;
    }
    public static Matrix Mutation(double min, double max, Matrix matrix)
    {
        return matrix + GetRandomMatrix(matrix.X, matrix.Y, min, max);
    }
}