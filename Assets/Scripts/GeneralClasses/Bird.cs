using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    internal class Bird : Enemy
    {
        public Bird(Transform view, IMove moveImplementation, IDamageable damageable, Transform target, SimpleSphereToucher touch, int pointsReward) : base(view, moveImplementation, damageable, target, touch, pointsReward)
        {
        }
    }
}
