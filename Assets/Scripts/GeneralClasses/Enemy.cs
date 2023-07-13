using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    [Serializable] 
    internal abstract class Enemy : Unit
    {
        Transform _target;
        public Enemy(Transform view, IMove moveImplementation, IDamageable damageable, Transform target, BaseToucher touch) : base(view, moveImplementation, damageable, touch)
        {
            _target = target;
        }

        public void Move(float deltaTime)
        {
            if (_target != null && _view != null)
            {
                Move(_target.position.x - _view.position.x, _target.position.y - _view.position.y, deltaTime);
                HandleCollisions();
            }
        }

        public override object Clone()
        {
            var clonedEnemy = (Enemy) base.Clone();
            clonedEnemy._target = _target;
            return clonedEnemy;
        }
    }
}