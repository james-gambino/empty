namespace Empty.Attributes.MetadataSchema;

// Класс для описания связей между классами
public class NavigationPropertyMetadata
{
    public ClassMetadata ClassMetadata { get; set; } // Ссылка на класс
    public string PropertyName { get; set; } // Имя свойства или поля
    public string RelationshipType { get; set; } // Тип связи (например, many-to-one) "one-to-one", "one-to-many", "many-to-one"
    public string ForeignKey { get; set; } // Имя внешнего ключа (если применимо)
    public bool IsCollection { get; set; } // Является ли свойсво коллекцией или нет
}