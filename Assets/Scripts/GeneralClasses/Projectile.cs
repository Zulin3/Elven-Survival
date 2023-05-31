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
    public abstract class Projectile : MonoBehaviour, IMove, IDamaging
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
            set => _moveImplementation = value;
        }
        protected Transform _view;
        private int _collisions;
        public int Collisions
        {
            get => _collisions;
            set => _collisions = value;
        }

        private ViewServices _viewServices;
        public ViewServices ViewServices
        {
            get => _viewServices;
            set => _viewServices = value;
        }

        private List<Projectile> _projectileList;
        public List<Projectile> ProjectileList
        {
            get => _projectileList;
            set => _projectileList = value;
        }

        public Projectile(IMove moveImplementation = null, IDamaging damageImplementation = null)
        {
            _view = transform;
            _moveImplementation = moveImplementation;
            _damageImplementation = damageImplementation;
        }

        public void Move(float x, float y, float deltaTime)
        {
            _moveImplementation.Move(x, y, deltaTime);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            DealDamage(collision.gameObject.GetComponent<IDamageable>());
        }

        public void DealDamage(IDamageable target)
        {
            _collisions--;
            _damageImplementation.DealDamage(target);
            if (_collisions <= 0)
            {
                _projectileList.Remove(this);
                _viewServices.Destroy(gameObject);
            }
        }
    }
}
