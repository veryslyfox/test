using System.Reflection;
#pragma warning disable 
class ReflectData
{
    public ReflectData(Type type)
    {
        Fields = type.GetFields();
        Properties = type.GetProperties();
        Methods = type.GetMethods();
    }

    public ReflectData(FieldInfo[] fields = null, PropertyInfo[] properties = null,
    MethodInfo[] methods = null, ConstructorInfo[] constructors = null, EventInfo[] events = null)
    {

        Fields = fields;
        Properties = properties;
        Methods = methods;
        Constructors = constructors;
        Events = events;
    }
    public FieldInfo[] Fields { get; set; }
    public PropertyInfo[] Properties { get; set; }
    public MethodInfo[] Methods { get; set; }
    public ConstructorInfo[] Constructors { get; set; }
    public EventInfo[] Events { get; set; }
}