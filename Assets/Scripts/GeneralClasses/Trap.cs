using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    internal class Trap: Projectile
    {
        private float _angle = 0;
        public Trap(Transform view, int collisions, float damage, List<Projectile> projectileList) : base(view, projectileList, new MoveLinear(view, 0f), new DamagingOneTime(damage), collisions)
        {
        }

        public void Move(float deltaTime)
        {
        }
    }
}
