using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    internal sealed class Fox : Enemy
    {
        public Fox(Transform view, IMove moveImplementation, IDamageable damageable, Transform target) : base(view, moveImplementation, damageable, target)
        {
        }
    }
}