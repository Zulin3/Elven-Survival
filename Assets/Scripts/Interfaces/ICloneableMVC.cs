using Assets.Scripts.GeneralClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    internal interface ICloneableMVC
    {
        public object Clone(Transform newView);
    }
}
