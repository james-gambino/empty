using Empty.Attributes.MetadataSchema;

public static class MetadataProcessor
{
    public static void Process<T>() where T : class, new()
    {
        var type = typeof(T);
        var attribute = type.GetCustomAttributes(typeof(ClassMetadataSchemaAttribute), false).FirstOrDefault() as ClassMetadataSchemaAttribute;

        if (attribute != null)
        {
            // Call PrintProperties method on the instance
            attribute.PrintProperties(); // Indent by 2 spaces
        }
        else
        {
            Console.WriteLine($"No ClassMetadataSchemaAttribute found on {type.Name}.");
        }
    }
}