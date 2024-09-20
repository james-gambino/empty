using Empty.Attributes.MetadataSchema;

public static class MetadataProcessor
{
    public static void Process<T>() where T : class, new()
    {
        var type = typeof(T);
        var attribute = type.GetCustomAttributes(typeof(ClassMetadataSchemaAttribute), false).FirstOrDefault() as ClassMetadataSchemaAttribute;

        if (attribute != null) {
            attribute.PrintProperties();
        }
        else {
            Console.WriteLine($"No ClassMetadataSchemaAttribute found on {type.Name}.");
        }
    }
    
    public static void Process(object instance)
    {
        Type type = instance.GetType();
        var attribute = type.GetCustomAttributes(typeof(ClassMetadataSchemaAttribute), false).FirstOrDefault() as ClassMetadataSchemaAttribute;

        if (attribute != null) {
            attribute.TakeSchema(instance); // Indent by 2 spaces
        }
        else {
            Console.WriteLine($"No ClassMetadataSchemaAttribute found on {type.Name}.");
        }
    }
}