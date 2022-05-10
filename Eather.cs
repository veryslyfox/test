class Eather<TLeft, TRight>
{
    private TLeft? _left;
    private TRight? _right;
    private bool _isRight;
    public Eather(TLeft? left, TRight? right, bool isRight)
    {
        if (isRight)
        {
            _right = right;
        }
        else
        {
            _left = left;
        }
        _isRight = isRight;
    }
    public TLeft? LeftValue()
    {
        return _left;
    }
    public TRight? RightValue()
    {
        return _right;
    }
    public Type GetCurrentType()
    {
        if (_isRight)
        {
            return typeof(TRight);
        }
        else
        {
            return typeof(TLeft);
        }
    }
}