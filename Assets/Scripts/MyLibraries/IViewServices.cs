using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MyLibraries
{
    internal interface IViewServices
    {
        public T Instantiate<T>(GameObject prefab) where T: class;
        public void Destroy(GameObject value);

    }
}
