try
{
    var network = NeuralNetwork.GetRandomNetwork(0, 0, "2, 1", 0.0001, 1);
    double GetError(NeuralNetwork network)
    {
        return Err(1, 1, 2) + Err(1, 2, 3) + Err(2, 1, 3) + Err(2, 2, 4);
    }
    double Err(double a, double b, double c)
    {
        return Math.Abs(c - Use(a, b));
    }
    double Use(double a, double b)
    {
        return network!.Propagate(Vector.Create(a, b)).Values[0];
    }
    for (int i = 0; i < 100000; i++)
    {
        network.CorrectAll(GetError);
    }
    network.Write();
    network.Write("Weights", FileMode.Open);
    NeuralNetwork.Read("Weights", FileMode.Open).Write();
    Console.ReadKey();
}
catch (Exception exception)
{
    Console.Error.WriteLine(exception);
}
finally
{
    Console.ReadKey();
}