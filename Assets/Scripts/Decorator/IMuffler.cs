using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Decorator
{
    internal interface IMuffler
    {
        AudioClip AudioClipMuffler { get; }
        float VolumeFireOnMuffler { get; }
        Transform BarrelPositionMuffler { get; }
        GameObject MufflerInstance { get; }
    }
}
