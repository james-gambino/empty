namespace Empty;

public class Document
{
    public int Id { get; set; }
    public string Version { get; set; }
    public string Name { get; set; }
    public Bank Bank { get; set; }
    // public Person Seller { get; set; }
    // public Person Buyer { get; set; }
}

public class Bank
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Bik { get; set; }
    public string Inn { get; set; }
}

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Contacts Contacts { get; set; }
}

public class Contacts
{
    public int Id { get; set; }
    public IList<Email> Emails { get; set; }
    public IList<Phone> Phones { get; set; }
}

public class Email
{
    public int Id { get; set; }
    public string Value { get; set; }
}

public class Phone
{
    public int Id { get; set; }
    public string Value { get; set; }
}


