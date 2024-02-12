namespace FrontEnd.Helpers;

public class CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EnumKeyAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EnumValueAttribute : Attribute
    {
    }
}