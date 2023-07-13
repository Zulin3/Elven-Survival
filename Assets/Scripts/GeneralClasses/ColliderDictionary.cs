using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    internal sealed class ColliderDictionary<T>
    {
        private Dictionary<Collider, T> _colliderDictionary = new Dictionary<Collider, T>();

        public void Add(Collider collider, T value)
        {
            _colliderDictionary.Add(collider, value);
        }

        public void Remove(Collider collider)
        {
            _colliderDictionary.Remove(collider);
        }

        public T GetValue(Collider collider)
        {
            return _colliderDictionary[collider];
        }

        public bool Contains(Collider collider)
        {
            return _colliderDictionary.ContainsKey(collider);
        }

        public void Clear()
        {
            _colliderDictionary.Clear();
        }

    }
}
