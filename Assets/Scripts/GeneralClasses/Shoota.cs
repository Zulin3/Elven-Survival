using Assets.Scripts.MyLibraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Interfaces;
using UnityEngine;
using System.Runtime.CompilerServices;
using static Assets.Scripts.GeneralClasses.Constants;

namespace Assets.Scripts.GeneralClasses
{
    internal sealed class Shoota: IShoota
    {
        private Transform _view;
        private GameObject _prefab;
        private float _reloadTime;
        private ViewServices _viewServices;
        private float _lastShootTime;
        private List<Projectile> _projectileList;
        private float _speed;
        private Vector2 _aim;
        private float _damage;

        public float Damage
        {
            get => _damage;
            set => _damage = value;
        }

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }
        public Vector2 Aim 
        { 
            get => _aim; 
            set => _aim = value; 
        }

        public Shoota(Transform view, GameObject prefab, ViewServices viewServices, float reloadTime, List<Projectile> projectileList)
        {
            _view = view;
            _prefab = prefab;
            _viewServices = viewServices;
            _reloadTime = reloadTime;
            _projectileList = projectileList;
        }

        public void Shoot(float now)
        {
            if (now > _lastShootTime + _reloadTime)
            {
                _lastShootTime = now;
                Projectile projectile = _viewServices.Instantiate<Projectile>(_prefab);
                projectile.transform.position = _view.position;
                projectile.ViewServices = _viewServices;
                projectile.ProjectileList = _projectileList;
                if (projectile is Arrow)
                {
                    projectile.Collisions = ARROW_COLLISIONS;
                    ((Arrow)projectile).Rotate(_aim);
                    if (projectile.MoveImplementation == null)
                    {
                        projectile.MoveImplementation = new MoveLinear(projectile.transform, _speed);
                    }
                    if (projectile.DamageImplementation == null)
                    {
                        projectile.DamageImplementation = new DamagingOneTime(_damage);
                    }
                }
                _projectileList.Add(projectile);
            }
        }
    }
}
