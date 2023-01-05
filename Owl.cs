#pragma warning disable 
namespace Animals;

class Owl : Bird
{
    public Owl(string name) :
    base(name)
    {

    }
    public override void Vocalize()
    {
        Console.WriteLine("ух - ух");
    }
    public virtual void Vocalize(uint uh)
    {
        for (int i = 0; i < uh; i++)
        {
            if (i - 1 != uh)
            {
                Console.Write("ух - ");
            }
            else
            {
                Console.WriteLine("ух");
            }
        }
    }
}
