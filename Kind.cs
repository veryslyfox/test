#pragma warning disable
global using System.Security.Cryptography;
using System;
using System.Collections.Generic;

interface IKind : IKind<object>
{
    IList<object> Values { get; }
    object Teacher { get; set; }
}

class Kind : IKind
{
    private IList<object> _values;
    private object _teacher;
    public Kind()
    {

    }
    public Kind(IList<object> values)
    {
        _values = values;
        Teacher = null;
    }
    public Kind(IList<object> values, object teacher)
    {
        _values = values;
        Teacher = null;
    }

    public IList<object> Values
    {
        get => _values;
    }
    public object Teacher { get => _teacher; set { _teacher = value; _values.Add(value); } }
}

interface IKind<TTeacher>
{
    IList<TTeacher> Values { get; }
    TTeacher Teacher { get; set; }
}

class Kind<TTeacher> : IKind<TTeacher>
{
    private IList<TTeacher> _values;
    private TTeacher _teacher;

    public Kind(IList<TTeacher> values)
    {
        _values = values;
        Teacher = default;
    }
    public Kind(IList<TTeacher> values, TTeacher current)
    {
        _values = values;
        Teacher = current;
    }
    public IList<TTeacher> Values
    {
        get => _values;
    }
    public TTeacher Teacher { get => _teacher; set { _teacher = value; _values.Add(value); } }

    public override bool Equals(object? obj)
    {
        return obj is Kind<TTeacher> kind &&
               Equals(_values, kind._values) &&
               Equals(_teacher, kind._teacher) &&
               Equals(Values, kind.Values) &&
               Equals(Teacher, kind.Teacher);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_values, _teacher);
    }
}