using Assets.Scripts.Interfaces;
using System;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    [Serializable]
    internal sealed class Fox : Enemy
    {
        public Fox(Transform view, IMove moveImplementation, IDamageable damageable, Transform target, SimpleSphereToucher touch, int pointsReward) : base(view, moveImplementation, damageable, target, touch, pointsReward)
        {
        }
    }
}