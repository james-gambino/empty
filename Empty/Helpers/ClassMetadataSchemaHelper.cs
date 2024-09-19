using System.Collections;
using System.Reflection;

namespace Empty.Helpers;

public static class ClassMetadataSchemaHelper
{
    public static ClassMetadata TakeSchema(object instance)
    {
        Type objType = instance.GetType();
        PropertyInfo[] properties = objType.GetProperties();
        
        var metadata = new ClassMetadata {
            ClassName = objType.Name,
            Namespace = objType.Namespace,
            Properties = new List<PropertyMetadata>(),
            NavigationProperties = new List<NavigationPropertyMetadata>(),
            FilterCriterias = new List<FilterCriteria>()
        };
        
        foreach (PropertyInfo property in properties) {
            object propertyValue = property.GetValue(instance, null);
            if (propertyValue != null) {
                var propertyMetadata = new PropertyMetadata
                {
                    Key = 0, // ключ свойства (можно использовать порядковый номер)
                    Name = property.Name,
                    OriginalName = property.Name,
                    Caption = property.Name, // описание
                    Type = property.PropertyType.Name,
                    Value = propertyValue ?? null,
                };

                metadata.Properties.Add(propertyMetadata);
            }
            
            if (property.PropertyType.IsClass && property.PropertyType != typeof(string)) {
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
                if (propertyValue != null) {
                    var relatedMetadata = TakeSchema(propertyValue);
                    metadata.NavigationProperties.Last().ClassMetadata = relatedMetadata;
                }
            }
            
            else if (typeof(IEnumerable<>).IsAssignableFrom(property.PropertyType))
            {
                var itemType = property.PropertyType.GenericTypeArguments[0];
                var collectionMetadata =
                    TakeSchema(Activator.CreateInstance(typeof(List<>).MakeGenericType(itemType))); // CollectionMetadata

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
        
        return metadata;
    }
    
    public static void PrintProperties(Type objType, int indent)
    {
        if (objType == null) return;

        string indentString = new string(' ', indent);
        PropertyInfo[] properties = objType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (PropertyInfo property in properties)
        {
             
            Console.WriteLine("{0}{1}:", indentString, property.Name);

            // Check if the property is a collection
            if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType) && property.PropertyType != typeof(string))
            {
                // If it's a collection, we can display its type but not its elements since we don't have an instance
                Console.WriteLine("{0}  Type: {1}", indentString, property.PropertyType.Name);
            }
            else if (property.PropertyType.IsClass && property.PropertyType.Assembly == objType.Assembly)
            {
                // If it's a class from the same assembly, recursively print its properties
                PrintProperties(property.PropertyType, indent + 2);
            }
            else
            {
                // For primitive types or other types, display a placeholder for value
                Console.WriteLine("{0}  Type: {1}", indentString, property.PropertyType.Name);
            }
        }
    }
}