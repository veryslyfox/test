#pragma warning disable 
namespace Animals;

class SmallFox : Fox
{
    protected string _name;
    public SmallFox(string name) :
    base(name)
    {
        _name = name;
    }

    public override void Vocalize()
    {
        if (!IsAsleep)
        {
            Console.WriteLine("ф - ф - фыр?");
        }
    }
}
