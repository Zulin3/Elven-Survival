using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Decorator
{
    internal interface IAim
    {
        float Force { get; }
        GameObject AimInstance { get; }
    }
}
