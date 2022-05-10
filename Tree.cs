#pragma warning disable 
namespace Animals
{
    abstract class Tree
    {
        protected int _birds;
        public int GetBirds
        {
            get => _birds;
        }
    }
}
namespace System.Collections.Generic
{
    class Tree<T>
    {
        protected T _root;
        protected Tree<T>?[]? _trees;
        public Tree(T root, Tree<T>?[]? trees)
        {
            _root = root;
            _trees = trees;
        }
        public static Tree<T> Create(T root, params Tree<T>?[]? trees)
        {
            return new(root, trees);
        }

        public override bool Equals(object? obj)
        {
            return obj is Tree<T> tree &&
                   Equals(_root, tree._root) &&
                   Equals(_trees, tree._trees) &&
                   Equals(Root, tree.Root) &&
                   Equals(GetT, tree.GetT);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_trees, Root, GetT, TryToRootValue);
        }

        public T Root
        {
            get => _root;
        }
        public Tree<T>? this[int index]
        {
            get => _trees[index];
            set
            {
                _trees[index] = value;
            }
        }
        public Type GetT
        {
            get => _trees[0].Root.GetType();
        }
        public bool TryToRootValue
        {
            get => _trees is null;
        }
        public int Depth
        {
            get
            {
                if (this[0] == null)
                {
                    return 1;
                }
                else
                {
                    return this[0].Depth + 1;
                }
            }
        }
    }
}
