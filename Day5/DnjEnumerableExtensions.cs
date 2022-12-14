namespace Day5;

public static class DnjEnumerableExtensions
{
    public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self) => self.Select((item, index) => (item, index));
}