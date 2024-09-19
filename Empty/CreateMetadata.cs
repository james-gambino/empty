using System.Collections;
using System.Reflection;

namespace Empty;

public static class GenericBuilder
{
    // Метод для создания метаданных на основе экземпляра класса
    public static ClassMetadata CreateMetadata<T>(T instance)
    {
        var metadata = new ClassMetadata
        {
            ClassName = typeof(T).Name,
            Namespace = typeof(T).Namespace,
            Properties = new List<PropertyMetadata>(),
            NavigationProperties = new List<NavigationPropertyMetadata>(),
            FilterCriterias = new List<FilterCriteria>()
        };
        Console.WriteLine($"класс {metadata.ClassName} это навигационное свойство");
        foreach (var property in typeof(T).GetProperties())
        {
            var propertyValue = property.GetValue(instance);

            if (propertyValue != null) {
                var propertyMetadata = new PropertyMetadata
            {
                Key = 0, // ключ свойства (можно использовать порядковый номер)
                Name = property.Name,
                OriginalName = property.Name,
                Caption = property.Name, // описание
                Type = property.PropertyType.Name,
                Value = propertyValue,
            };

            metadata.Properties.Add(propertyMetadata);

            // Проверяем является ли свойство навигационным и добавляем его в NavigationProperties
            if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
            {
                Console.WriteLine($"{property.Name} это навигационное свойство");
                var navPropertyMetadata = new NavigationPropertyMetadata
                {
                    PropertyName = property.Name,
                    RelationshipType =
                        typeof(IList<>).IsAssignableFrom(property.PropertyType) ? "one-to-many" : "one-to-one",
                    ForeignKey =
                        $"{property.Name}Id", // Пример внешнего ключа, можно настроить по необходимости
                    IsCollection =
                        typeof(IList<>).IsAssignableFrom(property.PropertyType) // Установите true для коллекций
                };

                metadata.NavigationProperties.Add(navPropertyMetadata);

                // Рекурсивно создаем метаданные для связанных объектов
                if (propertyValue != null)
                {
                    Console.Write($" значение {propertyValue} ");
                    var relatedMetadata = CreateMetadata<object>(propertyValue);
                    metadata.NavigationProperties.Last().ClassMetadata = relatedMetadata;
                }
            }
            else if (typeof(IEnumerable<>).IsAssignableFrom(property.PropertyType))
            {
                var itemType = property.PropertyType.GenericTypeArguments[0];
                var collectionMetadata =
                    CreateMetadata<object>(Activator.CreateInstance(typeof(List<>).MakeGenericType(itemType)));

                var navPropertyMetadataCollection = new NavigationPropertyMetadata
                {
                    PropertyName = property.Name,
                    RelationshipType = "one-to-many",
                    ForeignKey = $"{property.Name}Id",
                    IsCollection = true,
                    ClassMetadata = collectionMetadata
                };

                metadata.NavigationProperties.Add(navPropertyMetadataCollection);
            }
            }
            Console.WriteLine($"свойство {property.Name} значение {propertyValue}");
        }

        return metadata;
    }

    private class CollectionMetadata<T> : ClassMetadata
    {
        public CollectionMetadata(object collection)
        {
            ClassName = typeof(T).Name;
            Namespace = typeof(T).Namespace;
            Properties = new List<PropertyMetadata>();

            var items = (IEnumerable)collection;
            var index = 0;

            foreach (var item in items)
            {
                var itemMetadata = CreateMetadata(item);
                Properties.AddRange(itemMetadata.Properties);
                index++;
            }
        }
    }
}