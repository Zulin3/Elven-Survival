using Assets.Scripts.Interfaces;
using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    internal class BirdFactory : IEnemyFactory
    {
        Transform _target;
        private float _acceleration;
        private float _maxHealth;
        private BirdEnemyData _birdEnemyData;
        private ColliderDictionary<IColliding> _enemyColliders;
        private ColliderDictionary<IColliding> _projectileColliders;
        private List<Enemy> _enemyList;

        public BirdFactory(Transform target, ColliderDictionary<IColliding> enemyColliders, ColliderDictionary<IColliding> projectileColliders, List<Enemy> enemyList)
        {
            _target = target;
            _birdEnemyData = Resources.Load<BirdEnemyData>("ScriptableObjects/BirdEnemyData");
            _acceleration = _birdEnemyData.acceleration;
            _maxHealth = _birdEnemyData.health;
            _enemyColliders = enemyColliders;
            _projectileColliders = projectileColliders;
            _enemyList = enemyList;
        }

        public Enemy Create(Vector3 position)
        {
            var birdObject = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("Prefabs/Birdy"), position, Quaternion.identity);
            birdObject.transform.position = new Vector3(position.x, position.y, _birdEnemyData.renderLayer);
            var birdCollider = birdObject.GetComponent<Collider>();
            var toucher = new SimpleSphereToucher(birdObject.transform, _birdEnemyData.colliderRadius, Constants.PROJECTILE_LAYER, _projectileColliders);
            Bird bird = new Bird(birdObject.transform, new MoveAccelerated(birdObject.transform, _acceleration), new DamageSimple(_maxHealth, birdObject.transform), _target, toucher);
            toucher.BaseObject = bird;
            _enemyList.Add(bird);
            //_enemyColliders.Add(birdCollider, bird);
            return bird;
        }
    }
}
