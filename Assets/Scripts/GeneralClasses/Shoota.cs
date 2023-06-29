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
using Assets.Scripts.ScriptableObjects;

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
        private ScriptableObject _projectileData;
        private ColliderDictionary<IColliding> _projectileColliders;

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

        public Shoota(Transform view, ProjectileType type, ViewServices viewServices, float reloadTime, List<Projectile> projectileList, ColliderDictionary<IColliding> projectileColliders)
        {
            _view = view;
            _viewServices = viewServices;
            _reloadTime = reloadTime;
            _projectileList = projectileList;
            _projectileColliders = projectileColliders;
            _type = type;
            switch (_type)
            {
                case ProjectileType.Arrow:
                    var projectileData = Resources.Load<ArrowData>("ScriptableObjects/ArrowData");
                    _speed = projectileData.speed;
                    _damage = projectileData.damage;
                    _projectileData = projectileData;
                    
                    _prefab = new GameObjectBuilder().Visual().Sprite(projectileData.sprite).Name(projectileData.name).SetSize(projectileData.size).Physics().SphereCollider(projectileData.colliderRadius,projectileData.colliderPosition,true).SetLayer(PROJECTILE_LAYER);
                    _prefab.transform.SetParent(view);
                    _prefab.SetActive(false);
                    break;
                default:
                    throw new InvalidProjectileTypeException();
            }
        }

        public void Shoot(float now)
        {
            if (now > _lastShootTime + _reloadTime)
            {
                _lastShootTime = now;

                GameObject projectileObject = _viewServices.Instantiate<GameObject>(_prefab);
                projectileObject.transform.position = _view.position;
                Collider projectileCollider = projectileObject.GetComponent<SphereCollider>();
                Projectile projectile;

                switch (_type)
                {
                    case ProjectileType.Arrow:
                        projectile = new Arrow(projectileObject.transform, _speed, ((ArrowData)_projectileData).collisions, _damage, _aim, _viewServices, _projectileList);
                        break;
                    default:
                        throw new InvalidProjectileTypeException();
                }

                _projectileList.Add(projectile);
                if (_projectileColliders.Contains(projectileCollider))
                {
                    _projectileColliders.Remove(projectileCollider);
                }
                _projectileColliders.Add(projectileCollider, projectile);
            }
        }
    }
}
