using Assets.Scripts.enums;
using Assets.Scripts.Interfaces;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    internal sealed class SpawnHandler: GameHandler
    {
        private float _spawnDelay;
        private IEnemyFactory _enemyFactory;
        private Vector3 _position;

        public SpawnHandler(IEnemyFactory enemyFactory, float spawnDelay, Vector3 position)
        {
            _spawnDelay = spawnDelay;
            _enemyFactory = enemyFactory;
            _position = position;
        }

        public override async void Handle()
        {
            _enemyFactory.Create(_position);
            await UniTask.Delay(TimeSpan.FromSeconds(_spawnDelay));
            base.Handle();
        }
    }
}
