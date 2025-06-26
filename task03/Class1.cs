namespace task03;

using System.Collections;

public class CustomCollection<T> : IEnumerable<T>
{
    private readonly List<T> _items = new();

    public void Add(T item) => _items.Add(item);

    public void Remove(T item) => _items.Remove(item);

    public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerable<T> GetReverseEnumerator()
    {
        for (int i = 1; i <= _items.Count; ++i)
        {
            yield return _items[_items.Count - i];
        }
    }

    public static IEnumerable<int> GenerateSequence(int start, int count)
    {
        int end = start + count;
        for (int num = start; num < end; ++num)
        {
            yield return num;
        }
    }

    public IEnumerable<T> FilterAndSort(Func<T, bool> predicate, Func<T, IComparable> keySelector)
    {
        var filteredCollection = _items.Where(predicate);
        var sortedCollection = filteredCollection.OrderBy(keySelector);
        return sortedCollection;
    }


}
