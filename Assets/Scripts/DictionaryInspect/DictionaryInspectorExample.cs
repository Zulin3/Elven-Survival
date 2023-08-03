using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.DictionaryInspect
{
    internal class DictionaryInspectorExample: MonoBehaviour
    {
        [DictionaryInspect]
        public SerializableDictionary<string, string> dict = new SerializableDictionary<string, string>();

        public void Start()
        {
            dict.Add("1", "2");
            dict.Add("3", "4");
            dict.Add("5", "6");
        }

        public void Update() {
        }

    }
}
