namespace Empty.Attributes.MetadataSchema;

public interface IClassMetadata
{
    void TakeSchema(object instance);
    void PrintProperties();
}
