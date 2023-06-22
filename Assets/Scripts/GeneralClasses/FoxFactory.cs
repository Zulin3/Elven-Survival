using Assets.Scripts.GeneralClasses;
using Assets.Scripts.Interfaces;
using Assets.Scripts.ScriptableObjects;
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

        public FoxFactory(Transform target, ColliderDictionary<IColliding> enemyColliders, ColliderDictionary<IColliding> projectileColliders)
        {
            _target = target;
            _foxEnemyData = Resources.Load<FoxEnemyData>("ScriptableObjects/FoxEnemyData");
            _speed = _foxEnemyData.speed;
            _maxHealth = _foxEnemyData.health;
            _enemyColliders = enemyColliders;
            _projectileColliders = projectileColliders;
        }

        public Enemy Create(Vector3 position)
        {
            var foxObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Foxy"), position, Quaternion.identity);
            foxObject.transform.position = position;
            var foxCollider = foxObject.GetComponent<Collider>();
            var toucher = new SimpleSphereToucher(foxObject.transform, 0.5f, Constants.PROJECTILE_LAYER, _projectileColliders);
            Fox fox = new Fox(foxObject.transform, new MoveLinear(foxObject.transform, _speed), new DamageSimple(_maxHealth, foxObject.transform), _target, toucher);
            toucher.BaseObject = fox;
            //_enemyColliders.Add(foxCollider, fox);
            return fox;
        }
    }
}