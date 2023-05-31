using Assets.Scripts.GeneralClasses;
using Assets.Scripts.Interfaces;
using UnityEngine;

public class FoxFactory : IEnemyFactory
{
    Transform _target;
    // FoxFactory решает, какая скорость будет у лисы, какой урон она наносит и т.д.
    const float _speed = Constants.ENEMY_FOX_SPEED;
    const float _maxHealth = Constants.ENEMY_FOX_HEALTH;

    public FoxFactory(Transform target)
    {
        _target = target;
    }

    public Enemy Create(Vector3 position)
    {
        var fox = Object.Instantiate(Resources.Load<Fox>("Foxy"), position, Quaternion.identity);
        fox.init(fox.transform, new MoveLinear(fox.transform, _speed), new DamageSimple(_maxHealth, fox.transform));
        fox.transform.position = position;
        fox.SetTarget(_target);
        return fox;
    }
}