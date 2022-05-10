namespace Animals;
class Mouse : Animal
{
    public Mouse(string name) : base(name) { }
    public override void Vocalize()
    {
        if (!IsAsleep)
        {
            Console.WriteLine("пик - пик");
        }
    }
}
