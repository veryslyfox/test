using System.Collections;
using Animals;

public class Matrix
{
    public Matrix(Vector[] vectors)
    {
        Vectors = vectors;
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
        Array.Fill(vectors, vector);
        return new(vectors);
    }
    public static Matrix GenerateBin(int x, int y)
    {
        Random rng = new Random();
        var matrix = Generate(x, y, 0);
        for (int row = 0; row < y; row++)
        {
            for (int column = 0; column < x; column++)
            {
                matrix[column, row] = rng.Next(2);   
            }
        }
        return matrix;
    }
    public double this[int x, int y]
    {
        get => Vectors[y].Values[x];
        set => Vectors[y].Values[x] = value;
    }
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
        return new(Values.Select(x => x < 0 ? x : 0).ToArray());
    }
}
public class NeuralNetwork
{
    public NeuralNetwork(Matrix[] matrices, double delta = 0.01)
    {
        Random random = new Random();
        Matrices = matrices;
        Delta = delta;
    }

    public Matrix[] Matrices { get; }
    public double Delta { get; }
    public Vector Propagation(Vector input)
    {
        Vector result = input;
        foreach (var item in Matrices)
        {
            input = (input * item).Relu();
        }
        return input;
    }
    
    public void RandomBinMatrix()
    {
        Random rng = new Random();
        Matrix matrix = new Matrix(new Vector[16]);
        for (int y = 0; y < Matrices.GetLength(1); y++)
        {
            for (int x = 0; x < Matrices.GetLength(0); x++)
            {
                
            }
        }
        rng.Next(2);
    }
}

