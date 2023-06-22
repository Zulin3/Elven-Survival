using Assets.Scripts.Interfaces;
using Assets.Scripts.MyLibraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    internal abstract class Projectile : IMove, IDamaging, IColliding
    {
        private IMove _moveImplementation;
        private IDamaging _damageImplementation;
        public IDamaging DamageImplementation
        {
            get => _damageImplementation;
            set => _damageImplementation = value;
        }
        public IMove MoveImplementation {
            get => _moveImplementation;
            private set => _moveImplementation = value;
        }
        protected Transform _view;
        private int _collisions;

        private ViewServices _viewServices;

        private List<Projectile> _projectileList;

        public Projectile(Transform transform, ViewServices viewServices, List<Projectile> projectileList, IMove moveImplementation, IDamaging damageImplementation, int collisions)
        {
            _view = transform;
            _moveImplementation = moveImplementation;
            _damageImplementation = damageImplementation;
            _viewServices = viewServices;
            _projectileList = projectileList;
            _collisions = collisions;
        }

        public void Move(float x, float y, float deltaTime)
        {
            _moveImplementation.Move(x, y, deltaTime);
        }

        public void DealDamage(IDamageable target)
        {
            _collisions--;
            _damageImplementation.DealDamage(target);
            if (_collisions <= 0)
            {
                _projectileList.Remove(this);
                _viewServices.Destroy(_view.gameObject);
            }
        }

        public void handleCollision(ITouching target)
        {
            if (target is IDamageable damageableTarget)
            {
                DealDamage(damageableTarget);
            }
        }
    }
}
