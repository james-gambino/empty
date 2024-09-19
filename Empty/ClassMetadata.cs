namespace Empty;


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

// Класс для описания связей между классами
public class NavigationPropertyMetadata
{
    public ClassMetadata ClassMetadata { get; set; } // Ссылка на класс
    public string PropertyName { get; set; } // Имя свойства или поля
    public string RelationshipType { get; set; } // Тип связи (например, many-to-one) "one-to-one", "one-to-many", "many-to-one"
    public string ForeignKey { get; set; } // Имя внешнего ключа (если применимо)
    public bool IsCollection { get; set; } // Является ли свойсво коллекцией или нет
}

// Основной класс для хранения метаданных о классе
public class ClassMetadata
{
    public string ClassName { get; set; } // Имя класса
    public string Namespace { get; set; } // Пространство имен
    public List<PropertyMetadata> Properties { get; set; } // Список свойств
    public List<NavigationPropertyMetadata> NavigationProperties { get; set; } // Список связей
    public List<FilterCriteria> FilterCriterias { get; set; } // Список фильтров
}

// Класс для фильтров выборки данных
public class FilterCriteria
{
    public string PropertyName { get; set; } // Имя свойства для фильтрации
    public string Operator { get; set; } // Оператор сравнения (например, =, >, LIKE)
    public object Value { get; set; } // Значение для сравнения
}