using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using System;
using Assets.Scripts.MyLibraries;

namespace Assets.Scripts.GeneralClasses
{
    internal class MonsterDen : Enemy, IUnitSpawner
    {
        private Enemy _enemyTemplate;
        private List<Enemy> _enemyList;
        private float _spawnDelay;
        private bool _isSpawning = false;
        public Enemy EnemyTemplate
        {
            set
            {
                _enemyTemplate = value;
                _enemyTemplate.View.position = _view.position;
                _enemyTemplate.View.gameObject.SetActive(false);
            }
        }
        public MonsterDen(Transform view, IMove moveImplementation, IDamageable damageable, Transform target, BaseToucher touch, List<Enemy> enemyList, float spawnDelay, int pointsReward) : base(view, moveImplementation, damageable, target, touch, pointsReward)
        {
            _enemyList = enemyList;
            _spawnDelay = spawnDelay;
            OnDeath += HandleDeath;
        }

        private async UniTaskVoid ContinueSpawning()
        {
            Debug.Log(this);
            while (_isSpawning)
            {
                Debug.Log(this);
                SpawnUnit();
                await UniTask.Delay(TimeSpan.FromSeconds(_spawnDelay));
            }
        }

        public void StartSpawning()
        {
            _isSpawning = true;
            ContinueSpawning().Forget();
        }

        private void HandleDeath(object sender, EventArgs e)
        {
            StopSpawning();
        }

        public void StopSpawning()
        {
            _isSpawning = false;
        }

        public Unit SpawnUnit()
        {
            Unit _spawnUnit = (Enemy) _enemyTemplate.Clone();
            _enemyList.Add((Enemy) _spawnUnit);
            return _spawnUnit;
        }
    }
}
