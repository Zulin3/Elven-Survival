using Assets.Scripts.GeneralClasses;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    internal sealed class FoxFactory : IEnemyFactory
    {
        Transform _target;
        // FoxFactory решает, какая скорость будет у лисы, какой урон она наносит и т.д.
        private const float _speed = Constants.ENEMY_FOX_SPEED;
        private const float _maxHealth = Constants.ENEMY_FOX_HEALTH;

        public FoxFactory(Transform target)
        {
            _target = target;
        }

        public Enemy Create(Vector3 position)
        {
            var foxObject = Object.Instantiate(Resources.Load<GameObject>("Foxy"), position, Quaternion.identity);
            foxObject.transform.position = position;
            Fox fox = new Fox(foxObject.transform, new MoveLinear(foxObject.transform, _speed), new DamageSimple(_maxHealth, foxObject.transform), _target);
            return fox;
        }
    }
}