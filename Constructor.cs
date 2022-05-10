class ConstructorData
{
    public ConstructorData()
    {
        Constructor = "";
        InnerConstructor = new ConstructorData();
    }
    public ConstructorData(string constructor)
    {
        Constructor = constructor;
        InnerConstructor = new ConstructorData();
    }
    public ConstructorData(string constructor, ConstructorData innerConstructor)
    {
        Constructor = constructor;
        InnerConstructor = innerConstructor;
    }
    public string Constructor { get; set; }
    public ConstructorData InnerConstructor { get; set; }
    public string Value { get => InnerConstructor == null ? Constructor : InnerConstructor.Value; }
}