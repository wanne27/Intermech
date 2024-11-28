using System.Collections;

namespace Task4
{
    public class OrderedDictionaryCollection<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    where TKey : notnull
    where TValue : notnull
    {
        private List<TKey> keysList = new List<TKey>();
        private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

        public void Add(TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key) && keysList.Contains(key))
            {
                throw new Exception("The key already exists");
            }
            else
            {
                keysList.Add(key);
                dictionary.Add(key, value);
            }
        }

        public void Insert(int index, TKey key, TValue value)
        {
            if (keysList.Contains(key))
            {
                throw new Exception("Such a key already exists");
            }
            else
            {
                keysList.Insert(index, key);
                dictionary[key] = value;
            }
        }

        public TValue GetValueByKey(TKey key)
        {
            var value = dictionary[key];

            if (value == null)
            {
                throw new Exception("The key doesn't exist");
            }
            else
            {
                return value;
            }
        }

        public void Remove(TKey key)
        {
            if (key == null)
            {
                throw new Exception("Collection is Empty");
            }
            else
            {
                keysList.Remove(key);
                dictionary.Remove(key);
            }
        }    
        
        public void Update(TKey key, TValue value)
        {
            if (keysList.Contains(key))
            {
                dictionary[key] = value;
            }
            else
            {
                throw new Exception("The key doesn't exist");
            }
        }

        public KeyValuePair<TKey, TValue> GetByIndex(int index)
        {
            var key = keysList[index];

            if (key != null)
            {
                return new KeyValuePair<TKey, TValue>(key, dictionary[key]);
            }
            else
            {
                throw new Exception("The index doesn't exist");
            }
        }

        public bool Contains(TKey key)
        {
            return keysList.Contains(key);
        }

        public void Clear()
        {
            keysList.Clear();
            dictionary.Clear();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var key in keysList)
            {
                yield return new KeyValuePair<TKey, TValue>(key, dictionary[key]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return dictionary.GetEnumerator();
        }
    }
}
