public class Matrix
{
    public Matrix(Vector[] vectors)
    {
        Vectors = vectors;
        X = vectors[0].Values.Length;
        Y = vectors.Length;
    }
    public double[] ToArray()
    {
        return Vectors.SelectMany(v => v.Values).ToArray();
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
    public double this[int x, int y]
    {
        get => Vectors[y].Values[x];
        set => Vectors[y].Values[x] = value;
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
    public double[] Values { get; set; }
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
        return new(Values.Select(x => x > 0 ? x : 0).ToArray());
    }
    public double Sum()
    {
        return Values.Sum();
    }
}
public class NeuralNetwork
{
#pragma warning disable
    public NeuralNetwork(Matrix[] matrices, bool isFormed = true, double delta = 0.01, double alpha = 1) // Form property not used from "Weight hegehod"
#pragma warning restore
    {
        Matrices = matrices;
        Delta = delta;
        Alpha = alpha;
    }
    public double[] Weights;

    public Matrix[] Matrices { get; set; }
    public double Delta { get; set; }
    public bool LowerDot { get; private set; }
    public NeuralNetwork Form { get; }

    public Vector Propagate(Vector data)
    {
        Vector result = data;
        foreach (var item in Matrices)
        {
            data = (data * item).Relu();
        }
        return data;
    }


    public static NeuralNetwork GetRandomNetwork(int min, int max, string arch, double delta, double alpha)
    {
        var neurons = arch.Split(',').Select(k => int.Parse(k)).ToArray();
        Matrix[] result = new Matrix[neurons.Length - 1];
        for (int i = 0; i < neurons.Length - 1; i++)
        {
            result[i] = Evolution.GetRandomMatrix(neurons[i], neurons[i + 1], min, max);
        }
        return new(result, false, delta, alpha);
    }
    public void Write()
    {
        foreach (var item in Matrices)
        {
            item.Write();
        }
    }

    public Matrix this[int layer]
    {
        get => Matrices[layer];
        set => Matrices[layer] = value;
    }
    public double this[int x, int y, int layer]
    {
        get => Matrices[layer][x, y];
        set => Matrices[layer][x, y] = value;
    }
    public void CorrectAll(Func<NeuralNetwork, double> func)
    {
        for (int layer = 0; layer < Matrices.Length; layer++)
        {
            for (int y = 0; y < Matrices[layer].Y; y++)
            {
                for (int x = 0; x < Matrices[layer].X; x++)
                {
                    Correct(x, y, layer, func);
                }
            }
        }
    }
    public void Correct(int x, int y, int layer, Func<NeuralNetwork, double> func)
    {
        var fx = func(this);
        this[x, y, layer] += Delta;
        var fxd = func(this);
        this[x, y, layer] -= Delta;
        this[x, y, layer] += (fx - fxd) * Alpha;
        var fxr = func(this);
        if (fxr > fx)
        {
            Alpha /= 2;
        }
    }
    public double Alpha { get; private set; }
    public static readonly Random _rng = new Random();
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
}