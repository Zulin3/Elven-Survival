using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine;
using Assets.Scripts.Interfaces;
using Assets.Scripts.enums;
using Assets.Scripts.MyLibraries;
using Assets.Scripts.ScriptableObjects;

namespace Assets.Scripts.GeneralClasses
{
    internal sealed class Game
    {
        private Player _player;
        private Transform _playerView;
        private IControl _control;

        private List<Enemy> _enemyList;
        private List<Projectile> _projectileList;
        
        private ColliderDictionary<IColliding> _enemyColliders;
        private ColliderDictionary<IColliding> _projectileColliders;

        private UnlockShoota _unlockShoota;

        public Game(Transform playerView)
        {
            ServiceLocator.SetService<IViewServices>(new ViewServices());

            _enemyColliders = new ColliderDictionary<IColliding>();
            _projectileColliders = new ColliderDictionary<IColliding>();
            _enemyList = new List<Enemy>();
            _projectileList = new List<Projectile>();
            _control = new ControlPC();
            _playerView = playerView;
        }

        public void InitGame()
        {
            var playerInitialization = new PlayerInitialization(_playerView, _projectileList, _projectileColliders, _enemyColliders, _control);
            _player = playerInitialization.InitPlayer();
            _unlockShoota = playerInitialization.UnlockShoota;

            var enemiesInitialization = new EnemiesInitialization(_enemyColliders, _projectileColliders, _enemyList, _player);
        }

        public void Update()
        {

            _player.HandleControls(Time.deltaTime);
            foreach (var enemy in _enemyList)
            {
                if (enemy != null)
                    enemy.Move(Time.deltaTime);
            }
            foreach (var projectile in _projectileList)
            {
                if (projectile is Arrow)
                    ((Arrow)projectile).Move(Time.deltaTime);
            }

            if (_control.isWeaponUnlock())
            {
                _unlockShoota.isUnlock = !_unlockShoota.isUnlock;
            }
        }
    }
}
