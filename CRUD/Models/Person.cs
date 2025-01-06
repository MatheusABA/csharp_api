namespace CRUD.Models;

public class Person
{
    public Person(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        IsActive = true;
    }
    
    public Guid Id { get; init; }    // Guid -> Global Unique Identifier
    public string Name { get; private set; }
    public bool IsActive { get; set; }

    public void ChangeName(string name)
    {
        Name = name;
    }
    
    // Soft Delete
    public void ChangeIsActive(bool isActive)
    {
        IsActive = isActive;
    }
}