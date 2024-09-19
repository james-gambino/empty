using Empty.Attributes.MetadataSchema;

namespace Empty;

[ClassMetadataSchema(typeof(Document))]
public class Document 
{
    public int Id { get; set; }
    public string Version { get; set; }
    public string Name { get; set; }
    public Bank Bank { get; set; }
    public Person Seller { get; set; }
    // public Person Buyer { get; set; }
}

[ClassMetadataSchema(typeof(Bank))]
public class Bank
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Bik { get; set; }
    public string Inn { get; set; }
}

[ClassMetadataSchema(typeof(Person))]
public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Contacts Contacts { get; set; }
}

[ClassMetadataSchema(typeof(Contacts))]
public class Contacts
{
    public int Id { get; set; }
    public IList<Email> Emails { get; set; }
    public IList<Phone> Phones { get; set; }
}

[ClassMetadataSchema(typeof(Email))]
public class Email
{
    public int Id { get; set; }
    public string Value { get; set; }
}

[ClassMetadataSchema(typeof(Phone))]
public class Phone
{
    public int Id { get; set; }
    public string Value { get; set; }
}


