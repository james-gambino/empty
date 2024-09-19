`ClassMetadata` будет содержать следующую информацию:
- `ClassName`: Имя класса (`"Document"`)
- `Namespace`: Пространство имен (`"PA.Domains"`)
- `Properties`: Список свойств (`"List<PropertyMetadata>"`)
- `NavigationProperties`: Список связей (`"List<NavigationPropertyMetadata>"`)

`PropertyMetadata` Структура для описания метаданных свойства или поля:
- `Key`: ключ свойства или поля
- `Name`: имя свойства или поля (`"Inn2"`)
- `OriginalName`: Исходное имя свойства (`"Inn"`)
- `Caption`: Отображаемое описание (`"ИНН"`)
- `Type`: Тип свойства или поля  (`"string"`, `"int"`, `"IList<Email>"`)
- `Value`: Значение свойства или поля (`"7741028801"`)


`NavigationPropertyMetadata` Класс для описания связей между классами:
- `ClassMetadata`: Ссылка на класс (`"Bank"`)
- `PropertyName`: Имя целевого свойства (`"Bank"`)
- `RelationshipType`: Тип связи (`"many-to-one"`)
- `IsCollection`: Тип связи (`"false"`)
- `ForeignKey`: Имя внешнего ключа (если применимо) (`"BankId"`)


`FilterCriteria` Класс для фильтров выборки данных:
- `PropertyName`: Имя свойства для фильтрации (`"Inn"`)
- `Operator`: Оператор сравнения (например, =, >, LIKE) (`"BETWEEN"`)
- `Value`: Значение для сравнения (`"10 AND 15"`)


Сгенерированный HQL запрос:
- `SELECT d
  FROM Document d
  LEFT JOIN d.Bank b
  WHERE
  Name = 'Document Title 1'
  GROUP BY d.Id`

