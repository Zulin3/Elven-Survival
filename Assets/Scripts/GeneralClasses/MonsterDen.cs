using Assets.Scripts.Interfaces;
using Assets.Scripts.MyLibraries;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    internal class MonsterDen : Enemy, IUnitSpawner
    {
        private Enemy _enemyTemplate;
        private List<Enemy> _enemyList;
        public Enemy EnemyTemplate
        {
            set
            {
                _enemyTemplate = value;
                _enemyTemplate.View.position = _view.position;
                _enemyTemplate.View.gameObject.SetActive(false);
            }
        }
        public MonsterDen(Transform view, IMove moveImplementation, IDamageable damageable, Transform target, BaseToucher touch, List<Enemy> enemyList) : base(view, moveImplementation, damageable, target, touch)
        {
            _enemyList = enemyList;
        }

        public Unit SpawnUnit()
        {
            Unit _spawnUnit = (Enemy) _enemyTemplate.Clone();
            _enemyList.Add((Enemy) _spawnUnit);
            return _spawnUnit;
        }
    }
}
