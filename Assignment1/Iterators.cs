namespace Assignment1;

public static class Iterators
{
    // can flatten


    public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items) 
    {
        foreach (var outer in items)
        {
            foreach (var inner in outer)
            {
                yield return inner;
            }
        }
    }

    public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate) 
    {
        foreach (var it in items)
        {
            if (predicate(it))
            {
                yield return it;
            } 
        }
    }
}