namespace Generics.Entities;

public class Employee : IEntity
{
    public int Id { get; set; }
    public string? FirstName { get; set; }

    public override string ToString() => $"Id: {Id}, FirstName: {FirstName}";
}