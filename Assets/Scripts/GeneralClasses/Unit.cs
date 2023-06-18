using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    internal abstract class Unit : MonoBehaviour, IMove, IDamageable
    {
        protected Transform _view;
        private IMove _moveImplementation;
        private IDamageable _damageImplementation;

        public Unit(Transform view, IMove moveImplementation, IDamageable damageable)
        {
            _view = view;
            _moveImplementation = moveImplementation;
            _damageImplementation = damageable;
        }

        public void init(Transform view, IMove moveImplementation, IDamageable damageable)
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
}