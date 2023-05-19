using Assets.Scripts.Interfaces;
using UnityEngine;

public class Unit: IMove, IDamageable
{
    Transform _view;
    IMove _moveImplementation;
    IDamageable _damageImplementation;

    public Unit(Transform view, IMove moveImplementation, IDamageable damageable) 
    { 
        _view = view;
        _moveImplementation = moveImplementation;
        _damageImplementation = damageable;
    }

    public void Move(float x, float y, float deltaTime)
    {
        _moveImplementation.Move(x, y, deltaTime);
    }

    public void TakeDamage(float damage)
    {
        _damageImplementation.TakeDamage(damage);
    }

}