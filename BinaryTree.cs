#pragma warning disable
class BinaryTree<T>
{
    
    protected T _root; 
    protected BinaryTree<T>? _binaryTree1;
    protected BinaryTree<T>? _binaryTree2;
    public BinaryTree(T root, BinaryTree<T>? binaryTree1 = null, BinaryTree<T>? binaryTree2 = null)
    {
        _root = root;
        _binaryTree1 = binaryTree1;
        _binaryTree2 = binaryTree2;
    }
    public T Left
    {
        get => _binaryTree1._root;
    }
    public T Right
    {
        get => _binaryTree2._root;
    }
    public BinaryTree<T>? LeftTree
    {
        get => _binaryTree1;
    }
    public BinaryTree<T>? RightTree
    {
        get => _binaryTree2;
    }
    public T Root
    {
        get => _root;
        set
        {
            _root = value;
        }
    }
}
