using Assets.Scripts.Interfaces;
using UnityEngine;

public abstract class Enemy : Unit
{
    Transform _target;
    public Enemy(Transform view, IMove moveImplementation, IDamageable damageable, Transform target) : base(view, moveImplementation, damageable)
    {
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void Move(float deltaTime)
    {
        if (_target != null && _view != null)
        {
            Move(_target.position.x - _view.position.x, _target.position.y - _view.position.y, deltaTime);
        }
    }

}
