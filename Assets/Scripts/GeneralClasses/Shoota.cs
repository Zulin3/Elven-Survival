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
using Assets.Scripts.enums;
using Assets.Scripts.Exceptions;

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
        private ProjectileType _type;

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

        public Shoota(Transform view, GameObject prefab, ProjectileType type, ViewServices viewServices, float reloadTime, List<Projectile> projectileList)
        {
            _view = view;
            _prefab = prefab;
            _viewServices = viewServices;
            _reloadTime = reloadTime;
            _projectileList = projectileList;
            _type = type;
        }

        public void Shoot(float now)
        {
            if (now > _lastShootTime + _reloadTime)
            {
                _lastShootTime = now;

                GameObject projectileObject = _viewServices.Instantiate<GameObject>(_prefab);
                projectileObject.transform.position = _view.position;
                Projectile projectile;

                switch (_type)
                {
                    case ProjectileType.Arrow:
                        projectile = new Arrow(projectileObject.transform, _speed, ARROW_COLLISIONS, _damage, _aim, _viewServices, _projectileList);
                        break;
                    default:
                        throw new InvalidProjectileTypeException();
                }

                _projectileList.Add(projectile);
            }
        }
    }
}
