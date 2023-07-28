using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Decorator
{
    internal class Aim : IAim
    {
        public float Force { get;  }
        public GameObject AimInstance { get; }

        public Aim(float force, GameObject aimInstance)
        {
            Force = force;
            AimInstance = aimInstance;
        }
    }
}
