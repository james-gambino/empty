using Empty.Helpers;

namespace Empty.Attributes.MetadataSchema;

[AttributeUsage(AttributeTargets.Class)]
public class ClassMetadataSchemaAttribute(Type classType) : Attribute, IClassMetadata
{
    private Type _classType = classType;

    public void TakeSchema()
    {
        // var result = ClassMetadataSchemaHelper.TakeSchema(this._instance);
    }

    public void PrintProperties()
    {
        ClassMetadataSchemaHelper.PrintProperties(_classType, 0);
    }
}