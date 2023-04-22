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
    public double this[int count]
    {
        get => Vectors[count / Y].Values[count % X];
        set => Vectors[count / Y].Values[count % X] = value;
    }
    public static Matrix Dot(int x, int y)
    {
        var result = Generate(x, y);
        result[Random.Next(x), Random.Next(y)] = 1;
        return result;
    }
    public int X { get; }
    public int Y { get; }
    public int Length { get => X * Y; }
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
        return new(Values.Select(x => x).ToArray());
    }
}
public class NeuralNetwork
{
    public NeuralNetwork(Matrix[] matrices, double delta = 0.01)
    {
        Matrices = matrices;
        Delta = delta;
    }

    public Matrix[] Matrices { get; }
    public double Delta { get; set; }
    public bool LowerDot { get; private set; }

    public Vector Propagate(Vector data)
    {
        Vector result = data;
        foreach (var item in Matrices)
        {
            data = (data * item).Relu();
        }
        return data;
    }


    public static NeuralNetwork GetRandomNetwork(int min, int max, string arch, double delta = 0.01)
    {
        var neurons = arch.Split(',').Select(k => int.Parse(k)).ToArray();
        Matrix[] result = new Matrix[neurons.Length - 1];
        for (int i = 0; i < neurons.Length - 1; i++)
        {
            result[i] = Evolution.GetRandomMatrix(neurons[i], neurons[i + 1], min, max);
        }
        return new(result, delta);
    }
    public void Write()
    {
        foreach (var item in Matrices)
        {
            item.Write();
        }
    }
    public void BackPropagate(int layer, int x, int y, Vector input, Vector output, double speed)
    {
        var err = Propagate(input) * output;
        this[x, y, layer] += Delta;
        var err2 = Propagate(input) * output;
        this[x, y, layer] += (err2 - err) / Delta * speed - Delta;
    }
    public void BackPropagate(Vector input, Vector output, double speed)
    {
        for (int layer = 0; layer < Matrices.Length; layer++)
        {
            for (int x = 0; x < this[layer].X; x++)
            {
                for (int y = 0; y < this[layer].Y; y++)
                {
                    var err = (Propagate(input) + output * -1).Relu().Values.Sum();
                    this[x, y, layer] += Delta;
                    var err2 = (Propagate(input) + output * -1).Relu().Values.Sum();
                    this[x, y, layer] -= (err2 - err) / Delta * speed + Delta;
                    var err3 = (Propagate(input) + output * -1).Relu().Values.Sum();
                    if (err3 > err2)
                    {
                        speed = -speed * 0.5;
                    }
                }
            }
        }
    }
    public void Gradient(Vector input, Vector output)
    {
        NeuralNetwork network = this;

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
}

public class NeuralNetworkPair
{
    public NeuralNetworkPair(NeuralNetwork a, NeuralNetwork b)
    {
        A = a;
        B = b;
    }

    public NeuralNetwork A { get; }
    public NeuralNetwork B { get; }
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
    public static NeuralNetworkPair Crossing(NeuralNetworkPair pair)
    {
        var dot = Random.Next(pair.A.Matrices.Length);
        var a = pair.A.Matrices.AsSpan(0, dot).ToArray();
        var b = pair.A.Matrices.AsSpan(dot, pair.A.Matrices.Length - dot).ToArray();
        var c = pair.B.Matrices.AsSpan(0, dot).ToArray();
        var d = pair.B.Matrices.AsSpan(dot, pair.B.Matrices.Length - dot).ToArray();
        return new(new(a.Concat(c).ToArray()), new(b.Concat(d).ToArray()));
    }
    public static NeuralNetwork[] Selection(NeuralNetwork[] population, int size, Func<NeuralNetwork, double> selector)
    {
        return population.Chunk(size).Select(n => n.MinBy(selector)).ToArray()!;
    }
    public static NeuralNetwork[] Generation(NeuralNetwork[] neuralNetworks, double min, double max)
    {
        var array = new NeuralNetwork[neuralNetworks.Length * neuralNetworks.Length];
        for (int i = 0; i < neuralNetworks.Length; i++)
        {
            for (int j = 0; j < neuralNetworks.Length; j++)
            {
                array[i * neuralNetworks.Length + j] = new(Crossing(new(neuralNetworks[i], neuralNetworks[j])).A.Matrices.Select(z => Mutation(min, max, z)).ToArray());
            }
        }
        return array;
    }
}