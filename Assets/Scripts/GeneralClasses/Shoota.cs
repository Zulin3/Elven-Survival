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
        private float _lastShootTime;
        private List<Projectile> _projectileList;
        private float _speed;
        private Vector2 _aim;
        private float _damage;
        private ProjectileType _type;
        private ScriptableObject _projectileData;
        private ColliderDictionary<IColliding> _projectileColliders;

        public Shoota(Transform view, ProjectileType type, List<Projectile> projectileList, ColliderDictionary<IColliding> projectileColliders)
        {
            _view = view;
            _projectileList = projectileList;
            _projectileColliders = projectileColliders;
            _type = type;
            switch (_type)
            {
                case ProjectileType.Arrow:
                    var arrowData = Resources.Load<ArrowData>("ScriptableObjects/ArrowData");
                    _reloadTime = arrowData.reloadTime;
                    _speed = arrowData.speed;
                    _damage = arrowData.damage;
                    _projectileData = arrowData;
                    
                    _prefab = new GameObjectBuilder().Visual().Sprite(arrowData.sprite).Name(arrowData.name).SetSize(arrowData.size).Physics().SphereCollider(arrowData.colliderRadius,arrowData.colliderPosition,true).SetLayer(PROJECTILE_LAYER);
                    _prefab.transform.SetParent(view);
                    _prefab.SetActive(false);
                    break;
                case ProjectileType.Trap:
                    var trapData = Resources.Load<TrapData>("ScriptableObjects/TrapData");
                    _reloadTime = trapData.reloadTime;
                    _damage = trapData.damage;
                    _projectileData = trapData;

                    _prefab = new GameObjectBuilder().Visual().Sprite(trapData.sprite).Name(trapData.name).SetSize(trapData.size).Physics().SphereCollider(trapData.colliderRadius, trapData.colliderPosition, true).SetLayer(PROJECTILE_LAYER);
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

                var viewServices = ServiceLocator.Resolve<IViewServices>();
                GameObject projectileObject = viewServices.Instantiate<GameObject>(_prefab);
                projectileObject.transform.position = _view.position;
                Collider projectileCollider = projectileObject.GetComponent<SphereCollider>();
                Projectile projectile;

                switch (_type)
                {
                    case ProjectileType.Arrow:
                        projectile = new Arrow(projectileObject.transform, _speed, ((ArrowData)_projectileData).collisions, _damage, _aim, _projectileList);
                        break;
                    case ProjectileType.Trap:
                        projectile = new Trap(projectileObject.transform, ((TrapData)_projectileData).collisions, _damage, _projectileList);
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

        public void SetAim(Vector2 aim)
        {
            _aim = aim;
        }

        public void SetWeaponStats(float damage, float speed, float reloadTime)
        {
            _damage = damage;
            _speed = speed;
            _reloadTime = reloadTime;
        }
    }
}
