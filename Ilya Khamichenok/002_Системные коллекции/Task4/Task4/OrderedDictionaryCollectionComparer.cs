using System.Diagnostics.CodeAnalysis;

namespace Task4
{
    public class OrderedDictionaryCollectionComparer<TKey, TValue> : IEqualityComparer<OrderedDictionaryCollection<TKey, TValue>>
        where TKey : notnull
        where TValue : notnull
    {
        public bool Equals(OrderedDictionaryCollection<TKey, TValue>? colletion1, OrderedDictionaryCollection<TKey, TValue>? colletion2)
        {
            if (colletion1 is null || colletion2 is null)
            {
                return false;
            }                

            foreach (var keyValue1 in colletion1)
            {
                if(!colletion2.Contains(keyValue1.Key))
                {
                    return false;
                }
            }

            return true;
        }

        public int GetHashCode([DisallowNull] OrderedDictionaryCollection<TKey, TValue> obj)
        {
            return obj.GetHashCode();
        }
    }
}
