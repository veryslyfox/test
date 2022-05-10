namespace Animals;

class Penguin : Animal
{
    public Penguin(string name) : base(name)
    {
    }

    public override void Vocalize()
    {
        Console.WriteLine("ТРЯ - Я - Я!");
    }
}