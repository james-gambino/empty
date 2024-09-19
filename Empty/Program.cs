// See https://aka.ms/new-console-template for more information

using Empty;
using Empty.Helpers;

internal class Program
{
    public static void Main(string[] args)
    {
        var document1 = new Document {
            Id = 1,
            Version = "1.0",
            Name = "Document Title 1",
            Bank = new Bank { Id = 1, Name = "Bank Name", Bik = "123456789", Inn = "987654321" },
        };
        
        // Seller = new Person { Id = 1, Name = "Seller Name", Contacts = new Contacts { Id = 1, Emails = new List<Email> { new Email { Id = 1, Value = "seller@gmail.com" } }, Phones = new List<Phone> { new Phone { Id = 1, Value = "+123456789" } } } },
        // Buyer = new Person { Id = 1, Name = "Buyer Name", Contacts = new Contacts { Id = 2, Emails = new List<Email> { new Email { Id = 2, Value = "buyer@example.com" } }, Phones = new List<Phone> { new Phone { Id = 2, Value = "+987654321" } } } },
        
        // Генерация Метаданных на основе экземпляра класса
        // var documentMetadata = GenericBuilder.CreateMetadata(document1);
        // documentMetadata.FilterCriterias.Add(new FilterCriteria {
        //     PropertyName = nameof(Document.Name),
        //     Operator = "=",
        //     Value = "Document Title 1"
        // });
        //
        //
        // // Генерация HQL-запроса на основе метаданных и фильтров
        // HqlQueryBuilder hqlQueryBuilder = new HqlQueryBuilder();
        // string hqlQueryResult = hqlQueryBuilder.BuildQuery(documentMetadata);
        //
        // // Пример вывода информации о метаданных документа и HQL-запроса
        // Console.WriteLine("Сгенерированный HQL запрос:");
        // Console.WriteLine(hqlQueryResult);
        //
        // GenericBuilder.PrintProperties(typeof(Document), 0);
        
        // var snapshots = ClassMetadataSchemaHelper.TakeSchema(document1);
        
        MetadataProcessor.Process<Document>();
        MetadataProcessor.Process<Document>(document1);
        
    }
}