var rng = new Random();
try
{
    var e = Console.ReadLine();
    while (e == null)
    {
        e = Console.ReadLine();
    }
    e = e.Replace(" ", "");
    List<double> numbers = new();
    List<Operation> operations = new();
    var numberString = "";
    foreach (var item in e)
    {
        var itemCode = (int)item;
        if (itemCode is > 47 and < 58 || itemCode == 46)
        {
            numberString += item;
        }
        else
        {
            numberString = "";
            break; 
        }
    }
    if (double.TryParse(numberString, out double number))
    {
        numbers.Add(number);
        goto 
    }
    else
    {
        Console.WriteLine("Error");
        Console.ReadKey();
        return;
    }
}
catch (Exception exception)
{
    Console.Error.WriteLine(exception);
}
finally
{
    Console.ReadKey();
}
enum Operation
{
    Addition,
    Subtraction,
    Multiply,
    Division,
}