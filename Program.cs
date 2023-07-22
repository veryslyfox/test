var images = ReadImages("train-images.idx3-ubyte");
var labels = ReadLabels("train-labels.idx1-ubyte");
var weights = Matrix.Random(784, 10, -1, 1);
var weightsGradient = Matrix.Generate(784, 10);
var rng = new Random();
var alpha = 10e-5;
try
{
    for (int epoch = 0; epoch < 100000; epoch++)
    {
        var position = rng.Next(60000);
        Backward(images[position], labels[position]);
        if ((epoch & 127) == 0)
        {
            Console.WriteLine($"Epoch: {epoch} Loss: {Loss()}");
        }
    }
}
catch (Exception exception)
{
    Console.WriteLine(exception);
    Console.ReadKey();
}
Console.ReadKey();
void Backward(Vector input, Vector correctOutput)
{
    var output = input * weights;
    var outputGradient = (output - correctOutput) * 2;
    weightsGradient = (input | outputGradient) * alpha;
    weights -= weightsGradient;
}
double Loss()
{
    var loss = 0.0;
    for (int i = 0; i < 200; i++)
    {
        var p = rng.Next(60000);
        loss += (images[p] * weights - labels[p]).Square().Sum();
    }
    return loss / 200;
}
Vector[] ReadLabels(string labelsFilepath)
{
    var labels = new byte[60000];
    using (var file = File.Open(labelsFilepath, FileMode.Open))
    {
        var reader = new BinaryReader(file);
        var magic = reader.ReadInt32();
        var size = reader.ReadInt32();
        magic = Reverse(magic);
        size = Reverse(size);
        if (magic != 2049)
            throw new ArgumentException("Magic number mismatch, expected 2049");
        labels = reader.ReadBytes(60000);
    }
    var vectorizedLabels = new Vector[labels.Length];
    for (int i = 0; i < 60000; i++)
    {
        vectorizedLabels[i] = Vector.Probability(labels[i], 10);
    }
    return vectorizedLabels;
}
int Reverse(int value)
{
    var b1 = value & 255;
    var b2 = (value >> 8) & 255;
    var b3 = (value >> 16) & 255;
    var b4 = (value >> 24) & 255;
    return (b1 << 24) | (b2 << 16) | (b3 << 8) | b4;
}
Vector[] ReadImages(string imagesFilepath)
{
    Vector[] vectors;
    using (var file = File.Open(imagesFilepath, FileMode.Open))
    {
        var reader = new BinaryReader(file);
        var magic = reader.ReadInt32();
        var size = reader.ReadInt32();
        var rows = reader.ReadInt32();
        var cols = reader.ReadInt32();
        magic = Reverse(magic);
        size = Reverse(size);
        rows = Reverse(rows);
        cols = Reverse(cols);
        var rowsXcols = rows * cols;
        vectors = new Vector[size];
        if (magic != 2051)
            throw new ArgumentException("Magic number mismatch, expected 2051");
        for (int i = 0; i < size; i++)
        {
            var image_data = reader.ReadBytes(rowsXcols);
            var vector = new Vector(image_data.Select(x => (double)(x / 256.0)).ToArray());
            vectors[i] = vector;
        }
    }
    return vectors;
}
class Image
{
    public Image(byte[,] data)
    {
        Data = data;
    }
    public static Image Deserialize(byte[] bytes, int rows, int cols)
    {
        var data = new byte[cols, rows];
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < cols; column++)
            {
                data[column, row] = bytes[row * rows + column];
            }
        }
        return new(data);
    }

    public byte[,] Data { get; }
}