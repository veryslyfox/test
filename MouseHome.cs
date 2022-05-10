#pragma warning disable 
namespace Animals;
class MouseHome : IEquatable<MouseHome>
{
    protected bool _isHidden;
    protected uint _miseCount;
    protected List<Mouse> _mise;
    public MouseHome()
    {
        _miseCount = 0;
        _mise = new List<Mouse>();
    }
    public void Hide()
    {
        _isHidden = true;
    }
    public void Unhide()
    {
        _isHidden = false;
    }
    public bool IsHidden
    {
        get => _isHidden;
    }
    public uint MiseCount
    {
        get => _miseCount;
    }
    public void DeleteMouse(Cat eater, Mouse mouse)
    {
        if (MiseCount != 0)
        {
            for (int i = 0; i < _miseCount; i++)
            {
                if (mouse == _mise[i])
                {
                    _miseCount -= 1;
                }
            }
        }
    }
    public void DeleteMouse(Fox eater, Mouse mouse)
    {
        if (MiseCount != 0)
        {
            for (int i = 0; i < _miseCount; i++)
            {
                if (mouse == _mise[i])
                {
                    _miseCount -= 1;
                }
            }
        }
    }
    public void AddMouse(Mouse mouse)
    {
        _miseCount += 1;
        _mise.Add(mouse);
    }
    public void MouseWrite(int index)
    {
        Console.Write($"mouse {_mise[index].Name}");
    }
    public void MouseWriteLine(int index)
    {
        Console.WriteLine($"mouse {_mise[index].Name}");
    }
    public void MiseWrite()
    {
        for (int i = 0; i < _miseCount; i++)
        {
            MouseWrite(i);
        }
    }
    public void MiseWriteLine()
    {
        for (int i = 0; i < _miseCount; i++)
        {
            MouseWriteLine(i);
        }
    }
    public static bool operator ==(MouseHome? x, MouseHome? y) => x is not null ? x.Equals(y) : y is null;

    public static bool operator !=(MouseHome? x, MouseHome? y) => !(x == y);

    public override bool Equals(object? other) => Equals(other as MouseHome);

    public bool Equals(MouseHome? other) => other is not null && (
        ReferenceEquals(this, other) ||
        _miseCount == other._miseCount && _isHidden == other._isHidden);
    public override int GetHashCode()
    {
        if (!_isHidden)
        {
            return (int)_miseCount;
        }
        else
        {
            return (int)_miseCount + (int)Math.Sqrt(_miseCount);
        }
    }
}
