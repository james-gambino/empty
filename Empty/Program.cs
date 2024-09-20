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
        
        MetadataProcessor.Process<Document>(); // Выведет в консоль структуру класса 
        // MetadataProcessor.Process(typeof(Document));
        MetadataProcessor.Process(document1); // Соберет метаданные
    }
}