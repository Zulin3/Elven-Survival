using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Assets.Scripts.GeneralClasses
{
    internal class EnemiesInitialization
    {
        private IEnemyFactory _denFactory;
        private IEnemyFactory _enemyFactory;
        private ColliderDictionary<IColliding> _enemyColliders;
        private ColliderDictionary<IColliding> _projectileColliders;
        private List<Enemy> _enemyList;
        private Player _player;
        public EnemiesInitialization(ColliderDictionary<IColliding> enemyColliders, ColliderDictionary<IColliding> projectileColliders, List<Enemy> enemyList, Player player)
        {
            _enemyColliders = enemyColliders;
            _projectileColliders = projectileColliders;
            _enemyList = enemyList;
            _player = player;

            _enemyFactory = new FoxFactory(_player.View, _enemyColliders, _projectileColliders, _enemyList);
            Fox fox = (Fox)_enemyFactory.Create(new Vector3(2, 2, 0));
            _denFactory = new MonsterDenFactory(_player.View, _enemyColliders, _projectileColliders, fox, _enemyList);

            MonsterDen den = (MonsterDen)_denFactory.Create(new Vector3(4, 4, 0));
            den.SpawnUnit();
        }
    }
}
