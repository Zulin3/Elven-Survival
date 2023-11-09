using Assets.Scripts.Interfaces;
using Assets.Scripts.ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    internal sealed class MonsterDenFactory: IEnemyFactory
    {
        Transform _target;
        private float _maxHealth;
        private MonsterDenData _monsterDenData;
        private Enemy _enemyTemplate;
        public Enemy EnemyTemplate => _enemyTemplate;
        private ColliderDictionary<IColliding> _enemyColliders;
        private ColliderDictionary<IColliding> _projectileColliders;
        private List<Enemy> _enemyList;

        public MonsterDenFactory(Transform target, ColliderDictionary<IColliding> enemyColliders, ColliderDictionary<IColliding> projectileColliders, Enemy enemyTemplate, List<Enemy> enemyList)
        {
            _target = target;
            _monsterDenData = Resources.Load<MonsterDenData>("ScriptableObjects/MonsterDenData");
            _maxHealth = _monsterDenData.health;
            _enemyColliders = enemyColliders;
            _projectileColliders = projectileColliders;
            _enemyTemplate = enemyTemplate;
            _enemyList = enemyList;
            enemyList.Remove(enemyTemplate);
        }

        public Enemy Create(Vector3 position)
        {
            Enemy newEnemy = (Enemy) _enemyTemplate.Clone();
            var denObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/MonsterDen"), position, Quaternion.identity);
            denObject.transform.position = position;
            var denCollider = denObject.GetComponent<Collider>();
            var toucher = new SimpleSphereToucher(denObject.transform, _monsterDenData.colliderRadius, Constants.PROJECTILE_LAYER, _projectileColliders);
            MonsterDen den = new MonsterDen(denObject.transform, new MoveLinear(denObject.transform, 0), new DamageSimple(_maxHealth, denObject.transform), _target, toucher, _enemyList, _monsterDenData.spawnDelay, _monsterDenData.pointsReward);
            den.EnemyTemplate = newEnemy;
            toucher.BaseObject = den;
            _enemyList.Add(den);
            Debug.Log("Created den");
            den.StartSpawning();
            return den;
        }
    }
}
