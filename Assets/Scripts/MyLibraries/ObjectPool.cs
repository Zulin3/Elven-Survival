using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MyLibraries
{
    internal sealed class ObjectPool : IDisposable
    {
        private readonly Stack<GameObject> _stack = new Stack<GameObject>();
        private readonly GameObject _prefab;
        private readonly Transform _root;

        public ObjectPool(GameObject prefab)
        {
            _prefab = prefab;
            _root = new GameObject($"[{_prefab.name}]").transform;
        }

        public GameObject Pop()
        {
            GameObject go;
            if (_stack.Count == 0)
            {
                go = UnityEngine.Object.Instantiate(_prefab);
                go.name = _prefab.name;
            }
            else
            {
                go = _stack.Pop();
            }
            go.SetActive(true);
            go.transform.SetParent(null);
            return go;
        }

        public void Push(GameObject go)
        {
            go.SetActive(false);
            go.transform.SetParent(_root);
            _stack.Push(go);
        }

        public void Dispose()
        {
            for (var i = 0; i < _stack.Count; i++)
            {
                var gameObject = _stack.Pop();
                UnityEngine.Object.Destroy(gameObject);
            }
            UnityEngine.Object.Destroy(_root.gameObject);
        }
    }
}
