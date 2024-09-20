namespace Empty.Attributes.MetadataSchema;

// Структура для описания метаданных свойства или поля
public class PropertyMetadata
{
    public int Key { get; set; } // Ключ свойства или поля
    public string Name { get; set; } // Имя свойства или поля
    public string OriginalName { get; set; } // Исходное имя свойства
    public string Type { get; set; } // Тип свойства или поля
}