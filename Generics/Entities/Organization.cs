namespace Generics.Entities;

public class Organization : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public override string ToString() => $"Id: {Id}, Name: {Name}";
}