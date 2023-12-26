using Google.Apis.Util;

namespace Binocs.Utilities
{
    public static class ListExtension
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            source.ThrowIfNull(nameof(source));
            action.ThrowIfNull(nameof(action));
            foreach (T element in source)
            {
                action(element);
            }
        }
    }
}
