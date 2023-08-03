using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MyLibraries
{
    public static partial class BuilderExtensions
    {
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T: Component
        {
            var result = gameObject.GetComponent<T>();
            if (result == null)
            {
                result = gameObject.AddComponent<T>();
            }
            return result;
        }
    }
}
