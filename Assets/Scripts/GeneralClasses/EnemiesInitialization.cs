using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    internal class EnemiesInitialization
    {
        private IEnemyFactory _denFactory;
        private IEnemyFactory _foxFactory;
        private IEnemyFactory _birdFactory;
        private ColliderDictionary<IColliding> _enemyColliders;
        private ColliderDictionary<IColliding> _projectileColliders;
        private List<Enemy> _enemyList;
        private Player _player;
        private SpawnHandler _spawnChain;
        public EnemiesInitialization(ColliderDictionary<IColliding> enemyColliders, ColliderDictionary<IColliding> projectileColliders, List<Enemy> enemyList, Player player)
        {
            _enemyColliders = enemyColliders;
            _projectileColliders = projectileColliders;
            _enemyList = enemyList;
            _player = player;

            _foxFactory = new FoxFactory(_player.View, _enemyColliders, _projectileColliders, _enemyList);
            Fox foxTemplate = (Fox)_foxFactory.Create(new Vector3(2, 2, 0));
            _denFactory = new MonsterDenFactory(_player.View, _enemyColliders, _projectileColliders, foxTemplate, _enemyList);
            
            _birdFactory = new BirdFactory(_player.View, _enemyColliders, _projectileColliders, _enemyList);
            _spawnChain = new SpawnHandler(_denFactory, 5, new Vector3(4, 4, 0));
            _spawnChain.SetNext(new SpawnHandler(_denFactory, 5, new Vector3(-4, -4, 0)));
            _spawnChain.SetNext(new SpawnHandler(_denFactory, 5, new Vector3(4, -4, 0)));
            _spawnChain.SetNext(new SpawnHandler(_denFactory, 5, new Vector3(-4, 4, 0)));
        }

        public void SpawnEnemies()
        {
            MonsterDen den = (MonsterDen)_denFactory.Create(new Vector3(4, 4, 0));

            _birdFactory.Create(new Vector3(-10, -5, 0));
            _spawnChain.Handle();
        }
    }
}
