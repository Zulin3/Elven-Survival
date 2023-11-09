using Assets.Scripts.enums;
using Assets.Scripts.Interfaces;
using Assets.Scripts.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GeneralClasses
{
    internal sealed class PlayerInitialization
    {
        private UnlockShoota _unlockShoota;
        private Transform _playerView;
        private IShoota _shootaProxy;
        private PlayerData _playerData;
        private ColliderDictionary<IColliding> _projectileColliders;
        private ColliderDictionary<IColliding> _enemyColliders;
        private List<Projectile> _projectileList;
        private IControl _control;

        public PlayerInitialization(Transform playerView, List<Projectile> projectileList, ColliderDictionary<IColliding> projectileColliders, ColliderDictionary<IColliding> enemyColliders, IControl control)
        {
            _playerView = playerView;
            _projectileColliders = projectileColliders;
            _enemyColliders = enemyColliders;
            _control = control;
            _projectileList = projectileList;
            _playerData = Resources.Load<PlayerData>("ScriptableObjects/PlayerData");
        }

        public UnlockShoota UnlockShoota { get => _unlockShoota; set => _unlockShoota = value; }

        public Player InitPlayer()
        {
            var arrowData = Resources.Load<ArrowData>("ScriptableObjects/ArrowData");
            _unlockShoota = new UnlockShoota(true);
            Shoota shoota = new Shoota(_playerView, ProjectileType.Arrow, _projectileList, _projectileColliders);
            _shootaProxy = new ShootaProxy(shoota, _unlockShoota);

            Shoota trapBag = new Shoota(_playerView, ProjectileType.Trap, _projectileList, _projectileColliders);

            var playerTouch = new SimpleSphereToucher(_playerView, 1f, Constants.ENEMY_LAYER, _enemyColliders);
            var player = new Player(_playerView, new MoveLinear(_playerView, _playerData.speed), _control, new DamageSimple(_playerData.maxHealth, _playerView), playerTouch, _shootaProxy, trapBag);
            playerTouch.BaseObject = player;
            return player;
        }
    }
}
