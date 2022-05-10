class GraphNode<T>
{
    protected T _value;
    protected List<GraphNode<T>>? _graphNodes;
    public GraphNode(T value, GraphNode<T>[]? graphNodes = null)
    {
        _value = value;
        if (graphNodes is not null)
        {
            _graphNodes = graphNodes.ToList();
        }
        else
        {
            _graphNodes = null;
        }
    }
    public GraphNode<T>[]? Neightbors
    {
        get
        {
            if (_graphNodes is not null)
            {
                return _graphNodes.ToArray();
            }
            else
            {
                return null;
            }
        }
    }
    public T Value
    {
        get => _value;
    }
    public GraphNode<T>? this[int index]
    {
        get
        {
            if (_graphNodes is not null)
            {
                return new(_graphNodes[index].Value);
            }
            else
            {
                return null;
            }
        }
    }
    public void AddNeightbor(GraphNode<T> graphNode)
    {
        if (_graphNodes is not null)
        {
            _graphNodes.Add(graphNode);
        }
        else
        {
            _graphNodes = new List<GraphNode<T>>(new GraphNode<T>[] { graphNode });
        }
    }

    public int GetNeightborsCount
    {
        get
        {
            if (_graphNodes is not null)
            {
                return _graphNodes.Count;
            }
            else
            {
                return 0;
            }
        }
    }
    public int GraphCount
    {
        get
        {
            var accumulator = 1;
            if (Neightbors is not null)
            {
                var countGraphNodes = new List<GraphNode<T>>();
                foreach (var item in Neightbors)
                {
                    foreach (var node in countGraphNodes)
                    {
                        if (!ReferenceEquals(item, node))
                        {
                            accumulator++;
                            countGraphNodes.Add(item);
                            break;
                        }
                    }
                    for (int i = 0; i < Neightbors.Length; i++)
                    {
                        accumulator += Neightbors[i].GraphCount;
                    }
                }
            }
            return accumulator;
        }
    }

}