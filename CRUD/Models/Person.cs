namespace CRUD.Models;

public class Person
{
    public Person(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
    
    public Guid Id { get; init; }    // Guid -> Global Unique Identifier
    public string Name { get; private set; }
    
}