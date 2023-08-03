using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.DictionaryInspect
{

    [System.Serializable]
    public class SerializableDictionary<TKey, TValue> : ISerializationCallbackReceiver
    {
        [SerializeField]
        private List<TKey> keys = new List<TKey>();
        [SerializeField]
        private List<TValue> values = new List<TValue>();

        private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

        // Method to add a key-value pair to the dictionary
        public void Add(TKey key, TValue value)
        {
            if (!dictionary.ContainsKey(key))
            {
                keys.Add(key);
                values.Add(value);
                dictionary.Add(key, value);
            }
        }

        // Method to remove a key-value pair from the dictionary
        public void Remove(TKey key)
        {
            if (dictionary.ContainsKey(key))
            {
                int index = keys.IndexOf(key);
                keys.RemoveAt(index);
                values.RemoveAt(index);
                dictionary.Remove(key);
            }
        }

        // Method to get the value associated with a given key
        public bool TryGetValue(TKey key, out TValue value)
        {
            return dictionary.TryGetValue(key, out value);
        }

        // Method to implement ISerializationCallbackReceiver for custom serialization
        public void OnBeforeSerialize()
        {
            keys.Clear();
            values.Clear();

            foreach (var pair in dictionary)
            {
                keys.Add(pair.Key);
                values.Add(pair.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            dictionary.Clear();

            for (int i = 0; i < keys.Count; i++)
            {
                if (!dictionary.ContainsKey(keys[i]))
                {
                    dictionary.Add(keys[i], values[i]);
                }
            }
        }
    }
}
