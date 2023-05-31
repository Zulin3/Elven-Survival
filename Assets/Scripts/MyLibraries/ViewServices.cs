using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MyLibraries
{
    public class ViewServices : IViewServices
    {
        private const int DefaultPoolSize = 10;
        private readonly Dictionary<string, ObjectPool> _viewCache = new Dictionary<string, ObjectPool>(DefaultPoolSize);

        public T Instantiate<T>(GameObject prefab)
        {
            if (!_viewCache.TryGetValue(prefab.name, out ObjectPool viewPool))
            {
                viewPool = new ObjectPool(prefab);
                _viewCache.Add(prefab.name, viewPool);
            }

            if (viewPool.Pop().TryGetComponent(out T component))
            {
                return component;
            }

            throw new InvalidOperationException($"{typeof(T)} not found");
        }

        public void Destroy(GameObject value)
        {
            _viewCache[value.name].Push(value);
        }
    }
}
