namespace Empty.Attributes.MetadataSchema;

// Структура для описания метаданных свойства или поля
public class PropertyMetadata
{
    public int Key { get; set; } // Ключ свойства или поля
    public string Name { get; set; } // Имя свойства или поля
    public string OriginalName { get; set; } // Исходное имя свойства
    public string Caption { get; set; } // Отображаемое описание
    public string Type { get; set; } // Тип свойства или поля
    public object Value { get; set; } // Значение свойства или поля
    public bool IsRequired { get; set; } // Является ли свойство обязательным
    public string Range { get; set; } // Диапазон значений (если применимо)
}