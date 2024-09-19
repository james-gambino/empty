using System.Text;

namespace Empty;
public class HqlQueryBuilder
{
    public string BuildQuery(ClassMetadata documentMeta)
    {
        var queryBuilder = new StringBuilder();
        
        queryBuilder.AppendLine("SELECT d");
        queryBuilder.AppendLine($"FROM {documentMeta.ClassName} d");

        // Добавляем навигационные свойства для JOIN
        foreach (var navProp in documentMeta.NavigationProperties)
        {
            queryBuilder.AppendLine($"LEFT JOIN d.{navProp.PropertyName} {navProp.PropertyName.ToLower()[0]}");
            if (navProp.IsCollection)
            {
                queryBuilder.AppendLine($"LEFT JOIN {navProp.PropertyName.ToLower()[0]}.{navProp.ClassMetadata.ClassName.ToLower()}");
            }
        }

        // Добавляем условия WHERE на основе FilterCriterias
        if (documentMeta.FilterCriterias.Any())
        {
            queryBuilder.AppendLine("WHERE");
            var conditions = new List<string>();
            foreach (var filter in documentMeta.FilterCriterias)
            {
                string condition = $"{filter.PropertyName} {filter.Operator} {FormatValue(filter.Value)}";
                conditions.Add(condition);
            }
            queryBuilder.AppendLine(string.Join(" AND ", conditions));
        }

        queryBuilder.AppendLine("GROUP BY d.Id");

        return queryBuilder.ToString();
    }

    private string FormatValue(object value)
    {
        // Форматируем значение для HQL-запроса
        if (value is string)
        {
            return $"'{value}'"; // Оборачиваем строковые значения в кавычки
        }
        return value.ToString(); // Для чисел возвращаем значение как есть
    }
}

