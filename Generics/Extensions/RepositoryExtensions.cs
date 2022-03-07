using Generics.Repositories;

namespace Generics.Extensions;

public static class RepositoryExtensions
{
    public static void AddBatch<T>(this IWriteRepository<T?> repository, IEnumerable<T?> items)
    {
        foreach (var item in items)
        {
            repository.Add(item);
        }
        repository.Save();
    }
}