#pragma warning disable 
namespace Animals;

abstract class Bird : Animal
{
    private bool _isFly;
    public Bird(string name) :
    base(name)
    {

    }
    public void Fly(Tree tree)
    {
        _isFly = true;
    }
    public void UnFly(Tree tree)
    {
        _isFly = false;
    }
    public bool IsFly { get => _isFly; private set { } }
}
