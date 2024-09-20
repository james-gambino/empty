using Empty;

public class TableLayoutSchema
{
    public string Name { get; set; } // Название таблицы
    public string Model { get; set; } // Название модели Document
    public List<Field> Fields { get; set; } = new List<Field>(); // Список полей таблицы
    public List<Filter> Filters { get; set; } = new List<Filter>(); // Список фильтров для таблицы
    public List<Sort> Sorts { get; set; } = new List<Sort>(); // Список условий сортировки для таблицы
    public List<JoinCondition> JoinConditions { get; set; } = new List<JoinCondition>(); // Список условий объединения (JOIN) для таблицы
    public List<GlobalCondition> GlobalConditions { get; set; } = new List<GlobalCondition>(); // Список глобальных условий для таблицы
}

public class Field
{
    public string Name { get; set; } // Название поля
    public string Type { get; set; } // Тип данных поля
    public string Value { get; set; } // Значение поля
    public string Caption { get; set; } // Отображаемое значение
}

public class Filter
{
    public string Operator { get; set; } // Логический оператор для фильтра (AND/OR)  
    public List<FilterField> Fields { get; set; } = new List<FilterField>(); // Список полей фильтрации
}

public class FilterField
{
    public string Field { get; set; } // Название поля для фильтрации
    public string Comparison { get; set; } // Тип сравнения для фильтрации is not, >=, =
    public object Value { get; set; } // Значение для фильтрации
}

public class Sort
{
    public Field Field { get; set; } // Поле для сортировки
    public string Direction { get; set; } // Направление сортировки asc/desc
}

public class JoinCondition
{
    public string Model { get; set; } // Модель для объединения Bank
    public Dictionary<string, string> On { get; set; } = new Dictionary<string, string>(); // Условия объединения  BankId - Bank.Id
}

public class GlobalCondition
{
    public bool ActiveOnly { get; set; } // Условие на активные записи
}