using System.Runtime.InteropServices;
public class Matrix
{
    private GCHandle _gcHandle;
    public unsafe Matrix(Vector[] vectors)
    {
        X = vectors[0].Values.Length;
        Y = vectors.Length;
        Weights = new double[X * Y];
        _gcHandle = GCHandle.Alloc(Weights, GCHandleType.Pinned);
        Pointer = _gcHandle.AddrOfPinnedObject();
        var pointer = (double*)Pointer;
        for (int y = 0; y < vectors.Length; y++)
        {
            var rowBegin = y * X;
            for (int x = 0; x < vectors[y].Values.Length; x++)
            {
                *(pointer + rowBegin + x) = vectors[y].Values[x];
            }
        }
    }
    public IntPtr Pointer;
    public Matrix Gradient
    {
        get;
        set;
    }
    public unsafe Matrix(double[,] values)
    {
        X = values.GetLength(0);
        Y = values.GetLength(1);
        Weights = new double[X * Y];
        _gcHandle = GCHandle.Alloc(Weights, GCHandleType.Pinned);
        Pointer = _gcHandle.AddrOfPinnedObject();
        var pointer = (double*)Pointer;
        var index = 0;
        foreach (var item in values)
        {
            index++;
            *(pointer + index) = item;
        }
    }
    public Matrix(double[] values, int x, int y)
    {
        X = x;
        Y = y;
        Weights = values;
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
        var result = new double[matrix.Y];
        for (int y = 0; y < matrix.Y; y++)
        {
            var value = 0.0;
            for (int x = 0; x < matrix.X; x++)
            {
                value += matrix[x, y] * vector[x];
            }
            result[y] = value;
        }
        return new(result, CreationOp.MultiplyVectorMatrix, new object[] { vector, matrix });
    }
    public static Matrix operator +(Matrix a, Matrix b)
    {
        var result = a;
        for (int i = 0; i < a.Weights.Length; i++)
        {
            result.Weights[i] += b.Weights[i];
        }
        return result;
    }
    public static Matrix operator -(Matrix a, Matrix b)
    {
        var result = a;
        for (int i = 0; i < a.Weights.Length; i++)
        {
            result.Weights[i] -= b.Weights[i];
        }
        return result;
    }
    public static Matrix operator *(Matrix a, double b)
    {
        return new(a.Weights.Select(k => k * b).ToArray(), a.X, a.Y);
    }
    public static Matrix operator -(Matrix value)
    {
        Matrix result = value;
        for (int i = 0; i < value.Weights.Length; i++)
        {
            result.Weights[i] = -result.Weights[i];
        }
        return result;
    }
    public Vector[] Vectors { get; }
    public void Write()
    {
        for (int y = 0; y < Y; y++)
        {
            for (int x = 0; x < X; x++)
            {
                Console.Write($"{this[x, y]} ");
            }
            Console.WriteLine();
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
    public static Random Rng = new Random();
    public double[] Weights { get; }
    public double this[int x, int y]
    {
        get => Weights[y * X + x];
        set => Weights[y * X + x] = value;
    }
    public int X { get; set; }
    public int Y { get; set; }
    public static Matrix Random(int x, int y, double min, double max)
    {
        var matrix = Matrix.Generate(x, y);
        for (int row = 0; row < y; row++)
        {
            for (int column = 0; column < x; column++)
            {
                matrix[column, row] = Rng.NextDouble() * (max - min) + min;
            }
        }
        return matrix;
    }
    public Matrix MultiplyAllColumns(Vector vector)
    {
        var result = Generate(X, Y);
        for (int y = 0; y < Y; y++)
        {
            for (int x = 0; x < X; x++)
            {
                result[x, y] = this[x, y] * vector[y];
            }
        }
        return result;
    }
    public Matrix MultiplyAllRows(Vector vector)
    {
        var result = Generate(X, Y);
        for (int y = 0; y < Y; y++)
        {
            for (int x = 0; x < X; x++)
            {
                result[x, y] = this[x, y] * vector[x];
            }
        }
        return result;
    }
    public Matrix ElementwiseMultiply(Matrix value)
    {
        return new(Weights.Select((x, i) => value.Weights[i] * x).ToArray(), X, Y);
    }
    Matrix Transpone()
    {
        var result = Generate(Y, X);
        for (int y = 0; y < Y; y++)
        {
            for (int x = 0; x < X; x++)
            {
                result[y, x] = this[x, y];
            }
        }
        return result;
    }
    public Matrix T
    {
        get => Transpone();
    }
    public Matrix Select(Func<double, double> function)
    {
        var result = this;
        for (int y = 0; y < Y; y++)
        {
            for (int x = 0; x < X; x++)
            {
                result[x, y] = function(result[x, y]);
            }
        }
        return result;
    }
}
public enum CreationOp
{
    Init,
    Add,
    MultiplyVectorMatrix,
    Convolution,
    Pooling,
    ReLU,
    LeakyReLU,
    Softsign,
    Softmax,
}
public class Vector
{
    public Vector(double[] values, CreationOp creation_op = CreationOp.Init, object[]? creators = null)
    {
        Values = values;
        Length = values.Length;
        CreationOp = creation_op;
        Creators = creators;
    }
    public static Vector Create(params double[] values)
    {
        return new(values);
    }
    public double[] Values { get; set; }
    CreationOp CreationOp { get; }
    object[]? Creators { get; }
    public int Length;

    public static Vector operator +(Vector a, Vector b)
    {
        var result = a.Values;
        for (int i = 0; i < b.Length; i++)
        {
            result[i] += b[i];
        }
        return new Vector(result, CreationOp.Add, new object[] { a, b });
    }
    public static Matrix operator |(Vector left, Vector right)
    {
        var result = new Matrix(new double[left.Length, right.Length]);
        for (int i = 0; i < left.Length; i++)
        {
            for (int j = 0; j < right.Length; j++)
            {
                result[i, j] = left[i] * right[j];
            }   
        }
        return result;
    }
    public static Vector Probability(int truePosition, int positionCount)
    {
        var result = new Vector(new double[positionCount]);
        result[truePosition] = 1;
        return result;
    }
    public static Vector operator -(Vector a, Vector b)
    {
        var result = a.Values;
        for (int i = 0; i < b.Length; i++)
        {
            result[i] -= b[i];
        }
        return new Vector(result, CreationOp.Add, new object[] { a, b });
    }
    public static Vector operator *(Vector a, double b)
    {
        var result = a.Values;
        for (int i = 0; i < a.Length; i++)
        {
            result[i] *= b;
        }
        return new Vector(result);
    }

    public double this[int index]
    {
        get => Values[index];
        set => Values[index] = value;
    }
    public void Write()
    {
        foreach (var item in Values)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
    public static Vector Random(int length, double min, double max)
    {
        var result = new Vector(new double[length]);
        for (int i = 0; i < length; i++)
        {
            result[i] = Matrix.Rng.NextDouble() * (max - min) + min;
        }
        return result;
    }
    public Vector Relu()
    {
        return new(Values.Select(x => x > 0 ? x : 0).ToArray(), CreationOp.ReLU, new object[] { this });
    }
    public Vector Square()
    {
        return new(Values.Select(x => x * x).ToArray());
    }
    public Vector Select(Func<double, double> func)
    {
        return new(Values.Select(func).ToArray());
    }
    public Vector LeakyRelu()
    {
        return new(Values.Select(x => x > 0 ? x : (x * 0.01)).ToArray(), CreationOp.LeakyReLU, new object[] { this });
    }
    public Vector Softsign()
    {
        return new(Values.Select(x => x > 0 ? 1 / (x + 1) : 1 / (1 - x)).ToArray(), CreationOp.Softsign, new object[] { this });
    }
    public Vector Gradient { get; set; }
    public void Backward(Vector gradient)
    {
        Vector TakeAsVector(int index)
        {
            if (Creators == null)
            {
                throw new Exception("NULL!");
            }
            return (Vector)Creators[index];
        }
        Matrix TakeAsMatrix(int index)
        {
            if (Creators == null)
            {
                throw new Exception("NULL!");
            }
            return (Matrix)Creators[index];
        }
        switch (CreationOp)
        {
            case CreationOp.Init:
                break;
            case CreationOp.Add:
                var left = TakeAsVector(0);
                var right = TakeAsVector(1);
                left.Gradient = Gradient;
                right.Gradient = Gradient;
                Creators[0] = left;
                Creators[1] = right;
                break;
            case CreationOp.MultiplyVectorMatrix:
                {
                    var vector = TakeAsVector(0);
                    var matrix = TakeAsMatrix(1);
                    vector.Gradient = this * matrix.T;
                    for (int y = 0; y < matrix.Y; y++)
                    {
                        for (int x = 0; x < matrix.X; x++)
                        {
                            matrix.Gradient[x, y] = this[x] * vector.Gradient[y];
                        }
                    }
                    Creators[0] = vector;
                    Creators[1] = matrix;
                    break;
                }
            case CreationOp.ReLU:
                {
                    var vector = TakeAsVector(0);
                    vector.Gradient = Activate.Deriv(this, ActivateFunction.ReLU);
                    Creators[0] = vector;
                    break;
                }
            case CreationOp.LeakyReLU:
                {
                    var vector = TakeAsVector(0);
                    vector.Gradient = Activate.Deriv(this, ActivateFunction.LeakyReLU);
                    Creators[0] = vector;
                    break;
                }
            case CreationOp.Softsign:
                {
                    var vector = TakeAsVector(0);
                    vector.Gradient = Activate.Deriv(this, ActivateFunction.Softsign);
                    Creators[0] = vector;
                    break;
                }
            case CreationOp.Softmax:
                {
                    var vector = TakeAsVector(0);
                    vector.Gradient = SoftmaxDeriv();
                    Creators[0] = vector;
                    break;
                }
        }
        if (Creators != null)
            foreach (var creator in Creators)
            {
                if (creator is Vector vector)
                {
                }
            }
    }
    public Vector Softmax()
    {
        var result = Values;
        var norm = 0.0;
        for (int i = 0; i < Length; i++)
        {
            result[i] = Math.Exp(result[i]);
            norm += result[i];
        }
        for (int i = 0; i < Length; i++)
        {
            result[i] /= norm;
        }
        return new(result, CreationOp.Softmax, new object[] { this });
    }
    public Vector SoftmaxDeriv()
    {
        var result = Values;
        var all = 0.0;
        for (int i = 0; i < Length; i++)
        {
            result[i] = Math.Exp(result[i]);
            all += result[i];
        }
        for (int i = 0; i < Length; i++)
        {
            result[i] = 1 / all - result[i] / (all * all);
        }
        return new(result);
    }
    public double Sum()
    {
        return Values.Sum();
    }
    public static Vector Concat(Vector up, Vector down)
    {
        var result = new double[up.Values.Length + down.Values.Length];
        for (int i = 0; i < up.Values.Length; i++)
        {
            result[i] = up.Values[i];
        }
        for (int i = up.Values.Length; i < up.Values.Length + down.Values.Length; i++)
        {
            result[i] = down.Values[i - up.Values.Length];
        }
        return new(result);
    }
}
public class Database
{
    public Database(Dictionary<Vector, Vector> data)
    {
        Data = data;
    }
    public double Error(NeuralNetwork network)
    {
        var sum = 0.0;
        foreach (var item in Data)
        {
            sum += Dist(network.Propagate(item.Key), item.Value);
        }
        return sum;
    }
    public static double Dist(Vector left, Vector right)
    {
        return left.Values.Zip(right.Values, (a, b) => (a - b) * (a - b)).Aggregate((a, b) => a + b);
    }
    public Dictionary<Vector, Vector> Data { get; }
}
public class NeuralNetwork
{
    public NeuralNetwork(Matrix[] matrices, double delta = 0.01, double alpha = 1, bool isRecurrent = false) // Form property not used from "Weight hegehod"
    {
        Matrices = matrices;
        Delta = delta;
        Alpha = alpha;
        IsRecurrent = isRecurrent;
        Output = new(new double[matrices[matrices.Length - 1].Y]);
    }
    public Matrix[] Matrices { get; set; }
    public double Delta { get; set; }
    public Vector Output { get; set; }
    public bool IsRecurrent;
    public Vector Propagate(Vector data)
    {
        Vector result = data;
        if (IsRecurrent)
        {
            result = Vector.Concat(result, Output);
        }
        foreach (var item in Matrices)
        {
            result = (result * item).Relu();
        }
        if (IsRecurrent)
        {
            Output = result;
        }
        return result;
    }
    public Vector PropagateText(string data)
    {
        Vector result = new Vector(new double[0]);
        if (IsRecurrent)
        {
            for (int i = 0; i < data.Length / Output.Values.Length; i++)
            {
                var array = new double[Output.Values.Length];
                var beginBlock = i * Output.Values.Length;
                for (int j = 0; j < Output.Values.Length; j++)
                {
                    array[j] = data[beginBlock + j];
                }
                result = Propagate(new(array));
            }
            return result;
        }
        return Output;
    }
    public static NeuralNetwork GetRandomNetwork(int min, int max, string arch, double delta, double alpha)
    {
        var neurons = arch.Split(',').Select(k => int.Parse(k)).ToArray();
        Matrix[] result = new Matrix[neurons.Length - 1];
        for (int i = 0; i < neurons.Length - 1; i++)
        {
            result[i] = Matrix.Random(neurons[i], neurons[i + 1], min, max);
        }
        return new(result, delta, alpha);
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
    public double CorrectAll(Func<NeuralNetwork, double> func)
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
        return func(this);
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
    public void Write(string fileName, FileMode mode)
    {
        var file = File.Open(fileName, mode);
        BinaryWriter writer = new BinaryWriter(file);
        writer.Write(Delta);
        writer.Write(Alpha);
        writer.Write(Matrices.Length);
        writer.Write(Matrices[0].X);
        for (int layer = 0; layer < Matrices.Length; layer++)
        {
            writer.Write(Matrices[layer].Y);
            for (int y = 0; y < Matrices[layer].Y; y++)
            {
                for (int x = 0; x < Matrices[layer].X; x++)
                {
                    writer.Write(this[x, y, layer]);
                }
            }
        }
        file.Close();
    }
    static public NeuralNetwork Read(string fileName, FileMode mode)
    {
        var file = File.Open(fileName, mode);
        BinaryReader reader = new BinaryReader(file);
        var delta = reader.ReadDouble();
        var alpha = reader.ReadDouble();
        var layerCount = reader.ReadInt32();
        var width = reader.ReadInt32();
        int height;
        var result = new NeuralNetwork(new Matrix[layerCount], delta, alpha);
        for (int layer = 0; layer < layerCount; layer++)
        {
            height = reader.ReadInt32();
            result.Matrices[layer] = Matrix.Generate(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    result[x, y, layer] = reader.ReadDouble();
                }
            }
            width = height;
        }
        file.Close();
        return result;
    }
    public double Alpha { get; private set; }
    public static readonly Random _rng = new Random();
}

static class Activate
{
    public static Vector Use(Vector input, ActivateFunction function)
    {
        var output = new Vector(new double[input.Values.Length]);
        for (int i = 0; i < input.Values.Length; i++)
        {
            output[i] = GetActivateFuncResult(input[i], function);
        }
        return output;
    }
    public static Vector Deriv(Vector input, ActivateFunction function)
    {
        var output = new Vector(new double[input.Values.Length]);
        for (int i = 0; i < input.Values.Length; i++)
        {
            output[i] = GetActivateFuncDeriv(input[i], function);
        }
        return output;
    }
    public static double GetActivateFuncResult(double neuronInput, ActivateFunction activateFunc)
    {
        var i = neuronInput;
        switch (activateFunc)
        {
            case ActivateFunction.ReLU:
                return i < 0 ? 0 : i;
            case ActivateFunction.LeakyReLU:
                return i < 0 ? 0.01 * i : i;
            case ActivateFunction.Softsign:
                return i / ((i > 0 ? i : -i) + 1);
            case ActivateFunction.PositiveSoftsign:
                return (i / ((i > 0 ? i : -i) + 1) + 1) / 2;
            default:
                return 0;
        }
    }
    public static double GetActivateFuncDeriv(double input, ActivateFunction activateFunc)
    {
        var i = input;
        switch (activateFunc)
        {
            case ActivateFunction.ReLU:
                return i < 0 ? 0 : 1;
            case ActivateFunction.LeakyReLU:
                return i < 0 ? 0.01 : 1;
            case ActivateFunction.Softsign:
                return i < 0 ? 1 / ((i + 1) * (i + 1)) : 1 / ((1 - i) * (1 - i));
            case ActivateFunction.PositiveSoftsign:
                return (i < 0 ? 1 / ((i + 1) * (i + 1)) : 1 / ((1 - i) * (1 - i)) + 1) / 2;
            default:
                return 0;
        }
    }
}
enum ActivateFunction
{
    ReLU,
    LeakyReLU,
    Softsign,
    PositiveSoftsign,
    Softmax
}
