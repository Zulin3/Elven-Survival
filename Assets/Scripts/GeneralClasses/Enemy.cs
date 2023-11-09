using Assets.Scripts.Interfaces;
using Assets.Scripts.MyLibraries;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    [Serializable] 
    internal abstract class Enemy : Unit
    {
        private Transform _target;
        private int _pointsReward;

        public Enemy(Transform view, IMove moveImplementation, IDamageable damageable, Transform target, BaseToucher touch, int pointsReward) : base(view, moveImplementation, damageable, touch)
        {
            _target = target;
            _pointsReward = pointsReward;
            OnDeath += RewardOnDeath;
        }

        public void Move(float deltaTime)
        {
            if (_target != null && _view != null)
            {
                Move(_target.position.x - _view.position.x, _target.position.y - _view.position.y, deltaTime);
                HandleCollisions();
            }
        }

        private void RewardOnDeath(object sender, EventArgs e)
        {
            var pointsService = ServiceLocator.Resolve<IPointsService>();
            pointsService.AddPoints(_pointsReward);
        }

        public override object Clone()
        {
            var clonedEnemy = (Enemy) base.Clone();
            clonedEnemy._target = _target;
            clonedEnemy._pointsReward = _pointsReward;
            clonedEnemy.OnDeath += RewardOnDeath;
            return clonedEnemy;
        }
    }
}