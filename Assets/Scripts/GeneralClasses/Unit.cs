using Assets.Scripts.Interfaces;
using Assets.Scripts.MyLibraries;
using System;
using System.Runtime.Serialization;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    [Serializable]
    internal abstract class Unit : IMove, IDamageable, ITouching, ICloneableMVC
    {
        protected Transform _view;
        private IMove _moveImplementation;
        private IDamageable _damageImplementation;
        protected ITouching _touchImplementation;

        public Transform View
        {
            get
            {
                return _view;
            }
            set
            {
                _view = value;
            }
        }

        public Unit(Transform view, IMove moveImplementation, IDamageable damageable, ITouching touchImplementation)
        {
            _view = view;
            _moveImplementation = moveImplementation;
            _damageImplementation = damageable;
            _touchImplementation = touchImplementation;
        }

        public event EventHandler OnDeath
        {
            add
            {
                _damageImplementation.OnDeath += value;
            }

            remove
            {
                _damageImplementation.OnDeath -= value;
            }
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

        public virtual object Clone()
        {
            var thisGameObject = _view.gameObject;
            var canvas = thisGameObject.transform.GetChild(0).gameObject;
            
            var copiedGameObject = thisGameObject.Copy();
            var canvasClone = GameObject.Instantiate(canvas,copiedGameObject.transform);
            canvasClone.name = "Canvas";

            return Clone(copiedGameObject.transform);
        }

        public object Clone(Transform newView)
        {
            var newUnit = MemberwiseClone() as Unit;
            newUnit._view = newView;
            if (_moveImplementation is MoveLinear)
            {
                newUnit._moveImplementation = ((MoveLinear)_moveImplementation).Clone(newView) as IMove;
            }
            newUnit._damageImplementation = _damageImplementation.Clone(newView) as IDamageable;
            newUnit._touchImplementation = _touchImplementation.Clone(newView) as ITouching;
            ((BaseToucher)newUnit._touchImplementation).BaseObject = newUnit;
            return newUnit;
        }
    }
}