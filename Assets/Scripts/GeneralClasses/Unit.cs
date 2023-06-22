using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    internal abstract class Unit: IMove, IDamageable, ITouching
    {
        protected Transform _view;
        private IMove _moveImplementation;
        private IDamageable _damageImplementation;
        protected ITouching _touchImplementation;

        public Unit(Transform view, IMove moveImplementation, IDamageable damageable, ITouching touchImplementation)
        {
            _view = view;
            _moveImplementation = moveImplementation;
            _damageImplementation = damageable;
            _touchImplementation = touchImplementation;
        }

        public Collider[] GetColliders()
        {
            return _touchImplementation.GetColliders();
        }

        public void Move(float x, float y, float deltaTime)
        {
            _moveImplementation.Move(x, y, deltaTime);
        }

        public void TakeDamage(float damage)
        {
            _damageImplementation.TakeDamage(damage);
        }

        public void HandleCollisions()
        {
            _touchImplementation.HandleCollisions();
        }
    }
}