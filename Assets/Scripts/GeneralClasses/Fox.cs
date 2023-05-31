using Assets.Scripts.Interfaces;
using UnityEngine;

public class Fox : Enemy
{
    public Fox(Transform view, IMove moveImplementation, IDamageable damageable, Transform target) : base(view, moveImplementation, damageable, target)
    {
    }
}