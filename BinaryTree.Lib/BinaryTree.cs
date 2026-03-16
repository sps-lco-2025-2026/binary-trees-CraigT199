using System.Reflection.Metadata;

namespace BinaryTree.Lib;

public class BinaryTree
{
    public BinaryTreeNode _head;
   
    public BinaryTree()
    {
        _head = null;
    }

    public BinaryTree(int v)
    {
        _head = new BinaryTreeNode(v);
    }
    
    public BinaryTree(IList<int> ls) : this()
    {
        foreach(int i in ls) 
            Insert(i);          
    }

    public int Sum => _head == null ? 0 : _head.Sum;

    public void Insert(int v)
    {
        if (_head == null)
            _head = new BinaryTreeNode(v);
        else
            _head.Insert(v);
    }

    public bool Contains(int v)
    {
        if (_head == null) return false;
        if (v == _head.Value) return true;
        if (v > _head.Value) return _head.Higher.Contains(v);
        if (v < _head.Value) return _head.Lower.Contains(v);
        return false;
    }

    public bool Duplicates()
    {
        if(_head == null)
            return false;
        
        int? lastValue = null;
        return _head.Duplicates(ref lastValue);
    }

    public int Depth()
    {
        return _head?.Depth() ?? 0;
    }

    public bool IsBalanced => _head?.IsBalanced() ?? true;

    public override string ToString()
    {
        return _head == null ? "{}" : $"{{{_head}}}";
    }
}

public class BinaryTreeNode
{
    int _value;
    BinaryTreeNode _lower;
    BinaryTreeNode _higher;

    internal int Value => _value;
    internal BinaryTreeNode? Lower => _lower;
    internal BinaryTreeNode? Higher => _higher;

    internal BinaryTreeNode(int v)
    {
        _value = v;
        _lower = null;
        _higher = null;
    }
    internal BinaryTreeNode(int v, BinaryTreeNode? l, BinaryTreeNode? h) 
    {
        _value = v;
        _lower = l;
        _higher = h;
    }

    internal void Insert(int v)
    {
        if(v <= _value)
        {
            if (_lower == null)
                _lower = new BinaryTreeNode(v);
            else
                _lower.Insert(v);
        }
        if(v > _value)
        {
            if (_higher == null)
                _higher = new BinaryTreeNode(v);
            else
                _higher.Insert(v);
        }
    }

    internal bool Contains(int v)
    {
        if (v == _value) return true;
        if (v > _value && _higher != null) return _higher.Contains(v);
        else if (v < _value && _lower != null) return _lower.Contains(v);
        return false;
    }

    internal int Sum => _value + (_lower?.Sum ?? 0) +  (_higher?.Sum ?? 0);

    internal bool Duplicates(ref int? lastValue)
    {
        if (_lower != null && _lower.Duplicates(ref lastValue))
            return true;

        if (lastValue.HasValue && _value == lastValue.Value)
            return true;

        lastValue = _value;
        
        if (_higher != null && _higher.Duplicates(ref lastValue))
            return true;

        return false;
    }

    internal int Depth()
    {
        return 1 + Math.Max(_lower?.Depth() ?? 0, _lower?.Depth() ?? 0);
    }

    internal bool IsBalanced()
    {
        int lowerDepth = _lower?.Depth() ?? 0;
        int higherDepth = _higher?.Depth() ?? 0;

        return (_lower?.IsBalanced() ?? true) && (_higher?.IsBalanced() ?? true) && Math.Abs(lowerDepth-higherDepth) <= 1;
    }

    public override string ToString()
    {
        string left = _lower != null ? _lower + ", " : "";
        string right = _higher != null ? ", " + _higher : "";
        return $"{left}{_value}{right}";
    }
}