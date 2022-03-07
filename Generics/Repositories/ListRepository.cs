using Generics.Entities;

namespace Generics.Repositories;

public class ListRepository<T> : IRepository<T>
    where T : class, IEntity
{
    private readonly List<T?> _items = new();

    public IEnumerable<T?> GetAll()
    {
        return _items.ToList();
    }

    public T? GetById(int id)
    {
        return _items.Single(a => a.Id == id);
    }

    public void Add(T? item)
    {
        item.Id = _items.Count + 1;
        _items.Add(item);
    }

    public void Remove(T? item)
    {
        _items.Remove(item);
    }

    public void Save()
    {
        // Everything is saved already in the List<T>
    }
}