using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IShoota
    {
        void Shoot(float now);
        public float Speed { get; set; }
        public Vector2 Aim { get; set; }
    }
}
