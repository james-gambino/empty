namespace Empty.Attributes.MetadataSchema;

// Основной класс для хранения метаданных о классе
public class ClassMetadata
{
    public string ClassName { get; set; } // Имя класса
    public string Namespace { get; set; } // Пространство имен
    public List<PropertyMetadata> Properties { get; set; } // Список свойств
    public List<NavigationPropertyMetadata> NavigationProperties { get; set; } // Список связей
}