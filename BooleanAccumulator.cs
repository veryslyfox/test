class BooleanAccumulator
{
     public BooleanAccumulator()
     {
          Value = true;
     }
     public BooleanAccumulator(bool value)
     {
          Value = value;
     }
     public BooleanAccumulator(bool value, object? equalityObject)
     {

          Value = value;
          EqualityObject = equalityObject;
     }

     public bool Value { get; private set; }

     public object? EqualityObject { get; set; }

     public void Or(bool value)
     {
          Value = Value || value;
     }
     public void And(bool value)
     {
          Value = Value && value;
     }
     public void Xor(bool value)
     {
          Value = Value != value;
     }
     public void EqualityOr(object value)
     {
          Value = Value || value == EqualityObject;
     }
     public void EqualityAnd(object value)
     {
          Value = Value && value == EqualityObject;
     }
     public void EqualityXor(object value)
     {
          Value = Value != (value == EqualityObject);
     }
     public void Not()
     {
          Value = !Value;
     }
     public override bool Equals(object? obj)
     {
          return obj is BooleanAccumulator accumulator &&
                 Value == accumulator.Value;
     }

     public override int GetHashCode()
     {
          return HashCode.Combine(Value);
     }
     public override string ToString()
     {
          if (Value)
          {
               return "true";
          }
          else
          {
               return "false";
          }
     }
}