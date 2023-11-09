using Assets.Scripts.GeneralClasses;
using Assets.Scripts.Interfaces;
using Assets.Scripts.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    internal sealed class FoxFactory : IEnemyFactory
    {
        Transform _target;
        // FoxFactory решает, какая скорость будет у лисы, какой урон она наносит и т.д.
        private float _speed;
        private float _maxHealth;
        private FoxEnemyData _foxEnemyData;
        private ColliderDictionary<IColliding> _enemyColliders;
        private ColliderDictionary<IColliding> _projectileColliders;
        private List<Enemy> _enemyList;

        public FoxFactory(Transform target, ColliderDictionary<IColliding> enemyColliders, ColliderDictionary<IColliding> projectileColliders, List<Enemy> enemyList)
        {
            _target = target;
            _foxEnemyData = Resources.Load<FoxEnemyData>("ScriptableObjects/FoxEnemyData");
            _speed = _foxEnemyData.speed;
            _maxHealth = _foxEnemyData.health;
            _enemyColliders = enemyColliders;
            _projectileColliders = projectileColliders;
            _enemyList = enemyList;
        }

        public Enemy Create(Vector3 position)
        {
            var foxObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Foxy"), position, Quaternion.identity);
            foxObject.transform.position = position;
            var foxCollider = foxObject.GetComponent<Collider>();
            var toucher = new SimpleSphereToucher(foxObject.transform, _foxEnemyData.colliderRadius, Constants.PROJECTILE_LAYER, _projectileColliders);
            Fox fox = new Fox(foxObject.transform, new MoveLinear(foxObject.transform, _speed), new DamageSimple(_maxHealth, foxObject.transform), _target, toucher, _foxEnemyData.pointsReward);
            toucher.BaseObject = fox;
            _enemyList.Add(fox);
            //_enemyColliders.Add(foxCollider, fox);
            return fox;
        }
    }
}