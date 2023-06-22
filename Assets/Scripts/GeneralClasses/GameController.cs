using Assets.Scripts.GeneralClasses;
using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using static Assets.Scripts.GeneralClasses.Constants;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.MyLibraries;
using Assets.Scripts.enums;
using Assets.Scripts.ScriptableObjects;

namespace Assets.Scripts.GeneralClasses
{
    internal sealed class GameController : MonoBehaviour
    {
        [SerializeField] private Transform _playerView;
        [SerializeField] private GameObject _projectile;
        private ViewServices _viewServices;
        private Player _player;
        private IEnemyFactory _enemyFactory;
        private List<Enemy> _enemyList;
        private List<Projectile> _projectileList;
        private IControl _control;
        private ColliderDictionary<IColliding> _enemyColliders;
        private ColliderDictionary<IColliding> _projectileColliders;

        void Start()
        {
            _viewServices = new ViewServices();
            _enemyColliders = new ColliderDictionary<IColliding>();
            _projectileColliders = new ColliderDictionary<IColliding>();

            _enemyFactory = new FoxFactory(_playerView, _enemyColliders, _projectileColliders);
            _enemyList = new List<Enemy>();
            _projectileList = new List<Projectile>();
            _control = new ControlPC();

            var arrowData = Resources.Load<ArrowData>("ScriptableObjects/ArrowData");
            var playerData = Resources.Load<PlayerData>("ScriptableObjects/PlayerData");

            Shoota shoota = new Shoota(_playerView, _projectile, ProjectileType.Arrow, _viewServices, 1, _projectileList, _projectileColliders);
            shoota.Speed = arrowData.speed;
            shoota.Damage = arrowData.damage;

            var playerTouch = new SimpleSphereToucher(_playerView, 1f, Constants.ENEMY_LAYER, _enemyColliders);
            _player = new Player(_playerView, new MoveLinear(_playerView, playerData.speed), _control, new DamageSimple(playerData.maxHealth, _playerView), playerTouch, shoota);
            playerTouch.BaseObject = _player;

            Fox fox = (Fox)_enemyFactory.Create(new Vector3(2, 2, 0));
            _enemyList.Add(fox);
            fox = (Fox)_enemyFactory.Create(new Vector3(-2, 2, 0));
            _enemyList.Add(fox);
            fox = (Fox)_enemyFactory.Create(new Vector3(2, -2, 0));
            _enemyList.Add(fox);
            fox = (Fox)_enemyFactory.Create(new Vector3(-2, -2, 0));
            _enemyList.Add(fox);
            fox = (Fox)_enemyFactory.Create(new Vector3(0, 2, 0));
            _enemyList.Add(fox);
            fox = (Fox)_enemyFactory.Create(new Vector3(2, 0, 0));
            _enemyList.Add(fox);
            fox = (Fox)_enemyFactory.Create(new Vector3(-2, 0, 0));
            _enemyList.Add(fox);
            fox = (Fox)_enemyFactory.Create(new Vector3(0, -2, 0));
            _enemyList.Add(fox);
        }


        void Update()
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


        }
    }
}